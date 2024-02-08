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

        public List<Cliente> Listar(string codigoNombre)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
                     SELECT
	                      c.Id,
                          c.Codigo,
                          c.Nombre,
                          c.TipoDocumento,
	                      es.Valor NombreTipoDocumento,
                          c.Documento,
                          c.Email
	                     FROM dbo.Cliente c
	                     JOIN dbo.Estaticos es ON es.Codigo = c.TipoDocumento AND es.Grupo = 'TIPO.DOCUMENTO'
                         WHERE  ");
            DynamicParameters parametros = new DynamicParameters();
            if (!string.IsNullOrEmpty(codigoNombre))
            {
                sb.Append("(c.Codigo LIKE @CodigoNombre OR c.Nombre LIKE @CodigoNombre) AND   ");
                parametros.Add("CodigoNombre", $"%{codigoNombre}%", System.Data.DbType.AnsiString);
            }
            sb.Length -= 7;
            sb.Append(" ORDER BY c.Nombre");
            return acceso.EjecutarConsulta<Cliente>(sb.ToString(), parametros);
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
