using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PAXScheduler.Models.Gudebook;
using PAXScheduler.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PAXScheduler.Services
{
    public class GuidebookService
    {
        private readonly IHttpClientFactory _clientFactory;
        private bool _configured = false;
        private readonly SemaphoreSlim configureSemaphore = new SemaphoreSlim(1);

        private Dictionary<string, Event> _events = new Dictionary<string, Event>
        {
            { "paxeast2019", new Event("PAX East 2019") }
        };

        public GuidebookService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private async Task Configure()
        {
            await configureSemaphore.WaitAsync();

            if (!_configured)
            {
                foreach (var item in _events)
                {
                    var databasePath = await DownloadGuidebookDb(item.Value);
                    var optionsBuilder = new DbContextOptionsBuilder<GuidebookContext>();
                    optionsBuilder.UseSqlite("Data Source=" + databasePath);
                    item.Value.DbContextOptions = optionsBuilder.Options;
                }
                _configured = true;
            }

            configureSemaphore.Release();
        }

        private async Task<string> DownloadGuidebookDb(Event @event)
        {
            using var client = _clientFactory.CreateClient();

            var searchResponse = await client.GetStringAsync("https://gears.guidebook.com/service/v2/search/?q=" + WebUtility.UrlEncode(@event.Name));
            var j = JObject.Parse(searchResponse);

            var eventIdentifier = j["data"].FirstOrDefault(x => x.Value<string>("name") == @event.Name)?.Value<string>("productIdentifier");

            using var guidebookDatabaseStream = await client.GetStreamAsync($"https://gears.guidebook.com/service/v2/guides/{eventIdentifier}/bundle/");
            using var guidebookArchive = new ZipArchive(guidebookDatabaseStream);
            var database = guidebookArchive.GetEntry("guide.db");

            var databasePath = Path.GetTempFileName();
            database.ExtractToFile(databasePath, true);

            return databasePath;
        }

        public async Task<GuidebookContext> GetDbContext(string eventName)
        {
            // Configure() will check _configured under the semaphore. Once we're configured
            // there's no need for the overhead of a semaphore just to check a boolean that
            // won't change. So check it here as well.
            if (!_configured)
            {
                await Configure();
            }

            if (!_events.ContainsKey(eventName))
            {
                return null;
            }

            return new GuidebookContext(_events[eventName].DbContextOptions);
        }
    }
}
