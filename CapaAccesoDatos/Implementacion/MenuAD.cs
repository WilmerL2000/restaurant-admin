using CapaAccesoDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos.Implementacion
{
	public class MenuAD : IMenuAD
	{
		private readonly ProyectoRestauranteEntities _restaurante;
		public List<Menu> ListarMenus()
		{
			List<Menu> lista = new List<Menu>();

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ObtenerMenu", conexion))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								while (reader.Read())
								{
									lista.Add(new Menu
									{
										Id = Convert.ToInt32(reader["Id"].ToString()),
										Descripcion = reader["Descripcion"].ToString(),
										Precio = (decimal)reader["Precio"]
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

		public Menu ObtenerMenu(int IdMenu)
		{
			Menu menu = new Menu();

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ObtenerMenuItemPorId", conexion))
					{
						cmd.Parameters.AddWithValue("@Id", IdMenu);
						cmd.CommandType = CommandType.StoredProcedure;

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.HasRows)
							{
								if (reader.Read())
								{
									menu.Id = Convert.ToInt32(reader["Id"].ToString());
									menu.Descripcion = reader["Descripcion"].ToString();
									menu.Precio = (decimal)reader["Precio"];
								}
							}
						}
						return menu;
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public bool InsertarMenu(Menu menu)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("InsertarMenuItem", conexion))
					{
						cmd.Parameters.AddWithValue("@Descripcion", menu.Descripcion);
						cmd.Parameters.AddWithValue("@Precio", menu.Precio);
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

		public bool ActualizarMenu(int idMenu, Menu menu)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("ActualizarMenuItem", conexion))
					{

						cmd.Parameters.AddWithValue("@Id", idMenu);
						cmd.Parameters.AddWithValue("@Descripcion", menu.Descripcion);
						cmd.Parameters.AddWithValue("@Precio", menu.Precio);
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

		public bool EliminarMenu(int IdMenu)
		{
			bool respuesta = false;

			using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
			{
				try
				{
					conexion.Open();

					using (SqlCommand cmd = new SqlCommand("EliminarMenuItem", conexion))
					{
						cmd.Parameters.AddWithValue("@Id", IdMenu);
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
	}
}
