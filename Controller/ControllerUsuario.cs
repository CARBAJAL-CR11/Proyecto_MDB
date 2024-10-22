using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Controller
{
    public class ControllerUsuario
    {
        public string codigoUsuario { get; set; }
        public string nombresUsuario { get; set; }
        public string apellidosUsuario { get; set; }
        public string correoUsuario { get; set; }

    }
}
