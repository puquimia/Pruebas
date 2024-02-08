

//#region VARIABLES
var idCliente = -1;
var jtxbCodigo = $("");
var jtxbNombre = $("");
var jddlTipoDocumento = $("");
var jtxbDocumento = $("");
var jtxbEmail = $("");
//#endregion

//#region CARGA INICIAL
$(function () {
    jtxbCodigo = $("#txbCodigo");
    jtxbNombre = $("#txbNombre");
    jddlTipoDocumento = $("#ddlTipoDocumento");
    jtxbDocumento = $("#txbDocumento");
    jtxbEmail = $("#txbEmail");

    jtxbCodigo.focus();
    $("#btnGuardar").click(btnGuardar_click);
});
//#endregion

//#region EVENTOS
function btnGuardar_click(evt) {
    Guardar();
}
//#endregion

//#region MÉTODOS
function Guardar() {
    var mensajes = [];
    if (!$.trim(jtxbCodigo.val())) {
        mensajes.push(" - Debe especificar un código.");
    }
    if (!$.trim(jtxbNombre.val())) {
        mensajes.push(" - Debe especificar un nombre.");
    }
    if (!jddlTipoDocumento.val()) {
        mensajes.push(" - Debe especificar un tipo de documento.");
    }
    if (!$.trim(jtxbDocumento.val())) {
        mensajes.push(" - Debe especificar un documento.");
    }
    else if (!sld.validation.numeroValido($.trim(jtxbDocumento.val()))) {
        mensajes.push(" - Debe especificar un documento válido.");
    }
    if (!$.trim(jtxbEmail.val())) {
        mensajes.push(" - Debe especificar un e-mail.");
    }
    else if (!sld.validation.correoValido($.trim(jtxbEmail.val()))) {
        mensajes.push(" - Debe especificar un e-mail válido.");
    }
    if (mensajes.length > 0) {
        Swal.fire({
            icon: "error",
            title: "Nuevo cliente",
            html: mensajes.join("<br/>"),
            showClass: {
                popup: `
                    animate__animated
                    animate__fadeInUp
                    animate__faster`
            },
            hideClass: {
                popup: `
                    animate__animated
                    animate__fadeOutDown
                    animate__faster`
            }
        });
        return;
    }
    var dto = {
        Codigo: jtxbCodigo.val(),
        Nombre: jtxbNombre.val(),
        TipoDocumento: jddlTipoDocumento.val(),
        Documento: jtxbDocumento.val(),
        Email: jtxbEmail.val()
    };
    ajax.Metodo("Guardar","Clientes", dto, function (data, status) {
        Swal.fire({
            icon: "success",
            title: "Nuevo cliente",
            html: "Se registró el cliente correctamente.",
            showClass: {
                popup: `
                    animate__animated
                    animate__fadeInUp
                    animate__faster`
            },
            hideClass: {
                popup: `
                    animate__animated
                    animate__fadeOutDown
                    animate__faster`
            }
        }).then((result) => {
            if (result.isConfirmed) {
                location.href = "/Clientes";
            }
        });
    });
}
//#endregion