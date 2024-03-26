using CapaEntidades;
using System.Collections.Generic;

namespace CapaLogicaNegocio.Interfaces
{
	internal interface IMenuLN
	{
		List<Menu> ListarMenu();
		Menu ObtenerMenu(int IdMenu);

		bool InsertarMenu(Menu menu);
		bool ActualizarMenu(int idMenu, Menu menu);
		bool EliminarMenu(int IdMenu);
	}
}
