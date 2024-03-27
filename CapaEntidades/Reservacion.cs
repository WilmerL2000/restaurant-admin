using System;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidades
{
	public class Reservacion
	{
		[Display(Name = "Reservacion #")]
		public int NumeroReservacion { get; set; }
		[Display(Name = "Nombre de Cliente")]
		public int IdCliente { get; set; }
		[Display(Name = "Numero de Mesa")]
		public int NumeroMesa { get; set; }
		[Display(Name = "Descripcion de Menu")]
		public int IdMenu { get; set; }
		public int Cantidad { get; set; }
		[Display(Name = "Fecha de Reservacion")]
		[DataType(DataType.DateTime)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime FechaReservacion { get; set; }

		public Cliente Cliente { get; set; }
		public Menu Menu { get; set; }
		public Mesa Mesa { get; set; }
	}
}
