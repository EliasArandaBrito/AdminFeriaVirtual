using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection;
using Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace Controller
{
    public class CUsuario
    {
        
        OracleCommand Comando = new OracleCommand();

        public bool InsertarUsuario(Usuario c)
        {
            try
            {
                Connection Cnn = new Connection();
                Cnn.conexion.Open();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_usuario";
                Comando.CommandType = CommandType.StoredProcedure;
                
                Comando.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2) { Value = c.Nombre });
                Comando.Parameters.Add(new OracleParameter("p_apellido", OracleDbType.Varchar2) { Value = c.Apellido });
                Comando.Parameters.Add(new OracleParameter("p_correoelectronico", OracleDbType.Varchar2) { Value = c.Correoelectronico });
                Comando.Parameters.Add(new OracleParameter("p_contrasena", OracleDbType.Varchar2) { Value = c.Contrasena });
                Comando.Parameters.Add(new OracleParameter("p_tipousuarioid", OracleDbType.Int32) { Value = c.Tipousuarioid });
                Comando.Parameters.Add(new OracleParameter("p_direccion", OracleDbType.Varchar2) { Value = c.Direccion });
                Comando.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2) { Value = c.Telefono });
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Oracle Exception: " + ex.Message);
                throw;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public List<Usuario> GetAllUsuarios()
        {
            Connection Cnn = new Connection();
            List<Usuario> usuarios = new List<Usuario>();
            Cnn.conexion.Open();
            using (Cnn.conexion)
            {
                try
                {
                    

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_usuarios; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario
                                {
                                    Usuarioid = Convert.ToInt32(reader["Usuarioid"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Correoelectronico = reader["Correoelectronico"].ToString(),
                                    Contrasena = reader["Contrasena"].ToString(),
                                    Tipousuarioid = Convert.ToInt32(reader["Tipousuarioid"]),
                                    Direccion = reader["Direccion"].ToString(),
                                    Telefono = reader["Telefono"].ToString()
                                };

                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            Cnn.conexion.Close();
            return usuarios;
        }

        public Usuario GetUsuarioById(int userId)
        {
            Connection Cnn = new Connection();
            Usuario usuario = null;
            Cnn.conexion.Open();
            using (Cnn.conexion)
            {
                try
                {
                    

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_usuario_by_id(:id); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("id", OracleDbType.Int32, userId, ParameterDirection.Input);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario
                                {
                                    Usuarioid = Convert.ToInt32(reader["Usuarioid"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Correoelectronico = reader["Correoelectronico"].ToString(),
                                    Contrasena = reader["Contrasena"].ToString(),
                                    Tipousuarioid = Convert.ToInt32(reader["Tipousuarioid"]),
                                    Direccion = reader["Direccion"].ToString(),
                                    Telefono = reader["Telefono"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            Cnn.conexion.Close();
            return usuario;
        }

        public bool ActualizarUsuario(Usuario c)
        {
            try
            {
                Connection Cnn = new Connection();
                Cnn.conexion.Open();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_usuarios";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add(new OracleParameter("p_usuarioid", OracleDbType.Varchar2) { Value = c.Usuarioid });
                Comando.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2) { Value = c.Nombre });
                Comando.Parameters.Add(new OracleParameter("p_apellido", OracleDbType.Varchar2) { Value = c.Apellido });
                Comando.Parameters.Add(new OracleParameter("p_correoelectronico", OracleDbType.Varchar2) { Value = c.Correoelectronico });
                Comando.Parameters.Add(new OracleParameter("p_contrasena", OracleDbType.Varchar2) { Value = c.Contrasena });
                Comando.Parameters.Add(new OracleParameter("p_tipousuarioid", OracleDbType.Int32) { Value = c.Tipousuarioid });
                Comando.Parameters.Add(new OracleParameter("p_direccion", OracleDbType.Varchar2) { Value = c.Direccion });
                Comando.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2) { Value = c.Telefono });
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Oracle Exception: " + ex.Message);
                throw;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool EliminarUsuario(int id)
        {
            try
            {
                Connection Cnn = new Connection();
                Cnn.conexion.Open();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_usuarios";
                Comando.CommandType = CommandType.StoredProcedure;
                
                Comando.Parameters.Add(new OracleParameter("p_usuarioid", OracleDbType.Int32) { Value = id });
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Oracle Exception: " + ex.Message);
                throw;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public int LoginCheckTipo(string email, string password, int tipo)
        {
            try
            {
                Connection Cnn = new Connection();
                Cnn.conexion.Open();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "login_usuario_with_type_check";
                Comando.CommandType = CommandType.StoredProcedure;
                
                // Add output parameter for the result
                OracleParameter resultParam = new OracleParameter("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
                Comando.Parameters.Add(resultParam);
                // Add input parameters
                Comando.Parameters.Add(new OracleParameter("p_correoelectronico", OracleDbType.Varchar2, 100) { Value = email });
                Comando.Parameters.Add(new OracleParameter("p_contrasena", OracleDbType.Varchar2, 100) { Value = password });
                Comando.Parameters.Add(new OracleParameter("p_expected_tipousuarioid", OracleDbType.Int32) { Value = Convert.ToInt32(tipo) });

                Comando.ExecuteNonQuery();

                int loginStatus = resultParam.Value != null ? ((OracleDecimal)resultParam.Value).ToInt32() : -3;

                switch (loginStatus)
                {
                    case -1:
                        Console.WriteLine("Login failed.");
                        break;
                    case -2:
                        Console.WriteLine("User type mismatch.");
                        break;
                    case 0:
                        Console.WriteLine("Login successful.");
                        break;
                    default:
                        Console.WriteLine("Unexpected result.");
                        break;
                }

                Comando.Parameters.Clear();
                Cnn.conexion.Close();

                return loginStatus;
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Oracle Exception: " + ex.Message);
                return -3;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -3;
            }
        }

        public string LoginReturnTipo(string email, string password)
        {
            try
            {
                Connection Cnn = new Connection();
                Cnn.conexion.Open();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "login_usuario_with_return_usertype";
                Comando.CommandType = CommandType.StoredProcedure;
                
                OracleParameter userTypeParam = new OracleParameter("p_usertype", OracleDbType.Varchar2, 50);
                userTypeParam.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(userTypeParam);

                Comando.Parameters.Add(new OracleParameter("p_correoelectronico", OracleDbType.Varchar2, 100) { Value = email });
                Comando.Parameters.Add(new OracleParameter("p_contrasena", OracleDbType.Varchar2, 100) { Value = password });

                // Add an output parameter for user type

                Comando.ExecuteNonQuery();

                object userTypeValue = Comando.Parameters["p_usertype"].Value;
                string userType = "Null";
                if (userTypeValue != DBNull.Value)
                {
                    userType = userTypeValue.ToString();
                    if (!string.IsNullOrEmpty(userType))
                    {
                        Console.WriteLine("User type: " + userType);
                    }
                    else
                    {
                        Console.WriteLine("User not found or invalid login.");
                    }
                }
                else
                {
                    Console.WriteLine("User type is DBNull.Value (null in database). Handle this case as needed.");
                }

                Comando.Parameters.Clear();
                Cnn.conexion.Close();

                return userType;
            }
            catch (Exception)
            {
                return "Error";
                throw;
            }
        }

    }
}
