using Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModeloSerie
    {
        //Cargar las series existentes
        public static DataTable CargarSeries(out string message)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            DataTable data = new DataTable();

            try
            {
                string query = "SELECT * FROM vw_series";
                // Obtén la conexión SQL Server usando la instancia de DatabaseConnection
                using (SqlConnection connection = dbConnection.GetConnection())
                using (SqlCommand cmdselect = new SqlCommand(query, connection))
                using (SqlDataAdapter adp = new SqlDataAdapter(cmdselect))
                {
                    connection.Open();
                    adp.Fill(data);
                }
            }
            catch (Exception ex)
            {
                message = $"Error al cargar datos: {ex.Message}";
                data = null;
            }
            message = null;
            return data;
        }

        //Ingresar series
        public static bool ingresarSeries(string codigoSerie,string nombre_serie, string fechaInicio, string fechaFinal, string codigo_descripcion, out string message)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                string query = "EXEC PA_InsertarSerie @codigo_Serie,@nombre_Serie,@fecha_Inicio,@fecha_Fin,@codigo_Descripcion";
                using (SqlConnection connection = dbConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@codigo_serie", codigoSerie);
                    cmd.Parameters.AddWithValue("@nombre_Serie", nombre_serie);
                    cmd.Parameters.AddWithValue("@fecha_Inicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fecha_Fin", fechaFinal);
                    cmd.Parameters.AddWithValue("@codigo_Descripcion", codigo_descripcion);
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
