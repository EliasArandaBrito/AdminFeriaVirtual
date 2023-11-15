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
    public class CMedioTransporte
    {
        OracleCommand Comando = new OracleCommand();

        public bool InsertarMedio(MedioTransporte c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_mediotransporte";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_patente", OracleDbType.Varchar2) { Value = c.Patente });
                Comando.Parameters.Add(new OracleParameter("p_ancho", OracleDbType.Single) { Value = c.Ancho });
                Comando.Parameters.Add(new OracleParameter("p_largo", OracleDbType.Single) { Value = c.Largo });
                Comando.Parameters.Add(new OracleParameter("p_alto", OracleDbType.Single) { Value = c.Alto });
                Comando.Parameters.Add(new OracleParameter("p_capacidad", OracleDbType.Single) { Value = c.Capacidad });
                Comando.Parameters.Add(new OracleParameter("p_refrigerado", OracleDbType.Int32) { Value = c.Refrigerado });
                Comando.Parameters.Add(new OracleParameter("p_precio", OracleDbType.Single) { Value = c.Precio });
                Comando.Parameters.Add(new OracleParameter("p_transportistaid", OracleDbType.Int32) { Value = c.Transportistaid });
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

        public List<MedioTransporte> GetAllMedioTransporte()
        {
            List<MedioTransporte> medioTransporteList = new List<MedioTransporte>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_mediotransporte; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedioTransporte medioTransporte = new MedioTransporte
                                {
                                    Medioid = Convert.ToInt32(reader["MedioId"]),
                                    Patente = reader["Patente"].ToString(),
                                    Ancho = Convert.ToInt32(reader["Ancho"]),
                                    Largo = Convert.ToInt32(reader["Largo"]),
                                    Alto = Convert.ToInt32(reader["Alto"]),
                                    Capacidad = Convert.ToSingle(reader["Capacidad"]),
                                    Refrigerado = Convert.ToInt32(reader["Refrigerado"]),
                                    Precio = Convert.ToSingle(reader["Precio"]),
                                    Transportistaid = Convert.ToInt32(reader["TransportistaId"])
                                };

                                medioTransporteList.Add(medioTransporte);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return medioTransporteList;
        }

        public MedioTransporte GetMedioTransporteById(int medioId)
        {
            MedioTransporte medioTransporte = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_mediotransporte_by_id(:p_medio_id); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_medio_id", OracleDbType.Int32).Value = medioId;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                medioTransporte = new MedioTransporte
                                {
                                    Medioid = Convert.ToInt32(reader["MedioId"]),
                                    Patente = reader["Patente"].ToString(),
                                    Ancho = Convert.ToInt32(reader["Ancho"]),
                                    Largo = Convert.ToInt32(reader["Largo"]),
                                    Alto = Convert.ToInt32(reader["Alto"]),
                                    Capacidad = Convert.ToSingle(reader["Capacidad"]),
                                    Refrigerado = Convert.ToInt32(reader["Refrigerado"]),
                                    Precio = Convert.ToSingle(reader["Precio"]),
                                    Transportistaid = Convert.ToInt32(reader["TransportistaId"])
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

            return medioTransporte;
        }



        public bool ActualizarMedioTransporte(MedioTransporte c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_mediotransporte";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_patente", OracleDbType.Varchar2) { Value = c.Patente });
                Comando.Parameters.Add(new OracleParameter("p_ancho", OracleDbType.Single) { Value = c.Ancho });
                Comando.Parameters.Add(new OracleParameter("p_largo", OracleDbType.Single) { Value = c.Largo });
                Comando.Parameters.Add(new OracleParameter("p_alto", OracleDbType.Single) { Value = c.Alto });
                Comando.Parameters.Add(new OracleParameter("p_capacidad", OracleDbType.Single) { Value = c.Capacidad });
                Comando.Parameters.Add(new OracleParameter("p_refrigerado", OracleDbType.Int32) { Value = c.Refrigerado });
                Comando.Parameters.Add(new OracleParameter("p_precio", OracleDbType.Single) { Value = c.Precio });
                Comando.Parameters.Add(new OracleParameter("p_transportistaid", OracleDbType.Int32) { Value = c.Transportistaid });
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

        public bool EliminarMedioTransporte(int id)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_mediotransporte";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_medioid", OracleDbType.Int32) { Value = id });
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

        public List<Subasta_Medio> GetAllSubMedio()
        {
            List<Subasta_Medio> submedioList = new List<Subasta_Medio>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_submedio; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Subasta_Medio submedio = new Subasta_Medio
                                {
                                    Medioid = Convert.ToInt32(reader["MedioId"]),
                                    Subastaid = Convert.ToInt32(reader["SubastaId"]),
                                    Selected = Convert.ToInt32(reader["Selected"])
                                };

                                submedioList.Add(submedio);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return submedioList;
        }

        public List<Subasta_Medio> GetSubMedioBySub(int subid)
        {
            List<Subasta_Medio> submedioList = new List<Subasta_Medio>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_submedio_by_subasta(:p_subastaid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_subastaid", OracleDbType.Int32).Value = subid;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Subasta_Medio submedio = new Subasta_Medio
                                {
                                    Medioid = Convert.ToInt32(reader["MedioId"]),
                                    Subastaid = Convert.ToInt32(reader["SubastaId"]),
                                    Selected = Convert.ToInt32(reader["Selected"])
                                };

                                submedioList.Add(submedio);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return submedioList;
        }
    }
}
