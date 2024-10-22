using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SerComentario
    {
        public static DataTable CargarComentarios()
        {
            DataTable datos = ModeloComentario.CargarComentarios(out string message);
            return datos;
        }
        public static DataTable cargarPerfiles()
        {
            DataTable datos = ModeloPerfil.CargarPerfiles(out string message);
            return datos;
        }
    }
}
