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
    public class CSubasta
    {
        OracleCommand Comando = new OracleCommand();

        public bool InsertarSubasta(Subasta c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_subasta";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = c.Ventaid });
                Comando.Parameters.Add(new OracleParameter("p_fechainicio", OracleDbType.Date) { Value = c.Fechainicio });
                Comando.Parameters.Add(new OracleParameter("p_fechatermino", OracleDbType.Date) { Value = c.Fechatermino });
                Comando.Parameters.Add(new OracleParameter("p_ancho", OracleDbType.Single) { Value = c.Ancho_min });
                Comando.Parameters.Add(new OracleParameter("p_largo", OracleDbType.Single) { Value = c.Largo_min });
                Comando.Parameters.Add(new OracleParameter("p_alto", OracleDbType.Single) { Value = c.Alto_min });
                Comando.Parameters.Add(new OracleParameter("p_capacidad", OracleDbType.Single) { Value = c.Capacidad });
                Comando.Parameters.Add(new OracleParameter("p_refrigerado", OracleDbType.Int32) { Value = c.Refrigerado });
                try
                {
                    Comando.ExecuteNonQuery();
                    Comando.Parameters.Clear();
                    Cnn.conexion.Close();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Comando.Parameters.Clear();
                    Cnn.conexion.Close();
                    return false;
                }
                
                
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Subasta> GetAllSubasta()
        {
            List<Subasta> subastaList = new List<Subasta>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_subasta; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Subasta subasta = new Subasta
                                {
                                    Subastaid = Convert.ToInt32(reader["SubastaId"]),
                                    Ventaid = Convert.ToInt32(reader["VentaId"]),
                                    Fechainicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    Fechatermino = Convert.ToDateTime(reader["FechaTermino"]),
                                    Ancho_min = Convert.ToSingle(reader["Ancho_min"]),
                                    Largo_min = Convert.ToSingle(reader["Largo_min"]),
                                    Alto_min = Convert.ToSingle(reader["Alto_min"]),
                                    Capacidad = Convert.ToSingle(reader["Capacidad"]),
                                    Refrigerado = Convert.ToInt32(reader["Refrigerado"]),
                                    Finished = Convert.ToInt32(reader["Finished"])

                                };

                                subastaList.Add(subasta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return subastaList;
        }

        public List<Subasta> GetUnfinishedSubasta()
        {
            List<Subasta> subastaList = new List<Subasta>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_unfinished_subasta; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Subasta subasta = new Subasta
                                {
                                    Subastaid = Convert.ToInt32(reader["SubastaId"]),
                                    Ventaid = Convert.ToInt32(reader["VentaId"]),
                                    Fechainicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    Fechatermino = Convert.ToDateTime(reader["FechaTermino"]),
                                    Ancho_min = Convert.ToSingle(reader["Ancho_min"]),
                                    Largo_min = Convert.ToSingle(reader["Largo_min"]),
                                    Alto_min = Convert.ToSingle(reader["Alto_min"]),
                                    Capacidad = Convert.ToSingle(reader["Capacidad"]),
                                    Refrigerado = Convert.ToInt32(reader["Refrigerado"]),
                                    Finished = Convert.ToInt32(reader["Finished"])

                                };

                                subastaList.Add(subasta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return subastaList;
        }

        public List<SuperSubasta> GetSuperSubasta()
        {
            List<SuperSubasta> subastaList = new List<SuperSubasta>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_super_subasta; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SuperSubasta subasta = new SuperSubasta
                                {
                                    Subastaid = Convert.ToInt32(reader["SubastaId"]),
                                    Ventaid = Convert.ToInt32(reader["VentaId"]),
                                    Fechainicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    Fechatermino = Convert.ToDateTime(reader["FechaTermino"]),
                                    Ancho_min = Convert.ToSingle(reader["Ancho_min"]),
                                    Largo_min = Convert.ToSingle(reader["Largo_min"]),
                                    Alto_min = Convert.ToSingle(reader["Alto_min"]),
                                    Capacidad = Convert.ToSingle(reader["Capacidad"]),
                                    Refrigerado = Convert.ToInt32(reader["Refrigerado"]),
                                    Finished = Convert.ToInt32(reader["Finished"]),
                                    Origen = reader["Origen"].ToString(),
                                    Destino = reader["Destino"].ToString()

                                };

                                subastaList.Add(subasta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return subastaList;
        }
        public Subasta GetSubastaById(int subastaId)
        {
            Subasta subasta = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_subasta_by_id(:p_subastaid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_subastaid", OracleDbType.Int32).Value = subastaId;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                subasta = new Subasta
                                {
                                    Subastaid = Convert.ToInt32(reader["SubastaId"]),
                                    Ventaid = Convert.ToInt32(reader["VentaId"]),
                                    Fechainicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    Fechatermino = Convert.ToDateTime(reader["FechaTermino"]),
                                    Ancho_min = Convert.ToSingle(reader["Ancho_min"]),
                                    Largo_min = Convert.ToSingle(reader["Largo_min"]),
                                    Alto_min = Convert.ToSingle(reader["Alto_min"]),
                                    Finished = Convert.ToInt32(reader["Finished"])
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

            return subasta;
        }


        public bool ActualizarSubasta(Subasta c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_subasta";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_subastaid", OracleDbType.Int32) { Value = c.Subastaid });
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = c.Ventaid });
                Comando.Parameters.Add(new OracleParameter("p_fechainicio", OracleDbType.Date) { Value = c.Fechainicio });
                Comando.Parameters.Add(new OracleParameter("p_fechatermino", OracleDbType.Date) { Value = c.Fechatermino });
                Comando.Parameters.Add(new OracleParameter("p_ancho", OracleDbType.Single) { Value = c.Ancho_min });
                Comando.Parameters.Add(new OracleParameter("p_largo", OracleDbType.Single) { Value = c.Largo_min });
                Comando.Parameters.Add(new OracleParameter("p_alto", OracleDbType.Single) { Value = c.Alto_min });
                Comando.Parameters.Add(new OracleParameter("p_capacidad", OracleDbType.Single) { Value = c.Capacidad });
                Comando.Parameters.Add(new OracleParameter("p_refrigerado", OracleDbType.Int32) { Value = c.Refrigerado });
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

        public bool FinalizarSubasta(int subastaid, int finished)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "finish_subasta";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_subastaid", OracleDbType.Int32) { Value = subastaid });
                Comando.Parameters.Add(new OracleParameter("p_finished", OracleDbType.Int32) { Value = finished });
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

        public bool EliminarSubasta(int id)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_subasta";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_subastaid", OracleDbType.Int32) { Value = id });
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

        public bool InsertarSubastaMedio(Subasta_Medio c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_subasta_medio";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_medioid", OracleDbType.Int32) { Value = c.Medioid });
                Comando.Parameters.Add(new OracleParameter("p_subastaid", OracleDbType.Int32) { Value = c.Subastaid });
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

        public bool EliminarSubastaMedio(int idmedio, int idsubasta)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_subasta_medio";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_medioid", OracleDbType.Int32) { Value = idmedio });
                Comando.Parameters.Add(new OracleParameter("p_subastaid", OracleDbType.Int32) { Value = idsubasta });
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

        public bool ActualizarSubastaMedio(Subasta_Medio c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_subasta_medio";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_medioid", OracleDbType.Int32) { Value = c.Medioid });
                Comando.Parameters.Add(new OracleParameter("p_subastaid", OracleDbType.Int32) { Value = c.Subastaid });
                Comando.Parameters.Add(new OracleParameter("p_selected", OracleDbType.Int32) { Value = c.Selected });
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

    }
}
