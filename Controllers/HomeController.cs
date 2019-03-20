using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAXSchedule.Models.Gudebook;
using PAXSchedule.Models;
using PAXSchedule.Services;
using Microsoft.AspNetCore.Http.Features;

namespace PAXSchedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly GuidebookService _guidebookService;

        public HomeController(GuidebookService guidebookService)
        {
            _guidebookService = guidebookService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(ViewShow), new { showName = "paxeast2019" });
        }

        [HttpGet("{showName}")]
        [HttpGet("{showName}/{hashids}")] // Ignored by the controller, will be read by the page Javascript
        public IActionResult ViewShow(string showName)
        {
            var show = _guidebookService.GetShow(showName);

            ViewData["ShowName"] = show.FullName;
            ViewData["CalendarUrl"] = Url.Action(nameof(Calendar), new { showName });
            ViewData["EventsUrl"] = Url.Action(nameof(Events), new { showName });
            ViewData["ViewShowUrl"] = Url.Action(nameof(ViewShow), new { showName, hashids = "" });
            return View(show);
        }

        private IQueryable<GuidebookEvent> GetEvents(GuidebookContext context, string eventHashids)
        {
            // eventPredicate will determine if a given event should be included in the calendar
            // If eventHashIds is null, include all events
            Expression<Func<GuidebookEvent, bool>> eventPredicate = calendarEvent => true;

            if (eventHashids != null)
            {
                var hashids = new HashidsNet.Hashids();
                var eventIds = hashids.DecodeLong(eventHashids);
                eventPredicate = guidebookEvent => eventIds.Contains(guidebookEvent.Id);
            }

            return context.GuidebookEvent.Where(eventPredicate);
        }

        [HttpGet("{showName}/[action]")]
        [HttpGet("{showName}/[action]/{eventHashids}")]
        [Produces("application/json")]
        public async Task<IActionResult> Events(string showName, string eventHashids)
        {
            // Workaround for https://github.com/aspnet/AspNetCore/issues/7644
            var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
            if (syncIOFeature != null)
            {
                syncIOFeature.AllowSynchronousIO = true;
            }

            using var context = await _guidebookService.GetShow(showName).GetDbContext();

            if (context == null)
            {
                return NotFound();
            }

            var events = await GetEvents(context, eventHashids)
                .Include(e => e.EventLocation.Location)
                .Include(e => e.ScheduleTracks)
                    .ThenInclude(st => st.Schedule)
                .ToListAsync();

            if (!events.Any())
            {
                return NotFound();
            }

            return Ok(events);
        }

        [HttpGet("{showName}/[action]")]
        [HttpGet("{showName}/[action]/{eventHashids}")]
        [Produces("text/calendar")]
        public async Task<IActionResult> Calendar(string showName, string eventHashids)
        {
            HttpContext.Items.Add("filename", showName + ".ics");

            var show = _guidebookService.GetShow(showName);
            using var context = await show.GetDbContext();

            var events = GetEvents(context, eventHashids);

            if (!events.Any())
            {
                return NotFound();
            }

            var calendar = new Calendar();
            calendar.Properties.Add(new CalendarProperty("X-WR-CALNAME", show.FullName));
            var timezone = context.GuidebookGuide.FirstOrDefault()?.Timezone;
            if (timezone != null)
            {
                // If we can find a Windows Zone for this Time Zone, use that so it'll appear nicer in Outlook.
                timezone = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default.WindowsMapping.MapZones
                    .FirstOrDefault(z => z.TzdbIds.Contains(timezone))?.WindowsId ?? timezone;
                calendar.AddTimeZone(timezone);
            }
            calendar.Events.AddRange(events.Select(e => new CalendarEvent
                {
                    Uid = e.Id.ToString() + "_" + e.GuideId.ToString() + "@paxschedule.com",
                    Summary = e.Name,
                    Start = new CalDateTime(Convert.ToDateTime(e.StartTime), timezone),
                    End = new CalDateTime(Convert.ToDateTime(e.EndTime), timezone),
                    Description = e.Description,
                    Location = e.EventLocation.Location.Name
                }));

            return Ok(calendar);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
