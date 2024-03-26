using System.ComponentModel.DataAnnotations;

namespace CapaEntidades
{
	public class Cliente
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public string Telefono { get; set; }
		[Display(Name = "Correo electronico")]
		public string CorreoElectronico { get; set; }
	}
}
