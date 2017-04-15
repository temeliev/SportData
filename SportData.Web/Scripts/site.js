var item_to_delete, item_to_delete_name, item_to_delete_second, item_to_delete_name_second, action_name, controller_name;

$(".deleteItem").click(function (e) {
    action_name = $(this).attr("action-name");
    controller_name = $(this).attr("controller-name");
    item_to_delete = $(this).attr("data-first-id");
    item_to_delete_name = $(this).attr("data-first-name");
    item_to_delete_second = $(this).attr("data-second-id");
    item_to_delete_name_second = $(this).attr("data-second-name");
});

$('#btnContinueDelete').click(function () {
    var path = "/" + controller_name + "/" + action_name + "?" + item_to_delete_name + "=" + item_to_delete;
    if (typeof item_to_delete_second !== 'undefined') {
        path += "&" + item_to_delete_name_second + "=" + item_to_delete_second;
    }
    window.location = path;
});

//$(document).ready(function () {

//    $('.ui-datepicker').datepicker({
//        format: "dd/mm/yyyy"
//    });

//});

$(document).ready(function () {
    $('.ui-datepicker').datepicker({ dateFormat: '<%= Html.ConvertDateFormat() %>' });
});

