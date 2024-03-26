using CapaEntidades;
using System.Collections.Generic;

namespace CapaAccesoDatos.Interfaces
{
	interface IMesaAD
	{
		List<Mesa> ListarMesas();
		Mesa ObtenerMesa(int IdMesa);

		bool InsertarMesa(Mesa mesa);
		bool ActualizarMesa(int IdMesa, Mesa mesa);
		bool EliminarMesa(int IdMesa);
	}
}
