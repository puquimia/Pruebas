

//#region VARIABLES
var jtxbCliente = $("");
var jtbodyProductos = $("");
var jtmpProductos = null;

var lDetalleVenta = [];
var jtbodyDetalleVenta = $("");
var jtmpDetalleVenta = null;
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
    jtbodyProductos.delegate("a.btn", "click", tbodyProductos_click);

    $("#btnBuscarProducto").click(btnBuscarProducto_click);

    jtbodyDetalleVenta = $("#tbodyDetalleVenta");
    jtmpDetalleVenta = $.templates("#tmpDetalleVenta");
    jtbodyDetalleVenta.delegate("a.btn", "click", tbodyDetalleVenta_click);
});
//#endregion

//#region EVENTOS
function btnAgregarProductos_click(evt) {
    $("#txbCodigoNombreProducto").val("");
    $("#txbCodigoNombreProducto").focus();
    jtbodyProductos.html("");
    $("#divProductos").modal();
}
function btnGuardar_click(evt) {
    Guardar();
}

function btnBuscarProducto_click(evt) {
    TraerProductos();
}
function tbodyProductos_click(evt) {
    var jcmd = $(evt.currentTarget);
    AgregarProductoLista(jcmd.closest("tr"));
}

function tbodyProducto_click(evt) {
    var jcmd = $(evt.currentTarget);
}
function tbodyDetalleVenta_click(evt) {
    var jcmd = $(evt.currentTarget);
    QuitarProducto(jcmd.closest("tr"));
}

//#endregion

//#region MÉTODOS
function TraerProductos() {
    var dto = {
        nombreCodigo: $.trim($("#txbCodigoNombreProducto").val())
    }
    ajax.Metodo("TraerProductos", "Ventas", dto, function (data, status) {
        jtbodyProductos.html(jtmpProductos.render(data));
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

function AgregarProductoLista(jtr) {
    lDetalleVenta.push({
        IdProduccto: jtr.data("id"),
        Codigo: jtr.data("codigo"),
        Nombre: jtr.data("nombre"),
        Precio: jtr.data("precio"),
        Subtotal: 0
    });
}

function QuitarProducto(jtr) {
    var index = jtr.index();
    lDetalleVenta.splice(index, 1);
}

function CargarProductoLista() {
    jtbodyDetalleVenta.html(jtmpDetalleVenta.render(lDetalleVenta));
}
//#endregion