// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () { // document ready
$.getJSON(eventsUrl)
    .done(function (events) {
        var locations = _.chain(events).map(e => e.eventLocation.location).uniq(l => l.id).value();

        // Function to determine if background color should have white or black text to provide
        // sufficient contrast http://www.w3.org/TR/AERT#color-contrast
        var shouldUseBlackText = function(hexValue) {
            var result = /^#?([A-Fa-f\d]{2})([A-Fa-f\d]{2})([A-Fa-f\d]{2})$/i.exec(hexValue);
            if (result == null) {
                return true; // Couldn't parse the hex value, default to black text.
            }
            var rgb = {
                r: parseInt(result[1], 16),
                g: parseInt(result[2], 16),
                b: parseInt(result[3], 16)
            };

            return Math.round((
                (rgb['r'] * 299) +
                (rgb['g'] * 587) +
                (rgb['b'] * 114)) / 1000) > 125;
        }

        var events = _(events).map(e =>
            _.extend(e, {
                'title': e.name,
                'resourceId': e.locations,
                'start': e.startTime,
                'end': e.endTime,
                'color': e.scheduleTracks[0].schedule.hexValue,
                'textColor': shouldUseBlackText(e.scheduleTracks[0].schedule.hexValue) ? "black" : "white"
            })
        );

        // TODO: consolidate these two
        var minTime = _.chain(events).pluck('startTime').map(dateString =>
            JSJoda.LocalDateTime.ofInstant(JSJoda.Instant.ofEpochMilli(new Date(dateString).getTime())).toLocalTime()
        )
            .min(x => x.toSecondOfDay())
            .value()
            .toString();
        var maxTime = _.chain(events).pluck('endTime').map(dateString =>
            JSJoda.LocalDateTime.ofInstant(JSJoda.Instant.ofEpochMilli(new Date(dateString).getTime())).toLocalTime()
        )
            .max(x => x.toSecondOfDay())
            .value()
            .toString();

        var calendarElement = document.getElementById('calendar');
        $(calendarElement).empty(); // remove loading icon
        var calendar = new FullCalendar.Calendar(calendarElement, {
            schedulerLicenseKey: "CC-Attribution-NonCommercial-NoDerivatives",
            defaultView: 'agendaDay',
            height: 'auto',
            validRange: {
                start: '2019-03-28',
                end: '2019-04-01'
            },
            minTime: minTime,
            maxTime: maxTime,
            editable: false,
            selectable: true,
            eventLimit: true, // allow "more" link when too many events
            header: {
                left: 'prev,next',
                center: 'title',
            },
            titleFormat: { // will produce something like "Tuesday, September 18, 2018"
                month: 'long',
                year: 'numeric',
                day: 'numeric',
                weekday: 'long'
            },
            views: {
                agendaTwoDay: {
                    type: 'agenda',
                    duration: { days: 2 },

                    // views that are more than a day will NOT do this behavior by default
                    // so, we need to explicitly enable it
                    groupByResource: true

                    //// uncomment this line to group by day FIRST with resources underneath
                    //groupByDateAndResource: true
                }
            },

            resourceOrder: 'title',
            filterResourcesWithEvents: true,
            resourceText: resource => resource.extendedProps.name,

            //// uncomment this line to hide the all-day slot
            allDaySlot: false,

            resources: locations,

            events: events,

            eventRender: function (info) {
                $(info.el).find('.fc-title').on('click', e => {
                    console.log('Clicked title: ' + info.event.title);
                    e.stopPropagation();
                });
            },

            eventClick: function (info) {
                console.log('Clicked event: ' + info.event.title);
            },
        });

        calendar.render();
    });
});
