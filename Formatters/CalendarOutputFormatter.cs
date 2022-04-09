using Ical.Net;
using Ical.Net.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PAXSchedule
{
    public class CalendarOutputFormatter : TextOutputFormatter
    {
        public CalendarOutputFormatter()
        {
            SupportedMediaTypes.Add(Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/calendar"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(Calendar).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            string? filename = context.HttpContext.Items["filename"] as string;
            if (!string.IsNullOrWhiteSpace(filename))
            {
                if (!filename.EndsWith(".ics"))
                {
                    filename += ".ics";
                }
                context.HttpContext.Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{filename}\"");
            }

            var calendar = context.Object as Calendar;
            var serializer = new CalendarSerializer(new SerializationContext());
            var serializedCalendar = serializer.SerializeToString(calendar);

            return context.HttpContext.Response.WriteAsync(serializedCalendar);
        }
    }
}
