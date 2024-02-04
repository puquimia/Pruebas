using Microsoft.VisualStudio.TestTools.UnitTesting;
using SLD.LIB.O.SOL.AD;
using SLD.LIB.O.SOL.LO.Ventas;
using SLD.LIB.O.SOL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SLD.TEST
{
    [TestClass]
    public class VentasTest
    {
        [TestInitialize]
        public void IniciarPruebasBD()
        {
            DAccesos acceso = new DAccesos();
            acceso.EjecutarSP("IniciarPruebasBD");
        }

        [TestMethod]
        [TestCategory("Registrar ventas")]
        public void RegistrarVentasTest()
        {
            Venta eVenta = new Venta()
            {
                CodigoCliente = "CLI-001",
                NombreCliente = "Maria Mendoza",
                FormaPago = Constantes.FORMAPAGO_CONTADO,
                FormaEntrega = Constantes.FORMAENTREGA_TRABAJO,
                TipoVenta = Constantes.VENTATIPO_PRODUCTO,
                Fecha = DateTime.Now
            };
            eVenta.lVentaDetalle = new List<VentaDetalle>()
            {
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-001",
                    NombreProducto = "Nombre producto demo 001",
                    Almacen = "ALM-01",
                    PrecioUnitario = 58m,
                    Cantidad = 5,
                },
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-002",
                    NombreProducto = "Nombre producto demo 002",
                    Almacen = "ALM-01",
                    PrecioUnitario = 145,
                    Cantidad = 8,
                },
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-003",
                    NombreProducto = "Nombre producto demo 003",
                    Almacen = "ALM-02",
                    PrecioUnitario = 15,
                    Cantidad = 50,
                }
            };
            eVenta.Registar();
            List<object> objVenta = eVenta.Traer();
            Venta eVentaRegistro = (Venta)objVenta[0];
            eVentaRegistro.lVentaDetalle = (List<VentaDetalle>)objVenta[1];
            Assert.IsTrue(eVentaRegistro.CodigoCliente == eVenta.CodigoCliente);
            Assert.IsTrue(eVentaRegistro.NombreCliente == eVenta.NombreCliente);
            Assert.IsTrue(eVentaRegistro.FormaPago == eVenta.FormaPago);
            Assert.IsTrue(eVentaRegistro.Total == eVenta.lVentaDetalle.Sum(x => x.Cantidad * x.PrecioUnitario));
            Assert.IsTrue(eVentaRegistro.lVentaDetalle.Count == eVenta.lVentaDetalle.Count);
        }

        [TestMethod]
        [TestCategory("Registrar ventas")]
        public void RegistrarVentasTest_ConDescuentosxItem()
        {
            VentaDescuentoItem eVenta = new VentaDescuentoItem()
            {
                CodigoCliente = "CLI-001",
                NombreCliente = "Maria Mendoza",
                FormaPago = Constantes.FORMAPAGO_CONTADO,
                FormaEntrega = Constantes.FORMAENTREGA_TRABAJO,
                TipoVenta = Constantes.VENTATIPO_PRODUCTO,
                Fecha = DateTime.Now
            };
            eVenta.lVentaDetalle = new List<VentaDetalle>()
            {
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-001",
                    NombreProducto = "Nombre producto demo 001 265",
                    Almacen = "ALM-01",
                    PrecioUnitario = 58m,
                    Descuento = 5m,
                    Cantidad = 5,
                },
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-002",
                    NombreProducto = "Nombre producto demo 002 1144",
                    Almacen = "ALM-01",
                    PrecioUnitario = 145,
                    Descuento = 2m,
                    Cantidad = 8,
                },
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-003",
                    NombreProducto = "Nombre producto demo 003 750",
                    Almacen = "ALM-02",
                    PrecioUnitario = 15,
                    Cantidad = 50,
                },
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-004",
                    NombreProducto = "Nombre producto demo 004 1465",
                    Almacen = "ALM-04",
                    PrecioUnitario = 1500,
                    Descuento = 35m,
                    Cantidad = 1,
                }
            };
            eVenta.Registar();
            List<object> objVenta = eVenta.Traer();
            Venta eVentaRegistro = (Venta)objVenta[0];
            eVentaRegistro.lVentaDetalle = (List<VentaDetalle>)objVenta[1];
            Assert.IsTrue(eVentaRegistro.CodigoCliente == eVenta.CodigoCliente);
            Assert.IsTrue(eVentaRegistro.NombreCliente == eVenta.NombreCliente);
            Assert.IsTrue(eVentaRegistro.FormaPago == eVenta.FormaPago);
            Assert.IsTrue(eVentaRegistro.Total == eVenta.lVentaDetalle.Sum(x => x.Cantidad * (x.PrecioUnitario - (x.Descuento ?? 0))));
            Assert.IsTrue(eVentaRegistro.Total == 3624);
            Assert.IsFalse(eVentaRegistro.Total == eVenta.lVentaDetalle.Sum(x => x.Cantidad * x.PrecioUnitario));
            Assert.IsTrue(eVentaRegistro.lVentaDetalle.Count == eVenta.lVentaDetalle.Count);
        }
        [TestMethod]
        [TestCategory("Registrar ventas")]
        public void RegistrarVentasTest_ConDescuentosGlobal()
        {
            VentaDescuentoGlobal eVenta = new VentaDescuentoGlobal()
            {
                CodigoCliente = "CLI-001",
                NombreCliente = "Maria Mendoza",
                FormaPago = Constantes.FORMAPAGO_CONTADO,
                FormaEntrega = Constantes.FORMAENTREGA_TRABAJO,
                TipoVenta = Constantes.VENTATIPO_PRODUCTO,
                Descuento = 50m,
                Fecha = DateTime.Now
            };
            eVenta.lVentaDetalle = new List<VentaDetalle>()
            {
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-001",
                    NombreProducto = "Nombre producto demo 001",
                    Almacen = "ALM-01",
                    PrecioUnitario = 58m,
                    Cantidad = 5,
                },
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-002",
                    NombreProducto = "Nombre producto demo 002",
                    Almacen = "ALM-01",
                    PrecioUnitario = 145,
                    Cantidad = 8,
                },
                new VentaDetalle()
                {
                    CodigoProducto = "PRO-003",
                    NombreProducto = "Nombre producto demo 003",
                    Almacen = "ALM-02",
                    PrecioUnitario = 15,
                    Cantidad = 50,
                }
            };
            eVenta.Registar();
            List<object> objVenta = eVenta.Traer();
            Venta eVentaRegistro = (Venta)objVenta[0];
            eVentaRegistro.lVentaDetalle = (List<VentaDetalle>)objVenta[1];
            Assert.IsTrue(eVentaRegistro.CodigoCliente == eVenta.CodigoCliente);
            Assert.IsTrue(eVentaRegistro.NombreCliente == eVenta.NombreCliente);
            Assert.IsTrue(eVentaRegistro.FormaPago == eVenta.FormaPago);
            Assert.IsTrue(eVentaRegistro.Total == 2150m);
            Assert.IsFalse(eVentaRegistro.Total == eVenta.lVentaDetalle.Sum(x => x.Cantidad * x.PrecioUnitario));
            Assert.IsTrue(eVenta.lVentaDetalle.Sum(x => x.Cantidad * x.PrecioUnitario) - eVentaRegistro.Descuento == eVentaRegistro.Total);
            Assert.IsTrue(eVentaRegistro.lVentaDetalle.Count == eVenta.lVentaDetalle.Count);
        }
    }
}
