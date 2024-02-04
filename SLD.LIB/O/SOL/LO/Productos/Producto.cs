using Dapper.Contrib.Extensions;
using SLD.LIB.O.SOL.AD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.O.SOL.LO.Productos
{
    [Table("dbo.Producto")]
    public class Producto : IProductoOperacion
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
        public void Registrar()
        {
            acceso.Insert(this);
        }
        public List<Producto> Listar()
        {
            return acceso.GetAll<Producto>();
        }
        #endregion
    }
}
