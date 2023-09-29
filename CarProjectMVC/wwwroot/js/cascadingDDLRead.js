$(document).ready(function () {
    $('[id=brand]').attr('disabled', true);
    $('[id=model]').attr('disabled', true);
    $('[id=color]').attr('disabled', true);
    LoadBrands();
    LoadModels();
    LoadColors();
});



function LoadBrands() {
    var brands = $('[id=brand]');
    for (let index = 0; index < brands.length; index++) {
        $.ajax({
            url: '/Create/GetBrands',
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
                    $('[id=brand]').attr('disabled', true);
                    $('[id=model]').attr('disabled', true);
                    $('[id=color]').attr('disabled', true);
                    $('[id=brand]').append('<option>--Brands not available--</option>');
                    $('[id=model]').append('<option>--Models not available--</option>');
                    $('[id=color]').append('<option>--Colors not available--</option>');
                }
            },
            error: function (error) {
                alert(error);
            }
        });
    }

}

function LoadModels() {

    var brands = $('[id=brand]');
    var models = $('[id=model]');
    console.log(models);

    for (let index = 0; index < brands.length; index++) {
        $.ajax({
            url: '/Create/GetModels?Id=' + brands[index].value,
            success: function (response) {
                var valueToSelect = models[index].lastChild.value;
  
                console.log("valueToSelect = " + valueToSelect);
                models[index].removeChild(models[index].lastChild);
                if (response != null && response != undefined && response.length > 0) {
                    $.each(response, function (i, data) {
                        var option = document.createElement("option");
                        option.value = data.id;
                        option.innerHTML = data.name;
                        models[index].appendChild(option); 
                        console.log("data.id = " + data.id);
                        if (data.id == valueToSelect) {
                            models[index].value = data.id;
                            console.log(models[index].value);
                        }
                    });
                    
                }
                else {
                    $('[id=model]').attr('disabled', true);
                    $('[id=color]').attr('disabled', true);
                    $('[id=model]').append('<option>--Models not available--</option>');
                    $('[id=color]').append('<option>--Colors not available--</option>');
                }
            },
            error: function (error) {
                alert(error);
            }
        });
    }

}

function LoadColors() {

    var models = $('[id=model]');
    var colors = $('[id=color]');

    for (let index = 0; index < models.length; index++) {
        $.ajax({
            url: '/Create/GetColors?Id=' + models[index].value,
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
                    $('[id=color]').attr('disabled', true);
                    $('[id=color]').append('<option>--Colors not available--</option>');
                }
            },
            error: function (error) {
                alert(error);
            }
        });
    }

}