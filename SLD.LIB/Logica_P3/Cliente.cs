using Dapper;
using Dapper.Contrib.Extensions;
using SLD.LIB.Datos;
using SLD.LIB.O.SOL.LO.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.Logica_P3
{
    [Table("dbo.Cliente")]
    public class Cliente
    {
        #region Entidad
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int TipoDocumento { get; set; }
        [Computed]
        public string NombreTipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        #endregion

        #region Metodos
        public readonly DAccesos acceso;
        public Cliente()
        {
            acceso = new DAccesos();
        }
        public void Registrar()
        {
            acceso.Insert(this);
        }

        public List<Cliente> Listar()
        {
            return acceso.TrerLista<Cliente>("TraerClientes", null);
        }
        public Cliente Traer(int idCliente)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("IdCliente", idCliente, System.Data.DbType.Int32);
            return acceso.EjecutarConsultaSP<Cliente>("TraerVenta", param);
        }
        #endregion
    }
}
