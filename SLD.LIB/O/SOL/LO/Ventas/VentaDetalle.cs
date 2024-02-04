using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.O.SOL.LO.Ventas
{
    [Table("dbo.VentaDetalle")]
    public class VentaDetalle
    {
        [ExplicitKey]
        public int IdVenta { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Almacen { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal? Descuento { get; set; }
        public decimal Subtotal { get; set; }
    }
}
