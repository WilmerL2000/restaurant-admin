using CapaAccesoDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos.Implementacion
{
	public class MesaAD : IMesaAD
	{
		public bool ActualizarMesa(int IdMesa, Mesa mesa)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ActualizarMesa", conexion))
					{
						cmd.Parameters.AddWithValue("@Id", IdMesa);
						cmd.Parameters.AddWithValue("@NumeroMesa", mesa.NumeroMesa);
						cmd.Parameters.AddWithValue("@Descripcion", mesa.Descripcion);
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

		public bool EliminarMesa(int IdMesa)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("EliminarMesa", conexion))
					{
						cmd.Parameters.AddWithValue("@Id", IdMesa);
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

		public bool InsertarMesa(Mesa mesa)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("InsertarMesa", conexion))
					{
						cmd.Parameters.AddWithValue("@NumeroMesa", mesa.NumeroMesa);
						cmd.Parameters.AddWithValue("@Descripcion", mesa.Descripcion);
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

		public List<Mesa> ListarMesas()
		{
			List<Mesa> lista = new List<Mesa>();

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ObtenerMesas", conexion))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								while (reader.Read())
								{
									lista.Add(new Mesa
									{
										Id = Convert.ToInt32(reader["Id"].ToString()),
										NumeroMesa = Convert.ToInt32(reader["NumeroMesa"].ToString()),
										Descripcion = reader["Descripcion"].ToString(),
									});
								}
							}
						}

						return lista;
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public Mesa ObtenerMesa(int IdMesa)
		{
			Mesa mesa = new Mesa();

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ObtenerMesaPorId", conexion))
					{
						cmd.Parameters.AddWithValue("@Id", IdMesa);
						cmd.CommandType = CommandType.StoredProcedure;

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								if (reader.Read())
								{
									mesa.Id = Convert.ToInt32(reader["Id"].ToString());
									mesa.Descripcion = reader["Descripcion"].ToString();
									mesa.NumeroMesa = Convert.ToInt32(reader["NumeroMesa"].ToString());
								}
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
