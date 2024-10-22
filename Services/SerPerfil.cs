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
            DataTable datos = ModeloPerfil.CargarPerfiles(out string message);
            return datos;
        }
        public static DataTable cargarUsuarios()
        {
            DataTable datos = ModeloUsuario.CargarUsuario(out string message);
            return datos;
        }
    }
}
