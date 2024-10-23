using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Configuration;

namespace Model
{
    public class ModeloUsuario
    {
        public static DataTable CargarUsuario(out string message)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            DataTable data = new DataTable();

            try
            {
                string query = "SELECT * FROM usuarios ";
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
        public static DataTable cargarUnUsuario(out string message, string codigo)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            DataTable data = new DataTable();
            try
            {
                string query = "SELECT a.codigoUsuario,a.nombres,a.apellidos,a.correo,a.fechaNacimiento,a.estadoCuenta,b.tipoUsuario,c.nombreSuscripcion FROM usuarios a INNER JOIN tiposUsuarios b ON a.codigoTipoUsuario=b.codigoTipoUsuario INNER JOIN suscripciones c ON a.codigoSuscripcion=c.codigoSuscripcion WHERE codigoUsuario=@codigo";
                // Obtén la conexión SQL Server usando la instancia de DatabaseConnection
                using (SqlConnection connection = dbConnection.GetConnection())
                using (SqlCommand cmdselect = new SqlCommand(query, connection))
                using (SqlDataAdapter adp = new SqlDataAdapter(cmdselect))
                {
                    cmdselect.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;
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
        public static DataTable cargarTipoUsuarios(out string message) {
            DatabaseConnection dbConnection = new DatabaseConnection();
            DataTable data = new DataTable();
            try
            {
                string query = "SELECT * FROM tiposUsuarios ";
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
        public static DataTable cargarSubscripcion(out string message)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            DataTable data = new DataTable();
            try
            {
                string query = "SELECT * FROM suscripciones ";
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
        public static bool ingresarUsuarios(string codigo_usuario,string nombres,string apellidos,string correo, string clave, string fecha_nac,string estado_cuenta,string codigo_tipo,string codigo_subs,out string message) {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                string query = "INSERT INTO usuarios (codigoUsuario,nombres, apellidos, correo, clave,fechaNacimiento, estadoCuenta, codigoTipoUsuario, codigoSuscripcion) " +
                               "VALUES (@codigo,@nombre, @apellido, @correo, @Clave,@fecha, @estado, @codigoT, @codigoS)";
                using (SqlConnection connection = dbConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@codigo",codigo_usuario);
                    cmd.Parameters.AddWithValue("@nombre", nombres);
                    cmd.Parameters.AddWithValue("@apellido", apellidos);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@Clave", clave);
                    cmd.Parameters.AddWithValue("@fecha", fecha_nac);
                    cmd.Parameters.AddWithValue("@estado", estado_cuenta);
                    cmd.Parameters.AddWithValue("@codigoT", codigo_tipo);
                    cmd.Parameters.AddWithValue("@codigoS", codigo_subs);

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
        public static bool actualizarUsuarios(string codigo_usuario, string nombres, string apellidos, string correo, string clave, string fecha_nac, string estado_cuenta, string codigo_tipo, string codigo_subs, out string message)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                string query = "UPDATE usuarios SET nombres=@nombre, apellidos=@apellido, correo=@correo,fechaNacimiento=@fecha,estadoCuenta=@estado,codigoTipoUsuario=@codigoT,codigoSuscripcion=@codigoS WHERE codigoUsuario=@codigo";
                using (SqlConnection connection = dbConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo_usuario);
                    cmd.Parameters.AddWithValue("@nombre", nombres);
                    cmd.Parameters.AddWithValue("@apellido", apellidos);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@fecha", fecha_nac);
                    cmd.Parameters.AddWithValue("@estado", estado_cuenta);
                    cmd.Parameters.AddWithValue("@codigoT", codigo_tipo);
                    cmd.Parameters.AddWithValue("@codigoS", codigo_subs);

                    connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        message = "Actualizado Exitosamente";
                        return true;
                    }
                    else
                    {
                        message = "No se actualizó ningún registro.";
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
