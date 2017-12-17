$(document).ready(function () {
    $(".brigade").click(function () {
        $(this).nextUntil(".brigade").toggle();
    });
});