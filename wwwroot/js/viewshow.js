// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () { // document ready

    var calendarElement = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarElement, {
        schedulerLicenseKey: "CC-Attribution-NonCommercial-NoDerivatives",
        defaultView: 'agendaDay',
        validRange: {
            start: '2019-03-28',
            end: '2019-04-01'
        },
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

        resources: [
            { id: 'a', title: 'Room A' },
            { id: 'b', title: 'Room B', eventColor: 'green' },
            { id: 'c', title: 'Room C', eventColor: 'orange' },
            { id: 'd', title: 'Room D', eventColor: 'red' }
        ],
        events: [
            { id: '1', resourceId: 'a', start: '2018-04-06', end: '2018-04-08', title: 'event 1' },
            { id: '2', resourceId: 'a', start: '2018-04-07T09:00:00', end: '2018-04-07T14:00:00', title: 'event 2' },
            { id: '3', resourceId: 'b', start: '2018-04-07T12:00:00', end: '2018-04-08T06:00:00', title: 'event 3' },
            { id: '4', resourceId: 'c', start: '2018-04-07T07:30:00', end: '2018-04-07T09:30:00', title: 'event 4' },
            { id: '5', resourceId: 'd', start: '2019-03-30T10:00:00', end: '2019-03-30T15:00:00', title: 'event 5', test: "test" }
        ],

        eventClick: function (a, b, c, d, e) {
            console.log('event');
        },
    });

    calendar.render();

});
