using System.ComponentModel.DataAnnotations;

namespace CapaEntidades
{
	public class Mesa
	{
		public int Id { get; set; }
		[Display(Name = "Numero de Mesa")]
		public int NumeroMesa { get; set; }
		public string Descripcion { get; set; }
	}
}
