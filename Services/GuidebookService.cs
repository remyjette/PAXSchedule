using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PAXSchedule.Models.Gudebook;
using PAXSchedule.Models;
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

namespace PAXSchedule.Services
{
    public class GuidebookService
    {
        private readonly IHttpClientFactory _clientFactory;

        private Dictionary<string, Show> _shows;

        public GuidebookService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

            _shows = new Dictionary<string, Show>()
            {
                { "paxeast2019", new Show("paxeast2019", "PAX East 2019", this) }
            };
        }

        public async Task<(FileInfo databasePath, DbContextOptions<GuidebookContext> dbContextOptions)> DownloadGuidebookDb(string showName)
        {
            using var client = _clientFactory.CreateClient();

            var searchResponse = await client.GetStringAsync("https://gears.guidebook.com/service/v2/search/?q=" + WebUtility.UrlEncode(showName));
            var j = JObject.Parse(searchResponse);

            var showIdentifier = j["data"].FirstOrDefault(x => x.Value<string>("name") == showName)?.Value<string>("productIdentifier");

            using var guidebookDatabaseStream = await client.GetStreamAsync($"https://gears.guidebook.com/service/v2/guides/{showIdentifier}/bundle/");
            using var guidebookArchive = new ZipArchive(guidebookDatabaseStream);
            var database = guidebookArchive.GetEntry("guide.db");

            var databasePath = Path.GetTempFileName();

            database.ExtractToFile(databasePath, true);
            var optionsBuilder = new DbContextOptionsBuilder<GuidebookContext>();
            optionsBuilder.UseSqlite("Data Source=" + databasePath);

            return (new FileInfo(databasePath), optionsBuilder.Options);
        }

        public Show GetShow(string showName)
        {
            return _shows[showName];
        }
    }
}
