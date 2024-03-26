using CapaEntidades;
using System.Collections.Generic;

namespace CapaAccesoDatos.Interfaces
{
	interface IReservacionAD
	{
		List<Reservacion> ListarReservacion();
		Reservacion ObtenerReservacion(int NumeroReservacion);

		bool InsertarReservacion(Reservacion reservacion);
		bool ActualizarReservacion(int NumeroReservacion, Reservacion reservacion);
		bool EliminarReservacion(int NumeroReservacion);
	}
}
