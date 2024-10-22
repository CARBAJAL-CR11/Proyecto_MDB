using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SerDescripcion
    {
        //Ingresar descripcion
        public static bool AgregarDescripcion(ControllerDescripcion descripcion, out string message)
        {
            try
            {
                return ModeloDescripcion.IngresarDescripcion(descripcion.codigoDescripcion, descripcion.descripcion, descripcion.clasificacionEdad, descripcion.codigoProductora, out message);
            }
            catch (Exception ex)
            {
                message = $"Error al registrar la descripcion: {ex.Message}";
                return false;
            }
        }

        //Actualizar descripcion
        public static bool ActualizarDescripcion(ControllerDescripcion descripcion, out string message)
        {
            try
            {
                return ModeloDescripcion.actualizarDescripcion(descripcion.codigoDescripcion, descripcion.descripcion, descripcion.clasificacionEdad, descripcion.codigoProductora, out message);
            }
            catch (Exception ex)
            {
                message = $"Error al actualizar la descripcion: {ex.Message}";
                return false;
            }
        }

        //Eliminar descripcion
        public static bool EliminarDescripcion(ControllerDescripcion descripcion, out string message)
        {
            try
            {
                return ModeloDescripcion.eliminarDescripcion(descripcion.codigoDescripcion, out message);
            }
            catch (Exception ex)
            {
                message = $"Error al eliminar la descripcion: {ex.Message}";
                return false;
            }
        }
    }
}
