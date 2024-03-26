using CapaEntidades;
using System.Collections.Generic;

namespace CapaAccesoDatos.Interfaces
{
	interface IClienteAD
	{
		List<Cliente> ListarClientes();
		Cliente ObtenerCliente(int IdCliente);

		bool InsertarCliente(Cliente cliente);
		bool ActualizarCliente(int idCliente, Cliente cliente);
		bool EliminarCliente(int IdCliente);
	}
}
