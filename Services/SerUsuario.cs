using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using Controller;
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
        public static DataTable cargarUnUsuario(string codigo_usuario) {
            DataTable datos = ModeloUsuario.cargarUnUsuario(out string message, codigo_usuario);
            return datos;
        }
        public static DataTable cagarTipos() {
            DataTable datos = ModeloUsuario.cargarTipoUsuarios(out string message);
            return datos;
        }
        public static DataTable cargarSusb() {
            DataTable datos = ModeloUsuario.cargarSubscripcion(out string message);
            return datos;
        }
        public static bool AgregarUsuario(ControllerUsuario usuario, out string message)
        {
            try {
                return ModeloUsuario.ingresarUsuarios(usuario.codigoUsuario,usuario.nombresUsuario,usuario.apellidosUsuario,usuario.correoUsuario,usuario.claveUsuario,usuario.fechaNacimiento,usuario.estadoCuenta,usuario.tipoUsuario,usuario.suscripcion,out message);
            }
            catch (Exception ex) {
                message = $"Error al registrar el usuario: {ex.Message}";
                return false;
            }
        }
        public static bool ActualizarUsuario(ControllerUsuario usuario, out string message) {
            try
            {
                return ModeloUsuario.actualizarUsuarios(usuario.codigoUsuario, usuario.nombresUsuario, usuario.apellidosUsuario, usuario.correoUsuario, usuario.claveUsuario, usuario.fechaNacimiento, usuario.estadoCuenta, usuario.tipoUsuario, usuario.suscripcion, out message);
            }
            catch (Exception ex)
            {
                message = $"Error al actualizar el usuario: {ex.Message}";
                return false;
            }
        }
        public static bool EliminarUsuario(string codigo, out string message) {
            try
            {
                return ModeloUsuario.EliminarUsuarios(out message,codigo);
            }
            catch (Exception ex)
            {
                message = $"Error al registrar el jugador: {ex.Message}";
                return false;
            }
        }

        public static int logIn(string correo, string clave)
        {
            return ModeloUsuario.logIn(correo,clave);
        }
    }
}
