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
    [Table("dbo.Producto")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }


        public readonly DAccesos acceso;
        public Producto()
        {
            acceso = new DAccesos();
        }
        public List<Producto> Buscar(string nombre)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
                        SELECT
                         p.Id,
                         p.Codigo,
                         p.Nombre,
                         p.PrecioVenta,
                         p.Stock
                        FROM dbo.Producto p
                        WHERE  ");
            DynamicParameters parametros = new DynamicParameters();
            if(!string.IsNullOrEmpty(nombre) )
            {
                sb.Append($"(p.Codigo LIKE @Nombre OR p.Nombre LIKE @Nombre) AND   ");
                parametros.Add("Nombre", nombre, System.Data.DbType.AnsiString);
            }
            sb.Length -= 7;
            sb.Append(" ORDER BY p.Codigo, p.Nombre");
            return acceso.EjecutarConsulta<Producto>(sb.ToString(), parametros);
        }
    }
}
