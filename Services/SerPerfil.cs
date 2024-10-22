using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using System.Threading.Tasks;

namespace Services
{
    public class SerPerfil
    {
        public static DataTable CargarPerfiles()
        {
            DataTable datos = ModeloPerfiles.CargarPerfiles(out string message);
            return datos;
        }
        public static DataTable cagarUsuarios()
        {
            DataTable datos = ModeloPerfiles.cargarUsuarios(out string message);
            return datos;
        }
    }
}
