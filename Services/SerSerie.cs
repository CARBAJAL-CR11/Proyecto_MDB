using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SerSerie
    {
        public static DataTable CargarSeries()
        {
            DataTable datos = ModeloSerie.CargarSeries(out string message);
            return datos;
        }
    }
}
