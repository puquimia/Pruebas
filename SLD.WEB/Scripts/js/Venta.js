

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
            jtxb.data("value", '' + ui.item.value);
            jtxb.val(ui.item.label).data("etiqueta", ui.item.label);
            return false;
        }
    });
    jtxbCliente.keyup(function () {
        var jtxb = $(this);
        if (jtxb.data("value") && jtxb.val() !== jtxb.data("etiqueta")) {
            jtxb.data("value", null);
            jtxb.data("etiqueta", null);
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
    jtbodyDetalleVenta.delegate("input[type=text]", "change", tbodyDetalleVenta_change);
    jtbodyDetalleVenta.delegate("input.descuento", "keydown", valDecimal);
    jtbodyDetalleVenta.delegate("input.cantidad", "keydown", valNumerico);
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
function tbodyDetalleVenta_change(evt) {
    var jcmd = $(evt.currentTarget);
    ActualizarLista(jcmd);
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
    if (!jtxbCliente.data("value")) {
        mensajes.push(" - Debe especificar un cliente.");
    }
    if (lDetalleVenta.length == 0) {
        mensajes.push(" - Debe debe agregar por lo menos un producto.");
    }
    else {
        var productosCeroCantidad = $.grep(lDetalleVenta, function (n, i) {
            return n.Cantidad < 1;
        });
        if (productosCeroCantidad.length > 0) {
            mensajes.push(" - Debe especificar una cantidad para todos los productos.");
        }
    }
    if (mensajes.length > 0) {
        Swal.fire({
            icon: "error",
            title: "Mensaje",
            html: mensajes.join("<br/>"),
        });
        return;
    }
    var lDetalle = [];
    $.each(lDetalleVenta, function (index, value) {
        lDetalle.push({
            IdProducto: value.IdProducto,
            Cantidad: value.Cantidad,
            PrecioUnitario: value.Precio.toFixed(2),
            Descuento: value.Descuento.toFixed(2),
            Subtotal: value.Subtotal.toFixed(2)
        });
    });
    var dto = {
        eVenta: {
            IdCliente: Number(jtxbCliente.data("value")),
        },
        VentaDetalle: lDetalle
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
    if (lDetalleVenta.length > 0) {
        var producto = $.grep(lDetalleVenta, function (n, i) {
            return n.IdProducto == Number(jtr.data("id"));
        });
        if (producto.length > 0) {
            return;
        }
    }
    lDetalleVenta.push({
        IdProducto: jtr.data("id"),
        Codigo: jtr.data("codigo"),
        Nombre: jtr.data("nombre"),
        Precio: Number(jtr.data("precio")),
        Cantidad: 0,
        Descuento: 0,
        Subtotal: 0
    });
    CargarProductoLista();
}

function QuitarProducto(jtr) {
    var index = jtr.index();
    lDetalleVenta.splice(index, 1);
    CargarProductoLista();
}

function CargarProductoLista() {
    jtbodyDetalleVenta.html(jtmpDetalleVenta.render(lDetalleVenta));

    var total = 0;
    $.each(lDetalleVenta, function (index, objeto) {
        total += objeto.Subtotal;
    });
    $("#lblTotal").text(total.toFixed(2));
}

function ActualizarLista(jcmd) {
    var producto = lDetalleVenta[jcmd.closest("tr").index()];
    if (jcmd.hasClass("cantidad")) {
        producto.Cantidad = Number(jcmd.val());
    }
    else if (jcmd.hasClass("descuento")) {
        producto.Descuento = Number(jcmd.val());
    }
    producto.Subtotal = (producto.Cantidad * producto.Precio) - producto.Descuento;
    CargarProductoLista();
}
//#endregion

function valNumerico(e) {
    var tecla = e.which || e.keyCode;
    if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
        (
            (tecla >= 48 && tecla <= 57) || //números principal
            (tecla >= 96 && tecla <= 105) || //números derecha
            tecla === 8 || //borrar atrás
            tecla === 9 ||  //tab
            tecla === 13 || // enter
            tecla === 35 || //fin
            tecla === 36 || //inicio
            tecla === 37 || //izquierda
            tecla === 39 || //derecha
            tecla === 46 || //suprimir
            tecla === 45 //insertar
        )
    ) {
        return true;
    }
    return false;
}

function valDecimal(e) {
    var tecla = e.which || e.keyCode;
    if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
        (
            (tecla >= 48 && tecla <= 57) || //números principal
            (tecla >= 96 && tecla <= 105) || //números derecha
            tecla === 190 || //punto centro
            tecla === 110 || //punto derecha
            tecla === 8 || //borrar atrás
            tecla === 9 || //tab
            tecla === 13 || // enter
            tecla === 35 || //fin
            tecla === 36 || //inicio
            tecla === 37 || //izquierda
            tecla === 39 || //derecha
            tecla === 46 || //suprimir
            tecla === 45  //insertar
        )
    ) {
        return true;
    }
    return false;
}