using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection;
using Models;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Controller
{
    public class CPostulacion
    {
        OracleCommand Comando = new OracleCommand();

        public bool InsertarPostulacion(Postulacion c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_postulacion";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_precio", OracleDbType.Decimal) { Value = c.Precio });
                Comando.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32) { Value = c.Cantidad });
                Comando.Parameters.Add(new OracleParameter("p_fechacosecha", OracleDbType.Date) { Value = c.Fechacosecha });
                Comando.Parameters.Add(new OracleParameter("p_contratoid", OracleDbType.Int32) { Value = c.Contratoid });
                Comando.Parameters.Add(new OracleParameter("p_productorid", OracleDbType.Int32) { Value = c.Productorid });

                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Postulacion> GetAllPostulacion()
        {
            List<Postulacion> postulacionList = new List<Postulacion>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_postulaciones; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        try{
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Postulacion postulacion = new Postulacion
                                    {
                                        Postulacionid = Convert.ToInt32(reader["PostulacionId"]),
                                        Precio = reader["Precio"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["Precio"]),
                                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                        Fechacosecha = reader["FechaCosecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaCosecha"]),
                                        Contratoid = Convert.ToInt32(reader["ContratoId"]),
                                        Productorid = Convert.ToInt32(reader["ProductorId"]),
                                        Selected = Convert.ToInt32(reader["Selected"])
                                    };

                                    postulacionList.Add(postulacion);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            Cnn.conexion.Close();
            return postulacionList;
        }

        public Postulacion GetPostulacionById(int postulacionId)
        {
            Postulacion postulacion = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_postulacion_by_id(:p_postulacion_id); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_postulacion_id", OracleDbType.Int32).Value = postulacionId;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                postulacion = new Postulacion
                                {
                                    Postulacionid = Convert.ToInt32(reader["PostulacionId"]),
                                    Precio = reader["Precio"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["Precio"]),
                                    Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                    Fechacosecha = reader["FechaCosecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaCosecha"]),
                                    Contratoid = Convert.ToInt32(reader["ContratoId"]),
                                    Productorid = Convert.ToInt32(reader["ProductorId"]),
                                    Selected = Convert.ToInt32(reader["Selected"])
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
            return postulacion;
        }

        public bool ActualizarPostulacion(Postulacion c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_postulacion";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_precio", OracleDbType.Decimal) { Value = c.Precio });
                Comando.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32) { Value = c.Cantidad });
                Comando.Parameters.Add(new OracleParameter("p_fechacosecha", OracleDbType.Date) { Value = c.Fechacosecha });
                Comando.Parameters.Add(new OracleParameter("p_contratoid", OracleDbType.Int32) { Value = c.Contratoid });
                Comando.Parameters.Add(new OracleParameter("p_productorid", OracleDbType.Int32) { Value = c.Productorid });

                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ActualizarPostulacion(int id, int selected)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "set_selected_postulacion";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_postulacionid", OracleDbType.Int32) { Value = id });
                Comando.Parameters.Add(new OracleParameter("p_selected", OracleDbType.Int32) { Value = selected });

                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool EliminarPostulacion(int id)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_postulacion";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_postulacionid", OracleDbType.Int32) { Value = id });
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public List<Postulacion> GetPostulacionByCon(int contratoId)
        {
            List<Postulacion> postulacionList = new List<Postulacion>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_postulacion_by_contract(:p_contratoid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_contratoid", OracleDbType.Int32).Value = contratoId;

                        try
                        {
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Postulacion postulacion = new Postulacion
                                    {
                                        Postulacionid = Convert.ToInt32(reader["PostulacionId"]),
                                        Precio = reader["Precio"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["Precio"]),
                                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                        Fechacosecha = reader["FechaCosecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaCosecha"]),
                                        Contratoid = Convert.ToInt32(reader["ContratoId"]),
                                        Productorid = Convert.ToInt32(reader["ProductorId"]),
                                        Selected = Convert.ToInt32(reader["Selected"])
                                    };

                                    postulacionList.Add(postulacion);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            Cnn.conexion.Close();
            return postulacionList;
        }

        public List<Postulacion> GetPostulacionByPro(int productorId)
        {
            List<Postulacion> postulacionList = new List<Postulacion>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_postulacion_by_productor(:p_productorid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_productorid", OracleDbType.Int32).Value = productorId;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Postulacion postulacion = new Postulacion
                                {
                                    Postulacionid = Convert.ToInt32(reader["PostulacionId"]),
                                    Precio = reader["Precio"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["Precio"]),
                                    Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                    Fechacosecha = reader["FechaCosecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaCosecha"]),
                                    Contratoid = Convert.ToInt32(reader["ContratoId"]),
                                    Productorid = Convert.ToInt32(reader["ProductorId"]),
                                    Selected = Convert.ToInt32(reader["Selected"])
                                };

                                postulacionList.Add(postulacion);
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
            return postulacionList;
        }

        public List<Postulacion> GetSelectedPostulacion(int contratoid)
        {
            List<Postulacion> postulacionList = new List<Postulacion>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_selected_postulacion(:p_contratoid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_contratoid", OracleDbType.Int32).Value = contratoid;
                        try
                        {
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Postulacion postulacion = new Postulacion
                                    {
                                        Postulacionid = Convert.ToInt32(reader["PostulacionId"]),
                                        Precio = reader["Precio"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["Precio"]),
                                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                        Fechacosecha = reader["FechaCosecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaCosecha"]),
                                        Contratoid = Convert.ToInt32(reader["ContratoId"]),
                                        Productorid = Convert.ToInt32(reader["ProductorId"]),
                                        Selected = Convert.ToInt32(reader["Selected"])
                                    };

                                    postulacionList.Add(postulacion);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            Cnn.conexion.Close();
            return postulacionList;
        }
    }
}
