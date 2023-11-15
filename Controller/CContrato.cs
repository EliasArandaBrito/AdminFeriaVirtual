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
    public class CContrato
    {
        OracleCommand Comando = new OracleCommand();

        public bool InsertarContrato(Contrato c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_contrato";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_fechainicio", OracleDbType.Date) { Value = c.Fechainicio });
                Comando.Parameters.Add(new OracleParameter("p_fechafinalizacion", OracleDbType.Date) { Value = c.Fechafinalizacion });
                Comando.Parameters.Add(new OracleParameter("p_tipocontrato", OracleDbType.Varchar2) { Value = c.Tipocontrato });
                Comando.Parameters.Add(new OracleParameter("p_estadocontratoid", OracleDbType.Int32) { Value = c.Estadocontratoid });
                Comando.Parameters.Add(new OracleParameter("p_demanda", OracleDbType.Varchar2) { Value = c.Demanda });
                Comando.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32) { Value = c.Cantidad });
                Comando.Parameters.Add(new OracleParameter("p_usuarioid", OracleDbType.Int32) { Value = c.Usuarioid });
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

        public List<Contrato> GetAllContratos()
        {
            List<Contrato> contratos = new List<Contrato>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_contratos; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contrato contrato = new Contrato
                                {
                                    Contratoid = Convert.ToInt32(reader["ContratoId"]),
                                    Fechainicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    Fechafinalizacion = Convert.ToDateTime(reader["FechaFinalizacion"]),
                                    Tipocontrato = reader["TipoContrato"].ToString(),
                                    Estadocontratoid = Convert.ToInt32(reader["EstadoContratoId"]),
                                    Demanda = reader["Demanda"].ToString(),
                                    Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                    Usuarioid = Convert.ToInt32(reader["UsuarioId"]),
                                    Published = Convert.ToInt32(reader["Published"])
                                };

                                contratos.Add(contrato);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return contratos;
        }

        public Contrato GetContratoById(int contratoId)
        {
            Contrato contrato = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_contrato_by_id(:p_contrato_id); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_contrato_id", OracleDbType.Int32).Value = contratoId;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                contrato = new Contrato
                                {
                                    Contratoid = Convert.ToInt32(reader["ContratoId"]),
                                    Fechainicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    Fechafinalizacion = Convert.ToDateTime(reader["FechaFinalizacion"]),
                                    Tipocontrato = reader["TipoContrato"].ToString(),
                                    Estadocontratoid = Convert.ToInt32(reader["EstadoContratoId"]),
                                    Demanda = reader["Demanda"].ToString(),
                                    Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                    Usuarioid = Convert.ToInt32(reader["UsuarioId"])
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
            return contrato;
        }



        public bool ActualizarContrato(Contrato c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_contrato";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_contratoid", OracleDbType.Int32) { Value = c.Contratoid });
                Comando.Parameters.Add(new OracleParameter("p_fechainicio", OracleDbType.Date) { Value = c.Fechainicio });
                Comando.Parameters.Add(new OracleParameter("p_fechafinalizacion", OracleDbType.Date) { Value = c.Fechafinalizacion });
                Comando.Parameters.Add(new OracleParameter("p_tipocontrato", OracleDbType.Varchar2) { Value = c.Tipocontrato });
                Comando.Parameters.Add(new OracleParameter("p_estadocontratoid", OracleDbType.Int32) { Value = c.Estadocontratoid });
                Comando.Parameters.Add(new OracleParameter("p_demanda", OracleDbType.Varchar2) { Value = c.Demanda });
                Comando.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32) { Value = c.Cantidad });
                Comando.Parameters.Add(new OracleParameter("p_usuarioid", OracleDbType.Int32) { Value = c.Usuarioid });
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

        public bool EliminarContrato(int id)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_contrato";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_contratoid", OracleDbType.Int32) { Value = id });
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

        public bool PublicarContrato(int id, int publish)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "publish_contrato";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_contratoid", OracleDbType.Int32) { Value = id });
                Comando.Parameters.Add(new OracleParameter("p_published", OracleDbType.Int32) { Value = publish });
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

        public List<Contrato> GetPublishedContratos()
        {
            List<Contrato> contratos = new List<Contrato>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_published_contratos; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contrato contrato = new Contrato
                                {
                                    Contratoid = Convert.ToInt32(reader["ContratoId"]),
                                    Fechainicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    Fechafinalizacion = Convert.ToDateTime(reader["FechaFinalizacion"]),
                                    Tipocontrato = reader["TipoContrato"].ToString(),
                                    Estadocontratoid = Convert.ToInt32(reader["EstadoContratoId"]),
                                    Demanda = reader["Demanda"].ToString(),
                                    Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                    Usuarioid = Convert.ToInt32(reader["UsuarioId"]),
                                    Published = Convert.ToInt32(reader["Published"])
                                };

                                contratos.Add(contrato);
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
            return contratos;
        }
    }
}
