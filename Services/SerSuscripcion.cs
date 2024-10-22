using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SerSuscripcion
    {
        public static DataTable CargarSuscripciones()
        {
            DataTable datos = ModeloSuscripcion.CargarSuscripciones(out string message);
            return datos;
        }
        public static DataTable CargarVistaSuscripciones()
        {
            DataTable datos = ModeloSuscripcion.CargarVistaSuscripciones(out string message);
            return datos;
        }
    }
}
