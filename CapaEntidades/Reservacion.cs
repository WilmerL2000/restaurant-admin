using System;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidades
{
	public class Reservacion
	{
		[Display(Name = "Numero de Reservacion")]
		public int NumeroReservacion { get; set; }
		[Display(Name = "Correo de Cliente")]
		public int IdCliente { get; set; }
		[Display(Name = "Numero de Mesa")]
		public int NumeroMesa { get; set; }
		[Display(Name = "Descripcion de Menu")]
		public int IdMenu { get; set; }
		public int Cantidad { get; set; }
		[Display(Name = "Fecha de Reservacion")]
		[DataType(DataType.DateTime)]
		public DateTime FechaReservacion { get; set; }

		public virtual Cliente Clientes { get; set; }
		public virtual Menu Menu { get; set; }
		public virtual Mesa Mesas { get; set; }
	}
}
