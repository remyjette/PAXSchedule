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
        public string Name { get; }
        public string FullName { get; }
        public bool Configured { get; private set; }
        private readonly GuidebookService _guidebookService;
        private readonly SemaphoreSlim _configureSemaphore = new SemaphoreSlim(1);
        private DbContextOptions<GuidebookContext> _dbContextOptions;

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
                // here at the same time.S
                _dbContextOptions = await _guidebookService.DownloadGuidebookDb(FullName);
                Configured = true;
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
