using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.LIB.O.SOL.LO.Productos
{
    public interface IProductoOperacion
    {
        void Registrar();
        List<Producto> Listar();
    }
}
