$(document).ready(function () {
    LoadBrands();

    $('#brand').change(function () {
        var brandId = $(this).val();
        if (brandId > 0) {
            LoadModels(brandId);
        }
        else {
            alert("Select Brand");
            $('#model').empty();
            $('#color').empty();
            $('#model').attr('disabled', true);
            $('#color').attr('disabled', true);
            $('#model').append('<option>--Select Model--</option>');
            $('#color').append('<option>--Select Color--</option>');
        }
    });

    $('#model').change(function () {
        var modelId = $(this).val();
        if (modelId > 0) {
            LoadColors(modelId);
        }
        else {
            alert("Select Model");
            $('#color').empty();
            $('#color').attr('disabled', true);
            $('#color').append('<option>--Select Color--</option>');
        }
    });
});


function LoadBrands() {
    $('#brand').empty();

    $.ajax({
        url: '/CascadeList/GetBrands',
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#brand').attr('disabled', false);
                $('#brand').append('<option>--Select Brand--</option>');
                $('#model').append('<option>--Select Model--</option>');
                $('#color').append('<option>--Select Color--</option>');
                $.each(response, function (i, data) {
                    $('#brand').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#brand').attr('disabled', true);
                $('#model').attr('disabled', true);
                $('#color').attr('disabled', true);
                $('#brand').append('<option>--Brands not available--</option>');
                $('#model').append('<option>--Models not available--</option>');
                $('#color').append('<option>--Colors not available--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

function LoadModels(brandId) {
    $('#model').empty();
    $('#color').empty();
    $('#color').attr('disabled', true);


    $.ajax({
        url: '/CascadeList/GetModels?Id=' + brandId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#model').attr('disabled', false);
                $('#model').append('<option>--Select Model--</option>');
                $('#color').append('<option>--Select Color--</option>');
                $.each(response, function (i, data) {
                    $('#model').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#model').attr('disabled', true);
                $('#color').attr('disabled', true);
                $('#model').append('<option>--Models not available--</option>');
                $('#color').append('<option>--Colors not available--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

function LoadColors(modelId) {
    $('#color').empty();

    $.ajax({
        url: '/CascadeList/GetColors?Id=' + modelId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#color').attr('disabled', false);
                $('#color').append('<option>--Select Color--</option>');
                $.each(response, function (i, data) {
                    $('#color').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#brand').attr('disabled', true);
                $('#model').attr('disabled', true);
                $('#color').attr('disabled', true);
                $('#brand').append('<option>--Brands not available--</option>');
                $('#model').append('<option>--Models not available--</option>');
                $('#color').append('<option>--Colors not available--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}