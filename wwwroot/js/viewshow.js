// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () { // document ready
$.getJSON(eventsUrl)
    .done(function (events) {
        var locations = _.chain(events).map(e => e.eventLocation.location).uniq(l => l.id).map(l => _.extend(l, { 'title': l.name })).value();

        var events = _(events).map(e => _.extend(e, { 'title': e.name, 'resourceId': e.locations, 'start': e.startTime, 'end': e.endTime }));

        // TODO: consolidate these two
        var minTime = _.chain(events).pluck('startTime').map(dateString => {
            return JSJoda.LocalDateTime.ofInstant(JSJoda.Instant.ofEpochMilli(new Date(dateString).getTime())).toLocalTime();
        })
            .min(x => x.toSecondOfDay())
            .value()
            .toString();
        var maxTime = _.chain(events).pluck('endTime').map(dateString => {
            return JSJoda.LocalDateTime.ofInstant(JSJoda.Instant.ofEpochMilli(new Date(dateString).getTime())).toLocalTime();
        })
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

            //// uncomment this line to hide the all-day slot
            allDaySlot: false,

            resources: locations,

            events: events,

            eventClick: function (a, b, c, d, e) {
                console.log('event');
            },
        });

        calendar.render();

    });
});
