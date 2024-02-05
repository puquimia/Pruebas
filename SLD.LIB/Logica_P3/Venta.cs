using Dapper;
using Dapper.Contrib.Extensions;
using SLD.LIB.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.Logica_P3
{
    [Table("dbo.Venta")]
    public class Venta
    {
        #region Entidad
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        [Computed]
        public string NombreCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        [Computed]
        public List<VentaDetalle> VentaDetalle { get; set; }
        #endregion

        #region Metodos
        public readonly DAccesos acceso;
        public Venta()
        {
            acceso = new DAccesos();
        }
        public void Registrar()
        {
            acceso.Insert(this);
        }

        public List<object> Listar()
        {
            return acceso.EjecutarConsultaSP("TraerVentas", x => x.Read<Venta>().ToList());
        }
        public List<object> Traer(int idVenta)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("IdVenta", idVenta, System.Data.DbType.Int32);
            return acceso.EjecutarConsultaSP("TraerVenta", param, 
                x => x.Read<Venta>().FirstOrDefault(),
                x => x.Read<VentaDetalle>().ToList());
        }
        #endregion
    }
}
