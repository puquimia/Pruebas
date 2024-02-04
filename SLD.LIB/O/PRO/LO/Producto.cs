using Dapper.Contrib.Extensions;
using SLD.LIB.O.PRO.AD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.O.PRO.LO
{
    [Table("dbo.Producto")]
    public class Producto
    {
        #region Propiedades
        [ExplicitKey]
        public string CSku { get; set; }
        public string CNombre { get; set; }
        public string CSkuFabricante { get; set; }
        public string CNmbFabricante { get; set; }
        public string CNmbProveedor { get; set; }
        public decimal NPeso { get; set; }
        public string CUM { get; set; }
        public decimal NPrecioLista { get; set; }
        public string CCodBarra { get; set; }
        public string CSkuAlternante { get; set; }
        #endregion

        #region Metodos
        public readonly DAccesos acceso;
        public Producto()
        {
            acceso = new DAccesos();
        }
        public List<Producto> TraerProductos()
        {
            return acceso.GetAll<Producto>();
        }
        public void RegistrarProducto()
        {
            acceso.Insert(this);
        }

        public void RegistrarProveedorProducto()
        {
            acceso.UpdateColumns(this, "CNmbProveedor");
        }

        public void RegistrarPrecioBaseProducto()
        {
            acceso.UpdateColumns(this, "NPrecioLista");
        }
        #endregion
    }
}
