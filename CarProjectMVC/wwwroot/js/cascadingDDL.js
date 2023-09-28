$(document).ready(function () {
    $('#brand').attr('disabled', true);
    $('#model').attr('disabled', true);
    $('#color').attr('disabled', true);
}

function LoadBrands() {
    $('#brand').empty();

    $.ajax({
        url: '/Create/GetBrands',
        success: function (response) {
            if(response)
        },
        error: function (error) {
            alert(error);
        }

    });
}