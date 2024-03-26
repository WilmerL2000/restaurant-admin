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
			throw new NotImplementedException();
		}

		public List<Reservacion> ListarReservacion()
		{
			throw new NotImplementedException();
		}

		public Reservacion ObtenerReservacion(int NumeroReservacion)
		{
			throw new NotImplementedException();
		}
	}
}
