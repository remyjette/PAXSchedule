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

        private Dictionary<string, Event> _events;

        public GuidebookService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

            _events = new Dictionary<string, Event>()
            {
                { "paxeast2019", new Event("paxeast2019", "PAX East 2019", this) }
            };
        }

        public async Task<DbContextOptions<GuidebookContext>> DownloadGuidebookDb(string eventName)
        {
            using var client = _clientFactory.CreateClient();

            var searchResponse = await client.GetStringAsync("https://gears.guidebook.com/service/v2/search/?q=" + WebUtility.UrlEncode(eventName));
            var j = JObject.Parse(searchResponse);

            var eventIdentifier = j["data"].FirstOrDefault(x => x.Value<string>("name") == eventName)?.Value<string>("productIdentifier");

            using var guidebookDatabaseStream = await client.GetStreamAsync($"https://gears.guidebook.com/service/v2/guides/{eventIdentifier}/bundle/");
            using var guidebookArchive = new ZipArchive(guidebookDatabaseStream);
            var database = guidebookArchive.GetEntry("guide.db");

            var databasePath = Path.GetTempFileName(); // TODO clean this up when we're done using it

            database.ExtractToFile(databasePath, true);
            var optionsBuilder = new DbContextOptionsBuilder<GuidebookContext>();
            optionsBuilder.UseSqlite("Data Source=" + databasePath);

            return optionsBuilder.Options;
        }

        public Event GetEvent(string eventName)
        {
            return _events[eventName];
        }
    }
}
