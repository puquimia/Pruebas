using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.O.SOL.LO.Ventas
{
    public interface IVentaOperaciones
    {
        void Registar();
        List<object> Traer();
    }
}
