using Dapper;
using SLD.LIB.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.Logica_P3
{
    public class Estaticos
    {
        public string Codigo { get; set; }
        public string Valor { get; set; }

        public readonly DAccesos acceso;
        public Estaticos()
        {
            acceso = new DAccesos();
        }
        public List<Estaticos> TraerEstaticosxGrupo(string grupo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Grupo", grupo, System.Data.DbType.AnsiString);
            return acceso.TrerLista<Estaticos>("TraerEstaticosxGrupo", param);
        }
    }
}
