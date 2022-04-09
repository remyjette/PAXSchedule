using Microsoft.EntityFrameworkCore;
using PAXSchedule.Models.Gudebook;
using PAXSchedule.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PAXSchedule.Models
{
    public class Show
    {
        private static readonly TimeSpan eventExpiration = new(1, 0, 0, 0);

        public string Name { get; }
        public string FullName { get; }
        private readonly GuidebookService _guidebookService;
        private readonly SemaphoreSlim _configureSemaphore = new(1);
        private DbContextOptions<GuidebookContext>? _dbContextOptions;
        private FileInfo? _databasePath;

        private bool _configured = false;
        private DateTime _lastUpdated;
        public bool Configured { get { return _configured && _lastUpdated < DateTime.Now.Add(eventExpiration); } }

        public Show(string name, string fullName, GuidebookService guidebookService)
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

            // Configured is checked twice. First outside the semaphore so that once
            // we've configured, we never need to wait on the semaphore since everything
            // will be readonly. Second inside the semaphore in case two threads get in
            // here at the same time.
            if (!Configured)
            {
                if (_databasePath != null)
                {
                    // TODO: Do this on a background task with a delay to avoid breaking
                    // active DbContexts that are still using this data source.
                    // TODO: Cleanup on app shutdown
                    _databasePath.Delete();
                }

                (_databasePath, _dbContextOptions) = await _guidebookService.DownloadGuidebookDb(FullName);
                _lastUpdated = DateTime.Now;
                _configured = true;
            }

            _configureSemaphore.Release();
        }

        public async Task<GuidebookContext> GetDbContext()
        {
            await Configure();
            return new GuidebookContext(_dbContextOptions!);
        }
    }
}
