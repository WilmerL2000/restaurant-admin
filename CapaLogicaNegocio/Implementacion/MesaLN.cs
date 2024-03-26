using CapaAccesoDatos.Implementacion;
using CapaEntidades;
using CapaLogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaLogicaNegocio.Implementacion
{
	public class MesaLN : IMesaLN
	{
		private readonly MesaAD mesaAD = new MesaAD();

		public bool ActualizarMesa(int idMesa, Mesa mesa)
		{
			try
			{
				var menuEncontrado = mesaAD.ObtenerMesa(mesa.Id);

				return menuEncontrado == null ? throw new OperationCanceledException("La mesa no existe no existe") : mesaAD.ActualizarMesa(idMesa, mesa);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public bool EliminarMesa(int IdMesa)
		{
			try
			{
				var menuEncontrado = mesaAD.ObtenerMesa(IdMesa);

				return menuEncontrado == null ? throw new OperationCanceledException("La mesa no existe no existe") : mesaAD.EliminarMesa(IdMesa);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool InsertarMesa(Mesa mesa)
		{
			try
			{
				return (mesa.Descripcion == "" || mesa.NumeroMesa.Equals("")) ?
						throw new OperationCanceledException("Deben llenarse todos los campos") : mesaAD.InsertarMesa(mesa);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Mesa> ListarMesa()
		{
			try
			{
				return mesaAD.ListarMesas();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Mesa ObtenerMesa(int IdMesa)
		{
			try
			{
				return mesaAD.ObtenerMesa(IdMesa);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
