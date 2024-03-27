using System.ComponentModel.DataAnnotations;

namespace CapaEntidades
{
	public class Menu
	{
		public int Id { get; set; }
		[Display(Name = "Descripcion de Menu")]
		public string Descripcion { get; set; }
		[Display(Name = "Precio de Menu")]
		public decimal Precio { get; set; }
	}
}
