using CapaAccesoDatos.Implementacion;
using CapaEntidades;
using CapaLogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaLogicaNegocio.Implementacion
{
	public class ReservacionLN : IReservacionLN
	{
		private readonly ReservacionAD reservacionAD = new ReservacionAD();
		public bool ActualizarReservacion(int NumeroReservacion, Reservacion reservacion)
		{
			try
			{
				var reservacionEncontrada = reservacionAD.ObtenerReservacion(NumeroReservacion);

				return reservacion == null ? throw new OperationCanceledException("La reservacion no existe no existe") : reservacionAD.ActualizarReservacion(NumeroReservacion, reservacion);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool EliminarReservacion(int NumeroReservacion)
		{
			try
			{
				var reservacionEncontrada = reservacionAD.ObtenerReservacion(NumeroReservacion);

				return reservacionEncontrada == null ? throw new OperationCanceledException("La reservacion no existe no existe") : reservacionAD.EliminarReservacion(NumeroReservacion);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool InsertarReservacion(Reservacion reservacion)
		{
			try
			{
				return reservacionAD.InsertarReservacion(reservacion);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Reservacion> ListarReservacion()
		{
			try
			{
				return reservacionAD.ListarReservacion();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Reservacion ObtenerReservacion(int NumeroReservacion)
		{
			try
			{
				return reservacionAD.ObtenerReservacion(NumeroReservacion);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
