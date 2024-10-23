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
    public class SerProductora
    {
        public static DataTable CargarProductoras()
        {
            DataTable datos = ModeloProductora.CargarProductoras(out string message);
            return datos;
        }
        public static DataTable cargarUnaProductora(string codigo_productora)
        {
            DataTable datos = ModeloProductora.cargarUnaProductora(out string message, codigo_productora);
            return datos;
        }
        public static bool AgregarProductora(ControllerProductoras productoras, out string message)
        {
            try
            {
                return ModeloProductora.ingresarProductora(productoras.codigoProductora,productoras.nombreProductora,productoras.direccionProductora,productoras.correoProductora,productoras.telefonoProductora,out message);
            }
            catch (Exception ex)
            {
                message = $"Error al registrar el usuario: {ex.Message}";
                return false;
            }
        }
        public static bool EliminarProductora(string codigo, out string message)
        {
            try
            {
                return ModeloProductora.EliminarProductora(out message, codigo);
            }
            catch (Exception ex)
            {
                message = $"Error al eliminar la productora: {ex.Message}";
                return false;
            }
        }
    }
}
