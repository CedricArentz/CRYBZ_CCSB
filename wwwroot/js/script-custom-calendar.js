var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    });
    InitializeCalendar();
});
var calendar;
function InitializeCalendar() {
    /// <summary>
    /// Initializes the calendar.
    /// </summary>
    /// <returns></returns>
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
                weekends: true,
                weekNumbers: true,
                editable: false,
                businessHours: {
                    // days of week. an array of zero-based day of week integers (0=Sunday)
                    daysOfWeek: [1, 2, 3, 4, 5], // Monday - Friday

                    startTime: '09:00', // a start time (10am in this example)
                    endTime: '18:00', // an end time (6pm in this example)
                },
                select: function (event) {
                    onShowModal(event, null);
                },
                eventDisplay: 'block',
                events: "/AppointmentController/GetAppointments"
                //events: function (fetchInfo, succesCallback, failureCallback) {
                //    $.ajax({
                //        url: routeURL + '/api/AppointmentApi/GetCalendarData?employeeId=' + $("#employeeId").val(),
                //        type: 'GET',
                //        dataType: 'json',
                //        success: function (response) {
                //            var events = [];
                //            if (response.status === 1) {
                //                $.each(response.dataenum, function (i, data) {
                //                    events.push({
                //                        title: data.title,
                //                        description: data.description,
                //                        start: data.startDate,
                //                        end: data.endDate,
                //                        backgroundColor: data.isEmployeeApproved ? "#28a745" : "#dc3545",
                //                        textColor: "white",
                //                        id: data.id
                //                    });
                //                })
                //            }
                //            succesCallback(events);
                //        },
                //        error: function (xhr) {
                //            $.notify("Error", "error");
                //        }
                //    });
                //},
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
        $("#title").val(obj.title);
        $("#description").val(obj.description);
        $("#appointmentDate").val(obj.startDate);
        $("#duration").val(obj.duration);
        $("#employeeId").val(obj.employeeId);
        $("#customerId").val(obj.customerId);
        $("#id").val(obj.id);
        $("#lblEmployeeName").html(obj.employeeName);
        $("#lblCustomerName").html(obj.customerName);
        if (obj.isEmployeeApproved) {
            $("#lblStatus").html("Bevestigd");
            $("#btnConfirm").addClass("d-none");
            $("#btnSubmit").addClass("d-none");
        } else {
            $("#lblStatus").html("Niet bevestigd");
            $("#btnConfirm").removeClass("d-none");
            $("#btnSubmit").removeClass("d-none");
        }
        $("#btnDelete").removeClass("d-none");
    }
    else {
        var appointmentdate = obj.start.getDate() + "-" + (obj.start.getMonth() + 1) + "-" +
            obj.start.getFullYear() + " " + new moment().format("HH:mm");
        $("#id").val(0);
        $("#title").val("");
        $("#description").val("");
        $("#appointmentDate").val(appointmentdate);
        $("#btnDelete").addClass("d-none");
        $("#btnSubmit").removeClass("d-none");
    }
    $("#appointmentInput").modal("show");
}
function onCloseModal() {
    $("#appointmentInput").modal("hide");
}
function onSubmitForm() {
    if (!checkValidation()) return;
    var requestData = {
        Id: parseInt($("id").val()),
        Title: $("#title").val(),
        Description: $("#description").val(),
        StartDate: $("#appointmentDate").val(),
        Duration: $("#duration").val(),
        EmployeeId: $("#employeeId").val(),
        CustomerId: $("#customerId").val()
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
    if ($("#title").val() === undefined || $("#title").val().trim() === "" ){
        isValid = false;
        $("#title").addClass("error");
    } else {
        $("#title").removeClass("error");
    }
    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val().trim() === "" ) {
        isValid = false;
        $("#appointmentDate").addClass("error");
    } else {
        $("#appointmentDate").removeClass("error");
    }
    return isValid;
}
function getEventDetailsByEventId(info) {
    $.ajax({
        url: routeURL + '/api/AppointmentApi/GetCalendarDataById/' + info.id,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status === 1 && response.dataenum != undefined) {
                onShowModal(response.dataenum, true);
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    }
    );
}
function onDoctorChange() {
    /// <summary>
    /// Handles the doctor change.
    /// </summary>
    /// <returns></returns>
    calendar.refetchEvents();
}

function onDeleteAppointment() {
    /// <summary>
    /// Delete the appointment.
    /// </summary>
    /// <returns></returns>
    var id = parseInt($("#id").val());
    $.ajax({
        url: routeURL + '/api/AppointmentApi/DeleteAppointment/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status === 1) {
                $.notify(response.message, "Afspraak verwijderd");
                calendar.refetchEvents();
                onCloseModal();
            }
            else {
                $.notify(response.message, "Verwijderen mislukt");
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}

function onConfirmAppointment() {
    /// <summary>
    /// Confirms the appointment.
    /// </summary>
    /// <returns></returns>
    var id = parseInt($("#id").val());
    $.ajax({
        url: routeURL + '/api/AppointmentApi/ConfirmAppointment/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status === 1) {
                $.notify(response.message, "Afspraak bevestigd");
                calendar.refetchEvents();
                onCloseModal();
            }
            else {
                $.notify(response.message, "Bevestigen mislukt");
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}