using CapaAccesoDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos.Implementacion
{
	public class ClienteAD : IClienteAD
	{
		public bool ActualizarCliente(int idCliente, Cliente cliente)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ActualizarCliente", conexion))
					{
						cmd.Parameters.AddWithValue("@Id", idCliente);
						cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
						cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
						cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
						cmd.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico);
						cmd.CommandType = CommandType.StoredProcedure;


						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								int filasAfectadas = cmd.ExecuteNonQuery();

								if (filasAfectadas > 0) respuesta = true;
							}

							return respuesta;
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public bool EliminarCliente(int IdCliente)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("EliminarCliente", conexion))
					{
						cmd.Parameters.AddWithValue("@Id", IdCliente);
						cmd.CommandType = CommandType.StoredProcedure;


						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								int filasAfectadas = cmd.ExecuteNonQuery();

								if (filasAfectadas > 0) respuesta = true;
							}

							return respuesta;

						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}


			}
		}

		public bool InsertarCliente(Cliente cliente)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("InsertarCliente", conexion))
					{
						cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
						cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
						cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
						cmd.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico);
						cmd.CommandType = CommandType.StoredProcedure;

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								int filasAfectadas = cmd.ExecuteNonQuery();

								if (filasAfectadas > 0) respuesta = true;
							}

							return respuesta;

						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public List<Cliente> ListarClientes()
		{
			List<Cliente> lista = new List<Cliente>();

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ObtenerClientes", conexion))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								while (reader.Read())
								{
									lista.Add(new Cliente
									{
										Id = Convert.ToInt32(reader["Id"].ToString()),
										Nombre = reader["Nombre"].ToString(),
										Apellidos = reader["Apellidos"].ToString(),
										Telefono = reader["Telefono"].ToString(),
										CorreoElectronico = reader["CorreoElectronico"].ToString()
									});
								}
							}
						}

						return lista;
					};
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public Cliente ObtenerCliente(int IdCliente)
		{
			Cliente mesa = new Cliente();

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ObtenerClientePorId", conexion))
					{
						cmd.Parameters.AddWithValue("@Id", IdCliente);
						cmd.CommandType = CommandType.StoredProcedure;


						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								mesa.Id = Convert.ToInt32(reader["Id"].ToString());
								mesa.Nombre = reader["Nombre"].ToString();
								mesa.Apellidos = reader["Apellidos"].ToString();
								mesa.Telefono = reader["Telefono"].ToString();
								mesa.CorreoElectronico = reader["CorreoElectronico"].ToString();
							}
						}

						return mesa;
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
	}
}
