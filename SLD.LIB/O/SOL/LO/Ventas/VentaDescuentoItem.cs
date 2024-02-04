using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SLD.LIB.O.SOL.LO.Ventas
{
    [Table("dbo.Venta")]
    public class VentaDescuentoItem : Venta
    {
        public void Registar()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                this.Total = lVentaDetalle.Sum(x => (decimal)x.Cantidad * (x.PrecioUnitario - (x.Descuento ?? 0)));
                acceso.Insert(this);
                foreach (VentaDetalle eDetalle in this.lVentaDetalle)
                {
                    eDetalle.IdVenta = this.Id;
                    eDetalle.Subtotal = eDetalle.Cantidad * (eDetalle.PrecioUnitario - (eDetalle.Descuento ?? 0));
                    acceso.Insert(eDetalle);
                }
                ts.Complete();
            }
        }
    }
}
