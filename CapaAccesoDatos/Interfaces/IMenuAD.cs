using CapaEntidades;
using System.Collections.Generic;

namespace CapaAccesoDatos.Interfaces
{
	interface IMenuAD
	{
		List<Menu> ListarMenus();
		Menu ObtenerMenu(int IdMenu);

		bool InsertarMenu(Menu menu);
		bool ActualizarMenu(int idMenu, Menu menu);
		bool EliminarMenu(int IdMenu);
	}
}
