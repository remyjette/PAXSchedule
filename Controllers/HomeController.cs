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
using PAXScheduler.Models.Gudebook;
using PAXScheduler.Models;
using PAXScheduler.Services;

namespace PAXScheduler.Controllers
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
            return View();
        }

        [HttpGet("{eventName}/[action]")]
        [HttpGet("{eventName}/[action]/{eventHashids}")]
        public async Task<IActionResult> Download(string eventName, string eventHashids)
        {
            using var context = await _guidebookService.GetEvent(eventName).GetDbContext();

            if (context == null)
            {
                return NotFound();
            }

            // eventPredicate will determine if a given event should be included in the calendar
            // If eventHashIds is null, include all events
            Expression<Func<GuidebookEvent, bool>> eventPredicate = calendarEvent => true;

            if (eventHashids != null)
            {
                var hashids = new HashidsNet.Hashids();
                var eventIds = hashids.DecodeLong(eventHashids);
                eventPredicate = guidebookEvent => eventIds.Contains(guidebookEvent.Id);
            }

            var calendar = new Calendar();
            calendar.Events.AddRange(context.GuidebookEvent
                .Where(eventPredicate)
                .Select(e => new CalendarEvent
                {
                    Uid = e.Id.ToString() + "_" + e.GuideId.ToString() + "@paxschedule.com",
                    Summary = e.Name,
                    Start = new CalDateTime(Convert.ToDateTime(e.StartTime), e.Guide.Timezone),
                    End = new CalDateTime(Convert.ToDateTime(e.EndTime), e.Guide.Timezone),
                    Description = e.Description,
                    Location = e.EventLocation.Location.Name
                }));

            return Ok(calendar);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
