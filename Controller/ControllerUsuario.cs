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
        public string claveUsuario { get; set; }
        public string fechaNacimiento { get; set; }
        public string estadoCuenta { get; set; }
        public string tipoUsuario { get; set; }
        public string suscripcion { get; set; }

    }
}
