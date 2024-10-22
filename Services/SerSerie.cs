using Controller;
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
        //Obtener series
        public static DataTable CargarSeries()
        {
            DataTable datos = ModeloSerie.CargarSeries(out string message);
            return datos;
        }

        //Ingresar serie
         public static bool AgregarSerie(ControllerSerie serie, out string message)
        {
            try
            {
                return ModeloSerie.ingresarSeries(usuario.codigoUsuario, usuario.nombresUsuario, usuario.apellidosUsuario, usuario.correoUsuario, usuario.claveUsuario, usuario.fechaNacimiento, usuario.estadoCuenta, usuario.tipoUsuario, usuario.suscripcion, out message);
            }
            catch (Exception ex)
            {
                message = $"Error al registrar el usuario: {ex.Message}";
                return false;
            }
        }
    }
}
