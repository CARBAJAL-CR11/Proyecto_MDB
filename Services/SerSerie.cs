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
                return ModeloSerie.ingresarSeries(serie.codigoSerie,serie.nombreSerie,serie.fechaEmisionInicio,serie.fechaEmisionFin,serie.codigoDescripcion, out message);
            }
            catch (Exception ex)
            {
                message = $"Error al registrar la serie: {ex.Message}";
                return false;
            }
         }

        //Actualizar serie
        public static bool ActualizarSerie(ControllerSerie serie, out string message)
        {
            try
            {
                return ModeloSerie.actualizarSeries(serie.codigoSerie, serie.nombreSerie, serie.fechaEmisionInicio, serie.fechaEmisionFin, serie.codigoDescripcion, out message);
            }
            catch (Exception ex)
            {
                message = $"Error al actualizar la serie: {ex.Message}";
                return false;
            }
        }

        //Eliminar serie
        public static bool EliminarSerie(ControllerSerie serie, out string message)
        {
            try
            {
                return ModeloSerie.eliminarSerie(serie.codigoSerie, out message);
            }
            catch (Exception ex)
            {
                message = $"Error al eliminar la serie: {ex.Message}";
                return false;
            }
        }
    }
}
