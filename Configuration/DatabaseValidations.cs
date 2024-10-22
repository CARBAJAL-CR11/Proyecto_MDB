using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public static class DatabaseValidations
    {
        public static string FormatSqlErrorMessage(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2627: // Error de clave duplicada (violación de índice único)
                    return "Error: La clave que está intentando insertar ya existe en la base de datos.";
                case 547: // Error de restricción de clave foránea
                    return "Error: La operación viola una restricción de clave foránea.";
                case 50000: // Error definido por el usuario
                    return $"Error definido por el usuario: {ex.Message}";
                case 515: // Error al intentar insertar un valor NULL en una columna que no lo permite
                    return "Error: No se puede insertar un valor NULL en una columna que no lo permite.";
                case 208: // Error de tabla o vista no encontrada
                    return "Error: La tabla o vista especificada no existe en la base de datos.";
                case 1205: // Deadlock (interbloqueo)
                    return "Error: La transacción fue seleccionada como víctima de un deadlock, por favor intente nuevamente.";
                case 2601: // Violación de índice único (clave duplicada)
                    return "Error: El valor que está intentando insertar ya existe y viola una restricción de índice único.";
                case 18456: // Error de inicio de sesión fallido
                    return "Error: Fallo en la autenticación del inicio de sesión, verifique las credenciales.";
                case 4060: // Error de inicio de sesión a la base de datos
                    return "Error: No se puede abrir la base de datos solicitada en el inicio de sesión.";
                case 18488: // Cambio obligatorio de contraseña en primer inicio de sesión
                    return "Error: Debe cambiar su contraseña en el primer inicio de sesión.";
                default:
                    return $"Error SQL: {ex.Message}";
            }

        }
    }
}
