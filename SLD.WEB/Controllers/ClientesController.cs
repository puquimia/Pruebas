using SLD.LIB.Logica_P3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLD.WEB.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Cliente cliente;
        private readonly Estaticos estaticos;
        public ClientesController()
        {
            cliente = new Cliente();
            estaticos = new Estaticos();
        }
        // GET: Clientes
        public ActionResult Index()
        {
            List<Cliente> lClientes = cliente.Listar(string.Empty);
            ViewData["Clientes"] = lClientes;
            return View();
        }

        public ActionResult Nuevo()
        {
            ViewData["TiposDocumento"] = estaticos.TraerEstaticosxGrupo("TIPO.DOCUMENTO");
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Cliente eCliente)
        {
            try
            {
                eCliente.Registrar();
                return Json(new { isSuccess = "ok" });
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}