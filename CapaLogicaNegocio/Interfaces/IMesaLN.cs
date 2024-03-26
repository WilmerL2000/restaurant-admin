using CapaEntidades;
using System.Collections.Generic;

namespace CapaLogicaNegocio.Interfaces
{
	internal interface IMesaLN
	{
		List<Mesa> ListarMesa();
		Mesa ObtenerMesa(int IdMesa);

		bool InsertarMesa(Mesa mesa);
		bool ActualizarMesa(int idMesa, Mesa mesa);
		bool EliminarMesa(int IdMesa);
	}
}
