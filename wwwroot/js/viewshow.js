// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () { // document ready
    $("#calendarUrl input").on('click', function () {
        $(this).select();
    });
    $("#calendarUrl .copy-button")
        .on('click', function () {
            $("#calendarUrl input").select();
            document.execCommand('copy');
            setTimeout(() => $(this).tooltip('hide'), 1000);
        })
        .tooltip({ trigger: "click" });

    var hashids = new Hashids();

    var initialUrl = location.pathname;
    var initialHash = initialUrl.replace(viewShowUrl + "/", "");
    var selectedEvents = hashids.decode(initialHash);

    // This function should be called every time selectedEvents is modified.
    // TODO: Use Proxy to do this automatically
    var hash = ''; // Global so it can be accessed by download/subscribe buttons
    function onSelectedEventsChanged() {
        hash = hashids.encode(...selectedEvents);
        window.history.replaceState({ hashids: hash }, "" /* title */, viewShowUrl + "/" + hash);
        url = window.location.origin + calendarUrl + "/" + hash;
        $("#calendarUrl input").val(window.location.origin + calendarUrl + "/" + hash);
        $('.download-button').attr('href', url);
    }
    onSelectedEventsChanged();

    // Define the eventRender function globally instead of inline so we can call it directly from the eventClick event.
    // While we could just use calendar.render(), that introduces latency - just re-applying the render effect on the
    // specific event has much better performance.
    function eventRender(info) {
        var $el = $(info.el);
        var $bgDiv = $el.find('.fc-bg');
        var $titleDiv = $el.find('.fc-title');

        var index = selectedEvents.indexOf(parseInt(info.event.id, 10));

        if (index == -1) {
            // TODO use the original value instead of hardcoding what the original value should be.
            $el.css('background-color', info.event.backgroundColor);
            $bgDiv.css('margin', 0);
            $bgDiv.css('opacity', 0.25);
            $titleDiv.css('font-weight', 'normal');
        } else {
            var color = tinycolor(info.event.backgroundColor);
            if (color.isLight()) {
                $el.css('background-color', color.darken(15));
            } else {
                $bgDiv.css('opacity', 0.15);
            }
            $bgDiv.css('margin', '1px');
            $titleDiv.css('font-weight', 'bold');
        }
    }

    $('.subscribe-button').on('click', e => {
        var subscribeType = $(e.currentTarget).data('subscribe-type');
        var urlWithoutProtocol = window.location.host + calendarUrl + '/' + hash;
        var url = '';
        switch (subscribeType) {
            case 'google':
                url = 'https://calendar.google.com/calendar/r?cid=http://' + urlWithoutProtocol;
                break;
            case 'outlook':
                url = 'https://outlook.live.com/owa/?path=/calendar/action/compose&rru=addsubscription&url=http://' + urlWithoutProtocol;
                break;
            case 'webcal':
                url = 'webcal://' + urlWithoutProtocol;
                break;
            default:
                console.log('Warning: Invalid subscribe type.')
        }
        var win = window.open(url, '_blank');
        win.focus();
    });

    $.getJSON(eventsUrl)
        .done(function (events) {
            $('#loadingSpinner').remove();
            $('#calendarContainer').show();

            var locations = _.chain(events).map(e => e.eventLocation.location).uniq(l => l.id).value();

            var tracks = _.chain(events).map(e => _(e.scheduleTracks).pluck('schedule')).flatten().uniq(s => s.id).sortBy(t => t.name).value();
            var panelTrack = _(tracks).find(t => t.name == "Panel");
            if (panelTrack) {
                // Since we have the panel track, remove any tracks for which all events overlap
                var getEventsForTrack = track => _(events).filter(e => _.chain(e.scheduleTracks).pluck('schedule').pluck('id').contains(track.id).value());
                var panelEvents = getEventsForTrack(panelTrack);
                tracks = _.chain(tracks).without(panelTrack).filter(track => _.chain(getEventsForTrack(track)).difference(panelEvents).size().value() > 0).value();
                tracks.unshift(panelTrack);
            }

            if (tracks) {
                $('#trackContainer').show();
                var trackButtonTemplate = $('#trackContainer .track-button');
                tracks.forEach(track => {
                    var newTrackButton = trackButtonTemplate.clone();
                    newTrackButton.show();
                    newTrackButton.find('span').text(track.name);
                    if (!panelTrack || track == panelTrack) {
                        newTrackButton.addClass('active');
                    }
                    var color = track.hexValue || "#3a87ad"; // Matches default for FullCalendar, should probably be more clever about this
                    newTrackButton.data('track', track);
                    newTrackButton.css('cursor', 'pointer');
                    newTrackButton.css('border-color', track.hexValue);
                    newTrackButton.css('color', newTrackButton.hasClass('active') ? 'white' : color);
                    newTrackButton.css('background-color', newTrackButton.hasClass('active') ? color : 'white');
                    newTrackButton.appendTo(trackButtonTemplate.parent());
                });
            }

            var allEvents = _(events).map(e =>
                _.extend(e, {
                    'title': e.name,
                    'resourceId': e.locations,
                    'start': e.startTime,
                    'end': e.endTime,
                    'color': e.scheduleTracks[0].schedule.hexValue,
                    'textColor': tinycolor(e.scheduleTracks[0].schedule.hexValue).isLight() ? "black" : "white"
                })
            );

            var selectedTracksEvents = () => {
                var selectedTrackIds = _.pluck($('.track-button.active').map((i, e) => $(e).data('track')).get(), 'id');
                return _(allEvents).filter(e => _.chain(e.scheduleTracks).pluck('schedule').pluck('id').intersection(selectedTrackIds).value().length > 0);
            }
            $('.track-button').on('click', e => {
                e.preventDefault();
                e.stopPropagation();
                var $button = $(e.currentTarget);
                $button.toggleClass('active');
                // TODO combine coloring with the initial render code
                var color = $button.data('track').hexValue || "#3a87ad"; // Matches default for FullCalendar, should probably be more clever about this
                $button.css('color', $button.hasClass('active') ? 'white' : color);
                $button.css('background-color', $button.hasClass('active') ? color : 'white');
                calendar.refetchEvents();
            });

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

                eventSources: [(info, successCallback) => successCallback(selectedTracksEvents())],

                eventRender: function (info) {
                    $(info.el).on('contextmenu', e => {
                        e.preventDefault();
                        console.log('Event title: ' + info.event.title);
                        console.log('Event description: ' + info.event.extendedProps.description);
                        $eventSummaryModal = $("#eventSummaryModal");
                        $eventSummaryModal.find("#eventTitle").text(info.event.title);
                        $eventSummaryModal.find("#eventTime").text(info.event.start.toLocaleTimeString('en-us', { hour: '2-digit', minute: '2-digit' }) + " - " + info.event.end.toLocaleTimeString('en-us', { hour: '2-digit', minute: '2-digit' }));
                        $eventSummaryModal.find("#eventLocation").text(info.event.extendedProps.eventLocation.location.name);
                        $eventSummaryModal.find("#eventDescription").html(info.event.extendedProps.description);
                        $eventSummaryModal.modal('show');
                    });

                    // TODO this gets fired for every event we render. Can we only do it once per re-render?
                    $(calendarElement).css('min-width', 50 + (80 * $(calendarElement).find('th').length) + 'px');

                    eventRender(info);
                },

                eventClick: function (info) {
                    var id = parseInt(info.event.id, 10);
                    var index = selectedEvents.indexOf(id);
                    if (index != -1) {
                        selectedEvents.splice(index, 1);
                    } else {
                        selectedEvents.push(id);
                    }

                    eventRender(info);

                    onSelectedEventsChanged();
                },
            });

            calendar.render();
        });
});
