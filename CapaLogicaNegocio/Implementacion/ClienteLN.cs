using CapaAccesoDatos.Implementacion;
using CapaEntidades;
using CapaLogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaLogicaNegocio.Implementacion
{
	public class ClienteLN : IClienteLN
	{
		private readonly ClienteAD clienteAD = new ClienteAD();

		public bool ActualizarCliente(int idCliente, Cliente cliente)
		{
			try
			{
				var clienteEncontrado = clienteAD.ObtenerCliente(idCliente);

				return clienteEncontrado == null ? throw new OperationCanceledException("El cliente no existe no existe") : clienteAD.ActualizarCliente(idCliente, cliente);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool EliminarCliente(int IdCliente)
		{
			try
			{
				var clienteEncontrado = clienteAD.ObtenerCliente(IdCliente);

				return clienteEncontrado == null ? throw new OperationCanceledException("El cliente no existe no existe") : clienteAD.EliminarCliente(IdCliente);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool InsertarCliente(Cliente cliente)
		{
			try
			{
				return clienteAD.InsertarCliente(cliente);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Cliente> ListarClientes()
		{
			try
			{
				return clienteAD.ListarClientes();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Cliente ObtenerCliente(int IdCliente)
		{
			try
			{
				return clienteAD.ObtenerCliente(IdCliente);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
