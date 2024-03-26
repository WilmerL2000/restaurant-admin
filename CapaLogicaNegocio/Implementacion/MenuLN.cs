using CapaAccesoDatos.Implementacion;
using CapaEntidades;
using CapaLogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaLogicaNegocio.Implementacion
{
	public class MenuLN : IMenuLN
	{
		private readonly MenuAD menuAD = new MenuAD();

		public bool ActualizarMenu(int idMenu, Menu menu)
		{
			try
			{
				var menuEncontrado = menuAD.ObtenerMenu(idMenu);

				return menuEncontrado == null ? throw new OperationCanceledException("El menu no existe") : menuAD.ActualizarMenu(idMenu, menu);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool EliminarMenu(int IdMenu)
		{
			try
			{
				var menuEncontrado = menuAD.ObtenerMenu(IdMenu);

				return menuEncontrado == null ? throw new OperationCanceledException("El menu no existe") : menuAD.EliminarMenu(IdMenu);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool InsertarMenu(Menu menu)
		{
			try
			{
				return (menu.Descripcion == "" || menu.Precio.Equals("")) ?
						throw new OperationCanceledException("Deben llenarse todos los campos") : menuAD.InsertarMenu(menu);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Menu> ListarMenu()
		{
			try
			{
				return menuAD.ListarMenus();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Menu ObtenerMenu(int IdMenu)
		{
			try
			{
				return menuAD.ObtenerMenu(IdMenu);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
