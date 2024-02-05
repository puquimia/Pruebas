using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.Logica_P3
{
    [Table("dbo.VentaDetalle")]
    public class VentaDetalle
    {
        [ExplicitKey]
        public int IdVenta { get; set; }
        [ExplicitKey]
        public int IdProducto { get; set; }
        [Computed]
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
    }
}
