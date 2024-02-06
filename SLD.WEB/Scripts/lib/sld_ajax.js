if (typeof (sld) === "undefined") {
    sld = {};
}
if (sld.ajax === undefined) {
    sld.ajax = {};
}
sld.ajax.Metodo = function (actionName, controllerName, dto, successMethod, errorMethod) {
    var url;
    url = "/" + controllerName + "/" + actionName,
    $.ajax({
        type: "POST",
        url: url,
        //contentType: "application/json; charset=utf-8",
        data: dto,
        dataType: "json",
        success: function (data, status) {
            if (data.hasOwnProperty("d")) {
                successMethod(data.d, status);
            }
            else {
                successMethod(data, status);
            }
        },
        error: function (response, settings) {
            if (errorMethod !== undefined) {
                errorMethod(response, settings);
            }
            else {
                if (response.responseText !== undefined) {
                    alert(response.responseText);
                }
            }
        }
    });
}

if (sld.validation === undefined) {
    sld.validation = {};
}
sld.validation.correoValido = function (val) {
    var correo = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return correo.test(val);
};
sld.validation.numeroValido = function (val) {
    var numbers = /^\d+$/;
    return numbers.test(val);
}

var ajax = sld.ajax;
var validacion = sld.validation;