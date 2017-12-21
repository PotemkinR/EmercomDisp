$(document).ready(function () {
    $("#datetimepicker").datetimepicker(
        {
            format: "DD.MM.YYYY HH:mm:ss",
            defaultDate: moment($("#datetimepicker").val(), "DD.MM.YYYY HH:mm:ss")
        });
    $("#datetimepicker1").datetimepicker(
        {
            format: "DD.MM.YYYY HH:mm:ss",
            defaultDate: moment($("#datetimepicker1").val(), "DD.MM.YYYY HH:mm:ss")
        });
        $("#datetimepicker2").datetimepicker(
            {
                format: "DD.MM.YYYY HH:mm:ss",
            });
    $("#datetimepicker3").datetimepicker(
        {
            format: "DD.MM.YYYY HH:mm:ss",
        });
    $("#datetimepicker4").datetimepicker(
        {
            format: "DD.MM.YYYY HH:mm:ss",
        });
});