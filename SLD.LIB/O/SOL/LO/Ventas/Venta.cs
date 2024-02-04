using Dapper;
using Dapper.Contrib.Extensions;
using SLD.LIB.O.SOL.AD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SLD.LIB.O.SOL.LO.Ventas
{
    [Table("dbo.Venta")]
    public class Venta : IVentaOperaciones
    {
        [Key]
        public int Id { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public int FormaPago { get; set; }
        public int FormaEntrega { get; set; }
        public int TipoVenta { get; set; }
        public decimal? Descuento { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        [Computed]
        public List<VentaDetalle> lVentaDetalle { get; set; }


        public readonly DAccesos acceso;
        public Venta()
        {
            acceso = new DAccesos();
        }


        public List<object> Traer()
        {
            DynamicParameters lParametros = new DynamicParameters();
            lParametros.Add("IdVenta", this.Id, System.Data.DbType.Int32);
            return acceso.EjecutarConsultaSP("TraerVenta", lParametros,
                x => x.Read<Venta>().First(),
                x=>x.Read<VentaDetalle>().ToList());
        }

        public void Registar()
        {
            using (TransactionScope ts =new TransactionScope())
            {
                this.Total = lVentaDetalle.Sum(x => (decimal)x.Cantidad * x.PrecioUnitario);
                acceso.Insert(this);
                foreach (VentaDetalle eDetalle in this.lVentaDetalle)
                {
                    eDetalle.IdVenta = this.Id;
                    eDetalle.Subtotal = (decimal)eDetalle.Cantidad * eDetalle.PrecioUnitario;
                    acceso.Insert(eDetalle);
                }
                ts.Complete();
            }
        }
    }
}
