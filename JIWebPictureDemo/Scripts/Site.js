// On Clicking Student Logo Image, then change the image
function ChangePicture() {
    $('#upload').click();
}

function ReadURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

$(function () {
    // Show Model Dialog Box
    $('#successErrorModel').modal('show');
});

function RedirectToEdit(s) {
    //location.href = '@Url.Action("Edit", "Home", new {id = '
}