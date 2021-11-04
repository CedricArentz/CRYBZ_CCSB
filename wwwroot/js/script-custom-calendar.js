// const { get } = require("jquery");

var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#Date").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    });
    InitializeCalendar();
});
var calendar;
function InitializeCalendar() {
    try {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            calendar = new FullCalendar.Calendar(calendarEl, {
                locale: 'nl',
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                weekNumbers: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                },
                eventDisplay: 'block',
                events: function (fetchInfo, successCallback, failureCallback) {
                    $.ajax({
                        url: routeURL + '/API/AppointmentApi/GetCalendarDataById?licenseplate=70-ght-14',/* + $("#employeeId").val(),*/
                        type: 'GET',
                        dataType: 'json',
                        success: function (response) {
                            var events = [];
                            if (response.status === 1) {
                                $.each(response.dataenum, function (i, data) {
                                    events.push({
                                        LicensePlate: data.LicensePlate,
                                        Date: data.Date,
                                        Action: data.Action,
                                        backgroundColor: data.isEmployeeApproved ? "#28a745" : "#dc3545",
                                        textColor: "white",
                                    });
                                })
                            }
                            successCallback(events);
                        },
                        error: function (xhr) {
                            $.notify("Error", "error");
                        }
                    });
                },
                eventClick: function (info) {
                    getEventDetailsByEventId(info.event);
                }
            });
            calendar.render();
        }
    }
    catch (e) {
        alert(e);
    }
}
function onShowModal(obj, isEventDetail) {
    if (isEventDetail) {
        $("#LicensePlate").val(obj.LicensePlate);
        //$("#Date").val(obj.Date);
        $("#Action").val(obj.Action);
    }
    else {
        var appointmentdate = obj.start.getYear + "-" + obj.start.getMonth() + "-" + obj.start.getDay() + " " + new moment().format("HH:mm:ss");
        $("#LicensePlate").val(0);
        //$("#Date").val(Date);
        $("#Action").val("");
    }
    $("#appointmentInput").modal("show");
}
function onCloseModal() {
    $("#appointmentInput").modal("hide");
}
function onSubmitForm() {
    if (!checkValidation()) return;
    var requestData = {
        LicensePlate: $("#LicensePlate").val(),
        Date: $("#Date").val(),
        Action: $("#Action").val()
    };

    $.ajax({
        url: routeURL + "/API/AppointmentApi/SaveCalendarData",
        type: "POST",
        data: JSON.stringify(requestData),
        contentType: "application/json",
        success: function (response) {
            console.log("1");
            if (response.status === 1 || response.status === 2) {
                $.notify(response.message, "succes");
                onCloseModal();
            } else {
                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "Fout");
        }
    });
}
function checkValidation() {
    var isValid = true;
    
    if ($("#Date").val() === undefined || $("#Date").val().trim() === "" ) {
        isValid = false;
        $("#Date").addClass("error");
    } else {
        $("#Date").removeClass("error");
    }
    return isValid;
}

function getEventDetailsByEventId(info) {
    $.ajax({
        url: routeURL + '/api/AppointmentApi/GetCalendarDataById' + info.id,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status === 1 && response.dataenum != undefined) {
                onShowModal(respone.dataenum, true);
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}

function onEmployeeChange() {
    calendar.refetchEvents();
}