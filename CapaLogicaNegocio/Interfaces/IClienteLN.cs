using CapaEntidades;
using System.Collections.Generic;

namespace CapaLogicaNegocio.Interfaces
{
	internal interface IClienteLN
	{
		List<Cliente> ListarClientes();
		Cliente ObtenerCliente(int IdCliente);

		bool InsertarCliente(Cliente cliente);
		bool ActualizarCliente(int idCliente, Cliente cliente);
		bool EliminarCliente(int IdCliente);
	}
}
