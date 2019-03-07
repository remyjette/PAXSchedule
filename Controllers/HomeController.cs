using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Download(string eventName)
        {
            using var context = await _guidebookService.GetDbContext(eventName);

            if (context == null)
            {
                return NotFound();
            }

            var calendar = new Calendar();
            calendar.Events.AddRange(context.GuidebookEvent.Select(e => new CalendarEvent
            {
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
