// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () { // document ready

var selectedEvents = []; // TODO: initialize from URL
// This function should be called every time selectedEvents is modified.
// TODO: Use Proxy to do this automatically
function onSelectedEventsChanged() {
    var hashids = new Hashids();
    var hash = hashids.encode(...(_(selectedEvents).map(x => parseInt(x, 10))));
    window.history.replaceState({ hashids: hash }, "" /* title */, viewShowUrl + "/" + hash);
}
onSelectedEventsChanged();

// Define the eventRender function globally instead of inline so we can call it directly from the eventClick event.
// While we could just use calendar.render(), that introduces latency - just re-applying the render effect on the
// specific event has much better performance.
function eventRender(info) {
    var $titleDiv = $(info.el).find('.fc-title');
    var index = selectedEvents.indexOf(info.event.id);

    if (index == -1) {
        $titleDiv.css('font-weight', 'normal');
    } else {
        $titleDiv.css('font-weight', 'bold');
    }
}

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

            resourceOrder: 'name',
            filterResourcesWithEvents: true,
            resourceText: resource => resource.extendedProps.name,

            allDaySlot: false,

            resources: locations,

            events: events,

            eventRender: function (info) {
                $(info.el).find('.fc-title').on('click', e => {
                    console.log('Clicked title: ' + info.event.title);
                    e.stopPropagation();
                });

                eventRender(info);
            },

            eventClick: function (info) {
                var index = selectedEvents.indexOf(info.event.id);
                if (index != -1) {
                    selectedEvents.splice(index, 1);
                } else {
                    selectedEvents.push(info.event.id);
                }

                eventRender(info);

                onSelectedEventsChanged();
            },
        });

        calendar.render();
    });
});
