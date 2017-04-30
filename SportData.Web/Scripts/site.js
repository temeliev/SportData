//var item_to_delete, item_to_delete_name, item_to_delete_second, item_to_delete_name_second, action_name, controller_name;

//$(".deleteItem").click(function (e) {
//    action_name = $(this).attr("action-name");
//    controller_name = $(this).attr("controller-name");
//    item_to_delete = $(this).attr("data-first-id");
//    item_to_delete_name = $(this).attr("data-first-name");
//    item_to_delete_second = $(this).attr("data-second-id");
//    item_to_delete_name_second = $(this).attr("data-second-name");
//});

//$('#btnContinueDelete').click(function () {
//    var path = "/" + controller_name + "/" + action_name + "?" + item_to_delete_name + "=" + item_to_delete;
//    if (typeof item_to_delete_second !== 'undefined') {
//        path += "&" + item_to_delete_name_second + "=" + item_to_delete_second;
//    }
//    window.location = path;
//});

//$(document).ready(function () {

//    $('.ui-datepicker').datepicker({
//        format: "dd/mm/yyyy"
//    });

//});

$(document).ready(function () {
    $('.ui-datepicker').datepicker({ dateFormat: '<%= Html.ConvertDateFormat() %>' });
});

$(function () {
    $("#accordion").accordion({
        collapsible: true,
        heightStyle: "content"
    });
});

$(function () {
    $("#tabs").tabs();
});

$(function () {
    $("#tabs").tabs({
        beforeLoad: function (event, ui) {
            ui.jqXHR.fail(function () {
                ui.panel.html(
                  "Couldn't load this tab. We'll try to fix this as soon as possible. " +
                  "If this wouldn't be a demo.");
            });
        }
    });
});

$('#dateDropdown').change(function () {

    /* Get the selected value of dropdownlist */
    var selectedVal = $(this).val();

    var currentTabId = $("#tabs .ui-state-active a").attr("id");
    var link = '/FootballMatches/FootballMatches?date=';
    switch (currentTabId) {
        case "all":
            link += selectedVal + "&status=" + "Default";
            break;
        case "upcoming":
            link += selectedVal + "&status=" + "NotStarted";
            break;
        case "finished":
            link += selectedVal + "&status=" + "Finished";
            break;
        default:
            break;
    }

    /* Request the partial view with .get request. */
    $.get(link, function (data) {
        var tabId = "#tabs-" + currentTabId;
        
        /* data is the pure html returned from action method, load it to your page */
        $(tabId).html(data);
        /* little fade in effect */
        $(tabId).fadeIn('fast');

        $("#all").attr("href", "/FootballMatches/FootballMatches?date=" + selectedVal + "&status=" + "Default");
        $("#upcoming").attr("href", "/FootballMatches/FootballMatches?date=" + selectedVal + "&status=" + "NotStarted");
        $("#finished").attr("href", "/FootballMatches/FootballMatches?date=" + selectedVal + "&status=" + "Finished");

    });

});

$(function () {
    $("#tab-container").tabs();
});

$(function () {
    $("#ranking-type-tabs").tabs();
});

$(function () {
    $("#tab-container").tabs({
        beforeLoad: function (event, ui) {
            ui.jqXHR.fail(function () {
                ui.panel.html(
                  "Couldn't load this tab. We'll try to fix this as soon as possible. " +
                  "If this wouldn't be a demo.");
            });
        }
    });
});

$(function () {
    $("#ranking-type-tabs").tabs({
        beforeLoad: function (event, ui) {
            ui.jqXHR.fail(function () {
                ui.panel.html(
                  "Couldn't load this tab. We'll try to fix this as soon as possible. " +
                  "If this wouldn't be a demo.");
            });
        }
    });
});