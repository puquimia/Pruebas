using SLD.LIB.Logica_P3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLD.WEB.Controllers
{
    public class VentasController : Controller
    {
        private readonly Cliente cliente;
        private readonly Producto producto;
        public VentasController()
        {
            cliente = new Cliente();
            producto = new Producto();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nueva()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Venta eVenta)
        {
            try
            {
                eVenta.Registrar();
                return Json(new { isSuccess = "ok" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult TraerClientes(string filtro)
        {
            try
            {
                List<Cliente>lClientes = cliente.Listar();
                return Json(
                    from eCli in lClientes
                    where !string.IsNullOrEmpty(filtro.Trim()) ? eCli.Nombre.ToLower().StartsWith(filtro.ToLower()) : true
                    select new
                    {
                        value = eCli.Id,
                        label = eCli.Codigo + " - " + eCli.Nombre
                    }
                );
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult TraerProductos(string nombreCodigo)
        {
            try
            {
                List<Producto> lProductos = producto.Buscar(nombreCodigo);
                return Json(
                    from ePro in lProductos
                    select new
                    {
                        Id = ePro.Id,
                        Codigo = ePro.Codigo,
                        Nombre = ePro.Nombre,
                        Precio =  ePro.PrecioVenta,
                        Stock = ePro.Stock
                    }
                );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}