using Dapper.Contrib.Extensions;
using SLD.LIB.O.PRO.AD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.O.SOL.LO.Productos
{
    [Table("dbo.Producto")]
    public class PrecioProducto : Producto
    {
       public void RegistrarPrecioBaseProducto()
       {
            acceso.UpdateColumns(this, "NPrecioLista");
       }
    }
}
