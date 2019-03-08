using Microsoft.EntityFrameworkCore;
using PAXScheduler.Models.Gudebook;
using PAXScheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PAXScheduler.Models
{
    public class Event
    {
        private static TimeSpan eventExpiration = new TimeSpan(1, 0, 0, 0);

        public string Name { get; }
        public string FullName { get; }
        private readonly GuidebookService _guidebookService;
        private readonly SemaphoreSlim _configureSemaphore = new SemaphoreSlim(1);
        private DbContextOptions<GuidebookContext> _dbContextOptions;

        private bool _configured = false;
        private DateTime _lastUpdated;
        public bool Configured { get { return _configured && _lastUpdated < DateTime.Now.Add(eventExpiration); } }

        public Event(string name, string fullName, GuidebookService guidebookService)
        {
            Name = name;
            FullName = fullName;
            _guidebookService = guidebookService;
        }

        public async Task Configure()
        {
            if (Configured)
            {
                return;
            }

            await _configureSemaphore.WaitAsync();

            if (!Configured)
            {
                // Configured is checked twice. First outside the semaphore so that once
                // we've configured, we never need to wait on the semaphore since everything
                // will be readonly. Second inside the semaphore in case two threads get in
                // here at the same time.
                _dbContextOptions = await _guidebookService.DownloadGuidebookDb(FullName);
                _lastUpdated = DateTime.Now;
                _configured = true;
            }

            _configureSemaphore.Release();
        }

        public async Task<GuidebookContext> GetDbContext()
        {
            await Configure();
            return new GuidebookContext(_dbContextOptions);
        }
    }
}
