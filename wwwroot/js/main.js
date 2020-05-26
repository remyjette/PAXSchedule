import { Calendar } from 'https://unpkg.com/@fullcalendar/core@4.3.1?module';
import resourceTimeGrid from 'https://unpkg.com/@fullcalendar/resource-timegrid@4.3.0?module';
import { LocalDateTime } from 'https://unpkg.com/@js-joda/core@2.0.0?module';
import Hashids from 'https://unpkg.com/hashids@2.2.1?module';
import _ from 'https://unpkg.com/underscore@1.10.2?module';
import 'https://unpkg.com/tinycolor2@1.4.1/tinycolor.js'; // This isn't an ES module

$(function () { // document ready
    $("#calendarUrl input").on('click', function () {
        $(this).select();
    });
    $("#calendarUrl .copy-button")
        .on('click', function () {
            // Create an element we can copy text to to use document.execCommand('copy')
            // This can be replaced when the Clipboard API has better support.
            // The element is created right next to the button to avoid moving the window,
            // but this probably needs more work.
            var input = $('<input>').appendTo($(this).parent());
            input.val($(this).data('url'));
            input.focus();
            input.select();
            document.execCommand('copy');
            input.remove()
            setTimeout(() => $(this).tooltip('hide'), 1000);
            return false; // Don't navigate to '#'
        })
        .tooltip({ trigger: "click" });

    var hashids = new Hashids();

    var selectedEvents;
    if (location.pathname !== viewShowUrl) {
        var initialUrl = location.pathname;
        var initialHash = initialUrl.replace(viewShowUrl + "/", "");
        selectedEvents = hashids.decode(initialHash);
    } else {
        selectedEvents = [];
    }

    // This function should be called every time selectedEvents is modified.
    // TODO: Use Proxy to do this automatically
    var hash = ''; // Global so it can be accessed by download/subscribe buttons
    function onSelectedEventsChanged() {
        hash = hashids.encode(...selectedEvents);
        window.history.replaceState({ hashids: hash }, "" /* title */, viewShowUrl + "/" + hash);
        $("#calendarUrl .copy-button").data('url', window.location.origin + calendarUrl + "/" + hash);
        $('.download-button').attr('href', window.location.origin + calendarUrl + "/" + hash);
    }
    onSelectedEventsChanged();

    // Define the eventRender function globally instead of inline so we can call it directly from the eventClick event.
    // While we could just use calendar.render(), that introduces latency - just re-applying the render effect on the
    // specific event has much better performance.
    function eventRender(info) {
        var $el = $(info.el);
        var $bgDiv = $el.find('.fc-bg');
        var $titleDiv = $el.find('.fc-title');

        // Prevent selecting the event title text to improve hold-tap for description on mobile.
        $el.addClass('noselect');

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
            var panelTrack = _(tracks).find(t => t.name == "Panel"); // TODO (#11) don't hardcode 'Panel'
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

            var allEvents = _(events).map(e => {
                var color = e.scheduleTracks.length == 1 ? e.scheduleTracks[0].schedule.hexValue : _.find(e.scheduleTracks, st => st.schedule.name != "Panel").schedule.hexValue; // TODO (#11) don't hardcode 'Panel'
                return _.extend(e, {
                    'title': e.name,
                    'resourceId': e.locations,
                    'start': e.startTime,
                    'end': e.endTime,
                    'color': color,
                    'textColor': tinycolor(color).isLight() ? "black" : "white"
                })
            });

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
                LocalDateTime.parse(dateString.replace(' ', 'T')).toLocalTime()
            )
                .min(x => x.toSecondOfDay())
                .value()
                .toString();
            var maxTime = _.chain(events).pluck('endTime').map(dateString =>
                LocalDateTime.parse(dateString.replace(' ', 'T')).toLocalTime()
            )
                .max(x => x.toSecondOfDay())
                .value()
                .toString();

            var calendarElement = document.getElementById('calendar');
            var calendar = new Calendar(calendarElement, {
                plugins: [ resourceTimeGrid ],
                schedulerLicenseKey: "CC-Attribution-NonCommercial-NoDerivatives",
                defaultView: 'resourceTimeGridDay',
                height: 'auto',
                validRange: {
                    start: _.chain(events).pluck('startTime').map(dateString => new Date(dateString)).min().value(),
                    end: _.chain(events).pluck('endTime').map(dateString => new Date(dateString)).max().value()
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
                        var $eventSummaryModal = $("#eventSummaryModal");
                        $eventSummaryModal.find("#eventTitle").text(info.event.title);
                        $eventSummaryModal.find("#eventTime").text(info.event.start.toLocaleTimeString('en-us', { hour: '2-digit', minute: '2-digit' }) + " - " + info.event.end.toLocaleTimeString('en-us', { hour: '2-digit', minute: '2-digit' }));
                        $eventSummaryModal.find("#eventLocation").text(info.event.extendedProps.eventLocation.location.name);
                        $eventSummaryModal.find("#eventDescription").html(info.event.extendedProps.plaintextDescription.replace(/\n/g, "<br />"));
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
