$(document).ready(function () {
    $('.brands').attr('disabled', true);
    $('.models').attr('disabled', true);
    $('.colors').attr('disabled', true);

    DefineTableFieldsById();
    LoadBrands();
    LoadModels();
    LoadColors();

    $('.brands').each(function () {
        $(this).on('change', (function () {
            var id = this.id;
            var value = this.value;
            var model = $('#' + id + ".models")[0];
            $('#' + id + ".models").empty();
            $.ajax({
                url: '/CascadeList/GetModels?Id=' + value,
                success: function (response) {
                    if (response != null && response != undefined && response.length > 0) {
                        $.each(response, function (i, data) {
                            var option = document.createElement("option");
                            option.value = data.id;
                            option.innerHTML = data.name;
                            model.appendChild(option);
                        });
                        $('#' + id + ".models").change();

                    }
                },
            });
        }));
    });

    $('.models').each(function () {
        $(this).on('change', (function () {
            var id = this.id;
            var value = this.value;
            var color = $('#' + id + ".colors")[0];
            $('#' + id + ".colors").empty();
            $.ajax({
                url: '/CascadeList/GetColors?Id=' + value,
                success: function (response) {
                    if (response != null && response != undefined && response.length > 0) {
                        $.each(response, function (i, data) {
                            var option = document.createElement("option");
                            option.value = data.id;
                            option.innerHTML = data.name;
                            color.appendChild(option);
                        });

                    }
                },
            });
        }));
    });


    $('.update').each(function () {
        $(this).on('click', (function () {
            $("[id=" + this.id + "]").each(function (i) {
                $(this).attr('disabled', false);
            });
            
            this.style.display = 'none';
            $('#' + this.id + '.delete')[0].style.display = "none";
            $('#' + this.id + '.save')[0].style.display = "";
            $('#' + this.id + '.cancel')[0].style.display = "";
        }));
    });

    $('.cancel').each(function () {
        $(this).on('click', (function () {
            $("[id=" + this.id + "]").each(function (i) {
                $(this).attr('disabled', true);
            });
            
            $('#' + this.id + '.update')[0].disabled = false;
            $('#' + this.id + '.delete')[0].disabled = false;

            this.style.display = 'none';
            $('#' + this.id + '.save')[0].style.display = "none";
            $('#' + this.id + '.update')[0].style.display = "";
            $('#' + this.id + '.delete')[0].style.display = "";
        }));
    });  
});

function DefineTableFieldsById() {
    //selects
    $(".brands").each(function (i) {
        $(this).attr("id", i);
    });
    $(".models").each(function (i) {
        $(this).attr("id", i);
    });
    $(".colors").each(function (i) {
        $(this).attr("id", i);
    });
    //buttons
    $(".update").each(function (i) {
        $(this).attr("id", i);
    });
    $(".save").each(function (i) {
        $(this).attr("id", i);
    });
    $(".delete").each(function (i) {
        $(this).attr("id", i);
    });
    $(".cancel").each(function (i) {
        $(this).attr("id", i);
    });

    $(".id").each(function (i) {
        $(this).attr("id", i);
    });
}


function EnableEdit(update) {

}

function LoadBrands() {
    var brands = $('.brands');
    for (let index = 0; index < brands.length; index++) {
        $.ajax({
            url: '/CascadeList/GetBrands',
            success: function (response) {
                if (response != null && response != undefined && response.length > 0) {
                    var valueToSelect = brands[index].lastChild.value;
                    brands[index].removeChild(brands[index].lastChild);
                    $.each(response, function (i, data) {
                        var option = document.createElement("option");
                        option.value = data.id;
                        option.innerHTML = data.name;
                        brands[index].appendChild(option);
                        if (data.id == valueToSelect) {
                            brands[index].value = data.id;
                        }
                    });
                }
                else {
                    $('.brands').attr('disabled', true);
                    $('.models').attr('disabled', true);
                    $('.colors').attr('disabled', true);
                    $('.brands').append('<option>--Brands not available--</option>');
                    $('.models').append('<option>--Models not available--</option>');
                    $('.colors').append('<option>--Colors not available--</option>');
                }
            },
            error: function (error) {
                alert(error);
            }
        });
    }

}

function LoadModels() {

    var brands = $('.brands');
    var models = $('.models');

    for (let index = 0; index < brands.length; index++) {
        $.ajax({
            url: '/CascadeList/GetModels?Id=' + brands[index].value,
            success: function (response) {
                var valueToSelect = models[index].lastChild.value;

                models[index].removeChild(models[index].lastChild);
                if (response != null && response != undefined && response.length > 0) {
                    $.each(response, function (i, data) {
                        var option = document.createElement("option");
                        option.value = data.id;
                        option.innerHTML = data.name;
                        models[index].appendChild(option);
                        if (data.id == valueToSelect) {
                            models[index].value = data.id;
                        }
                    });

                }
                else {
                    $('.models').attr('disabled', true);
                    $('.colors').attr('disabled', true);
                    $('.models').append('<option>--Models not available--</option>');
                    $('.colors').append('<option>--Colors not available--</option>');
                }
            },
            error: function (error) {
                alert(error);
            }
        });
    }

}

function LoadColors() {

    var models = $('.models');
    var colors = $('.colors');

    for (let index = 0; index < models.length; index++) {
        $.ajax({
            url: '/CascadeList/GetColors?Id=' + models[index].value,
            success: function (response) {
                if (response != null && response != undefined && response.length > 0) {
                    var valueToSelect = colors[index].lastChild.value;
                    colors[index].removeChild(colors[index].lastChild);
                    $.each(response, function (i, data) {
                        var option = document.createElement("option");
                        option.value = data.id;
                        option.innerHTML = data.name;
                        colors[index].appendChild(option);
                        if (data.id == valueToSelect) {
                            colors[index].value = data.id;
                        }
                    });
                }
                else {
                    $('.colors').attr('disabled', true);
                    $('.colors').append('<option>--Colors not available--</option>');
                }
            },
            error: function (error) {
                alert(error);
            }
        });
    }

}