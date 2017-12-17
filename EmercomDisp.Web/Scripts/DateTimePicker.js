$(document).ready(function () {
    $("#datetimepicker").datetimepicker(
        {
            format: "DD.MM.YYYY hh:mm:ss",
            defaultDate: moment($("#datetimepicker").val(), "DD.MM.YYYY hh:mm:ss")
        });
    $("#datetimepicker1").datetimepicker(
        {
            format: "DD.MM.YYYY hh:mm:ss",
            defaultDate: moment($("#datetimepicker1").val(), "DD.MM.YYYY hh:mm:ss")
        });
    $("#datetimepicker2").datetimepicker(
        {
            format: "DD.MM.YYYY hh:mm:ss",
            defaultDate: moment($("#datetimepicker2").val(), "DD.MM.YYYY hh:mm:ss")
        });
    $("#datetimepicker3").datetimepicker(
        {
            format: "DD.MM.YYYY hh:mm:ss",
            defaultDate: moment($("#datetimepicker3").val(), "DD.MM.YYYY hh:mm:ss")
        });
    $("#datetimepicker4").datetimepicker(
        {
            format: "DD.MM.YYYY hh:mm:ss",
            defaultDate: moment($("#datetimepicker4").val(), "DD.MM.YYYY hh:mm:ss")
        });
});