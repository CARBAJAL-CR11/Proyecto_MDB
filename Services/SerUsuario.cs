using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using System.Threading.Tasks;

namespace Services
{
    public class ServUsuario
    {
        public static DataTable CargarUsuarios()
        {
            DataTable datos = ModeloUsuario.CargarUsuario(out string message);
            return datos;
        }
    }
}
