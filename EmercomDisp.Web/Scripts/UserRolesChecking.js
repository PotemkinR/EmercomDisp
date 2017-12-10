$(document).ready(function () {
    $("#admin").click(function () {
        if ($("#admin").is(':checked',false)) {
            $("#editor").prop('checked', true);
            $('#editor').prop('disabled', true);
        }
        else {
            $("#editor").prop('checked', false);
            $('#editor').removeAttr('disabled');         
        }
    });
});