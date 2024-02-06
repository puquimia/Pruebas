

//#region VARIABLES
var jtxbCliente = $("");
var jtbodyProductos = $("");
var jtmpProductos = null;
//#endregion

//#region CARGA INICIAL
$(function () {
    jtxbCliente = $("#txbCliente");
    jtxbCliente.focus();
    jtxbCliente.autocomplete({
        minLength: 3,
        source: function (request, response) {
            var dto = {
                filtro: request.term
            };
            sld.ajax.Metodo("TraerClientes", "Ventas", dto, function (data, status) {
                response(data);
            });
        },
        focus: function (event, ui) {
            return false;
        },
        select: function (event, ui) {
            var jtxb = $(this);
            jtxb.attr("value", '' + ui.item.value);
            jtxb.val(ui.item.label).attr("etiqueta", ui.item.label);
            return false;
        }
    });
    jtxbCliente.keyup(function () {
        var jtxb = $(this);
        if (jtxb.attr("value") && jtxb.val() !== jtxb.attr("etiqueta")) {
            jtxb.attr("value", null);
            jtxb.attr("etiqueta", null);
        }
    });
    $("#btnGuardar").click(btnGuardar_click);

    $("#btnAgregarProductos").click(btnAgregarProductos_click);
    jtbodyProductos = $("#tbodyProductos");
    jtmpProductos = $.templates("#tmpProductos");
});
//#endregion

//#region EVENTOS
function btnAgregarProductos_click(evt) {
    TraerProductos();
}
function btnGuardar_click(evt) {
    Guardar();
}
//#endregion

//#region MÉTODOS
function TraerProductos() {
    ajax.Metodo("TraerProductos", "Ventas", dto, function (data, status) {
        jtbodyProductos.html(jtmpProductos.render(data));
        $("#divProductos").modal();
    });
}
function Guardar() {
    var mensajes = [];
    
    if (mensajes.length > 0) {
        Swal.fire({
            icon: "error",
            title: "Mensaje",
            html: mensajes.join("<br/>"),
        });
        return;
    }
    var dto = {
        
    };
    ajax.Metodo("Guardar", "Ventas", dto, function (data, status) {
        Swal.fire({
            icon: "success",
            title: "Mensaje",
            html: "Se regisro la venta correctamente.",
        }).then((result) => {
            if (result.isConfirmed) {
                location.href = "/Ventas";
            }
        });
    });
}
//#endregion