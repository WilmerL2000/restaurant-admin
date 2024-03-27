using CapaAccesoDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos.Implementacion
{
	public class ReservacionAD : IReservacionAD
	{
		public bool ActualizarReservacion(int NumeroReservacion, Reservacion reservacion)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ActualizarReservacion", conexion))
					{
						cmd.Parameters.AddWithValue("@NumeroReservacion", NumeroReservacion);
						cmd.Parameters.AddWithValue("@IdCliente", reservacion.IdCliente);
						cmd.Parameters.AddWithValue("@NumeroMesa", reservacion.NumeroMesa);
						cmd.Parameters.AddWithValue("@IdMenu", reservacion.IdMenu);
						cmd.Parameters.AddWithValue("@Cantidad", reservacion.Cantidad);
						cmd.Parameters.AddWithValue("@FechaReservacion", reservacion.FechaReservacion);

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

		public bool EliminarReservacion(int NumeroReservacion)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("EliminarReservacion", conexion))
					{
						cmd.Parameters.AddWithValue("@NumeroReservacion", NumeroReservacion);
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

		public bool InsertarReservacion(Reservacion reservacion)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("InsertarReservacio", conexion))
					{
						cmd.Parameters.AddWithValue("@IdCliente", reservacion.IdCliente);
						cmd.Parameters.AddWithValue("@NumeroMesa", reservacion.NumeroMesa);
						cmd.Parameters.AddWithValue("@IdMenu", reservacion.IdMenu);
						cmd.Parameters.AddWithValue("@Cantidad", reservacion.Cantidad);
						cmd.Parameters.AddWithValue("@FechaReservacion", reservacion.FechaReservacion);

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

		public List<Reservacion> ListarReservacion()
		{
			List<Reservacion> lista = new List<Reservacion>();

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ObtenerReservaciones", conexion))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								while (reader.Read())
								{
									lista.Add(new Reservacion
									{
										NumeroReservacion = Convert.ToInt32(reader["NumeroReservacion"].ToString()),
										FechaReservacion = (DateTime)reader["FechaReservacion"],
										Cantidad = Convert.ToInt32(reader["Cantidad"].ToString()),
										NumeroMesa = Convert.ToInt32(reader["NumeroMesa"].ToString()),
										Cliente = new Cliente
										{
											Nombre = reader["Nombre"].ToString(),
											Apellidos = reader["Apellidos"].ToString()
										},
										Menu = new Menu
										{
											Descripcion = reader["MenuDescripcion"].ToString()
										}
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

		public Reservacion ObtenerReservacion(int NumeroReservacion)
		{
			Reservacion reservacion = new Reservacion();

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ObtenerReservacionPorNumero", conexion))
					{
						cmd.Parameters.AddWithValue("@NumeroReservacion", NumeroReservacion);
						cmd.CommandType = CommandType.StoredProcedure;

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								if (reader.Read())
								{
									reservacion.NumeroReservacion = NumeroReservacion;
									reservacion.FechaReservacion = (DateTime)reader["FechaReservacion"];
									reservacion.Cantidad = Convert.ToInt32(reader["Cantidad"].ToString());
									reservacion.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
									reservacion.IdMenu = Convert.ToInt32(reader["IdMenu"].ToString());
									reservacion.NumeroMesa = Convert.ToInt32(reader["NumeroMesa"].ToString());
									reservacion.Cliente = new Cliente
									{
										Nombre = reader["Nombre"].ToString(),
										Apellidos = reader["Apellidos"].ToString(),
										CorreoElectronico = reader["CorreoElectronico"].ToString(),
										Telefono = reader["Telefono"].ToString(),
									};
									reservacion.Menu = new Menu
									{
										Descripcion = reader["MenuDescripcion"].ToString(),
										Precio = (decimal)reader["Precio"]
									};
									reservacion.Mesa = new Mesa
									{
										Descripcion = reader["MesaDescripcion"].ToString(),
									};

								}
							}
						}

						return reservacion;
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
