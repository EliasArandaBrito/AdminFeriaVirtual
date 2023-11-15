using DBConnection;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Controller
{
    public class CSubusuario
    {
        OracleCommand Comando = new OracleCommand();
        public List<Cliente> GetAllClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {

                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_clientes; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cliente cliente = new Cliente
                                {
                                    Clienteid = Convert.ToInt32(reader["Clienteid"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Tipocliente = reader["Tipocliente"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Correo = reader["Correo"].ToString()
                                    // Add other properties as needed
                                };

                                clientes.Add(cliente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return clientes;
        }

        public Cliente GetClienteById(int clientId)
        {
            Cliente cliente = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_cliente_by_id(:id); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("id", OracleDbType.Int32, clientId, ParameterDirection.Input);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cliente = new Cliente
                                {
                                    Clienteid = Convert.ToInt32(reader["Clienteid"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Tipocliente = reader["Tipocliente"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Correo = reader["Correo"].ToString()
                                    // Add other properties as needed
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

            return cliente;
        }

        public Productor GetProductorById(int? productorid)
        {
            throw new NotImplementedException();
        }

        public List<Productor> GetAllProductores()
        {
            List<Productor> productores = new List<Productor>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_productores; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Productor productor = new Productor
                                {
                                    Productorid = Convert.ToInt32(reader["Productorid"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Correo = reader["Correo"].ToString()
                                };

                                productores.Add(productor);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return productores;
        }

        public Productor GetProductorById(int productorId)
        {
            Productor productor = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_productor_by_id(:id); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("id", OracleDbType.Int32, productorId, ParameterDirection.Input);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productor = new Productor
                                {
                                    Productorid = Convert.ToInt32(reader["Productorid"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Correo = reader["Correo"].ToString()
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

            return productor;
        }

        public List<Transportista> GetAllTransportistas()
        {
            List<Transportista> transportistas = new List<Transportista>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_transportistas; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transportista transportista = new Transportista
                                {
                                    Transportistaid = Convert.ToInt32(reader["Transportistaid"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Correo = reader["Correo"].ToString()
                                };

                                transportistas.Add(transportista);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return transportistas;
        }

        public Transportista GetTransportistaById(int transportistaId)
        {
            Transportista transportista = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_transportista_by_id(:id); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("id", OracleDbType.Int32, transportistaId, ParameterDirection.Input);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                transportista = new Transportista
                                {
                                    Transportistaid = Convert.ToInt32(reader["Transportistaid"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Correo = reader["Correo"].ToString()
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

            return transportista;
        }

    }
}
