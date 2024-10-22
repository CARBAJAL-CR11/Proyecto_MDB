using Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModeloDescripcion
    {
        //Ingresar Descripcion
        public static bool IngresarDescripcion(string codigo_descripcion, string descripcion, string clasificacion_edad, string codigoProductora, out string message)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                string query = "EXEC PA_InsertarDescripcion @codigo_descripcion,@descripcion_d,@clasificacion_edad,@codigo_productora";
                using (SqlConnection connection = dbConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@codigo_descripcion", codigo_descripcion);
                    cmd.Parameters.AddWithValue("@descripcion_d", descripcion);
                    cmd.Parameters.AddWithValue("@clasificacion_edad", clasificacion_edad);
                    cmd.Parameters.AddWithValue("@codigo_productora", codigoProductora);
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        message = "Agregado Exitosamente";
                        return true;
                    }
                    else
                    {
                        message = "No se insertó ningún registro.";
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                message = $"Error de SQL: {DatabaseValidations.FormatSqlErrorMessage(ex)}";
                return false;
            }
            catch (Exception ex)
            {
                message = $"Error general al insertar el usuario: {ex.Message}";
                return false;
            }
        }
    }
}
