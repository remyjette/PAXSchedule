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
                { "paxeast2022", new Show("paxeast2022", "PAX East 2022", this) }
            };
        }

        public async Task<(FileInfo databasePath, DbContextOptions<GuidebookContext> dbContextOptions)> DownloadGuidebookDb(string showName)
        {
            using var client = _clientFactory.CreateClient();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://guidebook.com/og/service/v2/search/?q=" + WebUtility.UrlEncode(showName));
            requestMessage.Headers.Add("x-gb-appid", "13");
            var response = await client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            var searchResponse = await response.Content.ReadAsStringAsync();

            var j = JObject.Parse(searchResponse);

            var showIdentifier = j["data"].FirstOrDefault(x => x.Value<string>("name") == showName)?.Value<string>("productIdentifier");

            if (showIdentifier == null)
            {
                throw new Exception($"Couldn't find show with name {showName}");
            }

            using var guidebookDatabaseStream = await client.GetStreamAsync($"https://gears.guidebook.com/service/v2/guides/{showIdentifier}/bundle/");
            using var guidebookArchive = new ZipArchive(guidebookDatabaseStream);
            var database = guidebookArchive.GetEntry("guide.db");

            var databasePath = Path.GetTempFileName();

            database.ExtractToFile(databasePath, true);
            var optionsBuilder = new DbContextOptionsBuilder<GuidebookContext>();
            optionsBuilder.UseSqlite("Data Source=" + databasePath);

            return (new FileInfo(databasePath), optionsBuilder.Options);
        }
        public Show GetDefaultShow()
        {
            return _shows.First().Value;
        }

        public Show GetShow(string showName)
        {
            return _shows.TryGetValue(showName, out var show) ? show : null;
        }
    }
}
