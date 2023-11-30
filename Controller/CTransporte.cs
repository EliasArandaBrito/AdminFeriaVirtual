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
    public class CTransporte
    {
        OracleCommand Comando = new OracleCommand();

        public bool InsertarTransporte(Transporte c, int ventaid)
        {
            Connection Cnn = new Connection();
            try
            {
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_new_transporte";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_tipotransporte", OracleDbType.Varchar2) { Value = c.Tipotransporte });
                Comando.Parameters.Add(new OracleParameter("p_fechatransporte", OracleDbType.Date) { Value = c.Fechatransporte });
                Comando.Parameters.Add(new OracleParameter("p_origen", OracleDbType.Varchar2) { Value = c.Origen });
                Comando.Parameters.Add(new OracleParameter("p_destino", OracleDbType.Varchar2) { Value = c.Destino });
                Comando.Parameters.Add(new OracleParameter("p_estadotransporte", OracleDbType.Varchar2) { Value = c.Estadotransporte });
                Comando.Parameters.Add(new OracleParameter("p_medioid", OracleDbType.Int32) { Value = c.Medioid });
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = ventaid });
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Transporte> GetAllTransporte()
        {
            List<Transporte> transporteList = new List<Transporte>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_transporte; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transporte transporte = new Transporte
                                {
                                    Transporteid = Convert.ToInt32(reader["TransporteId"]),
                                    Tipotransporte = reader["TipoTransporte"].ToString(),
                                    Fechatransporte = Convert.ToDateTime(reader["FechaTransporte"]),
                                    Origen = reader["Origen"].ToString(),
                                    Destino = reader["Destino"].ToString(),
                                    Estadotransporte = reader["EstadoTransporte"].ToString(),
                                    Medioid = Convert.ToInt32(reader["MedioId"])
                                };

                                transporteList.Add(transporte);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return transporteList;
        }

        public Transporte GetTransporteById(int transporteId)
        {
            Transporte transporte = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_transporte_by_id(:p_transporteid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_transporteid", OracleDbType.Int32).Value = transporteId;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                transporte = new Transporte
                                {
                                    Transporteid = Convert.ToInt32(reader["TransporteId"]),
                                    Tipotransporte = reader["TipoTransporte"].ToString(),
                                    Fechatransporte = Convert.ToDateTime(reader["FechaTransporte"]),
                                    Origen = reader["Origen"].ToString(),
                                    Destino = reader["Destino"].ToString(),
                                    Estadotransporte = reader["EstadoTransporte"].ToString(),
                                    Medioid = Convert.ToInt32(reader["MedioId"])
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

            return transporte;
        }

        public bool ActualizarTransporte(Transporte c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_transporte";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_medioid", OracleDbType.Int32) { Value = c.Transporteid });
                Comando.Parameters.Add(new OracleParameter("p_tipotransporte", OracleDbType.Varchar2) { Value = c.Tipotransporte });
                Comando.Parameters.Add(new OracleParameter("p_fechatransporte", OracleDbType.Date) { Value = c.Fechatransporte });
                Comando.Parameters.Add(new OracleParameter("p_origen", OracleDbType.Varchar2) { Value = c.Origen });
                Comando.Parameters.Add(new OracleParameter("p_destino", OracleDbType.Varchar2) { Value = c.Destino });
                Comando.Parameters.Add(new OracleParameter("p_estadotransporte", OracleDbType.Varchar2) { Value = c.Estadotransporte });
                Comando.Parameters.Add(new OracleParameter("p_medioid", OracleDbType.Int32) { Value = c.Medioid });
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

        public bool EliminarTransporte(int id)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_transporte";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_transporteid", OracleDbType.Int32) { Value = id });
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
    }
}
