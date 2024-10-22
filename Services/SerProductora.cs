using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SerProductora
    {
        public static DataTable CargarProductoras()
        {
            DataTable datos = ModeloProductora.CargarProductoras(out string message);
            return datos;
        }
    }
}
