using System.ComponentModel.DataAnnotations;

namespace CapaEntidades
{
	public class Menu
	{
		public int Id { get; set; }
		[Display(Name = "Descripcion de Menu")]
		public string Descripcion { get; set; }
		[Display(Name = "Precio de Menu")]
		[DisplayFormat(DataFormatString = "{0:0.00}")]
		public decimal Precio { get; set; }
	}
}
