using CapaEntidades;
using CapaLogicaNegocio.Implementacion;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
	public class ReservacionController : Controller
	{
		private readonly ReservacionLN reservacionLN = new ReservacionLN();
		private readonly ClienteLN clienteLN = new ClienteLN();
		private readonly MenuLN menuLN = new MenuLN();
		private readonly MesaLN mesaLN = new MesaLN();

		// GET: Reservacion
		public ActionResult Index()
		{
			return View(reservacionLN.ListarReservacion());
		}

		// GET: Reservacion/Details/5
		public ActionResult Details(int NumeroReservacion)
		{

			return View(reservacionLN.ObtenerReservacion(NumeroReservacion));
		}

		// GET: Reservacion/Create
		public ActionResult Create()
		{
			CargarVistaValores();

			return View();
		}

		// POST: Reservacion/Create
		[HttpPost]
		public ActionResult Create(Reservacion reservacion)
		{
			try
			{
				reservacionLN.InsertarReservacion(reservacion);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Reservacion/Edit/5
		public ActionResult Edit(int NumeroReservacion)
		{
			CargarVistaValores();

			var reservacion = reservacionLN.ObtenerReservacion(NumeroReservacion);

			if (reservacion == null) return RedirectToAction("Index");

			return View(reservacion);
		}

		// POST: Reservacion/Edit/5
		[HttpPost]
		public ActionResult Edit(int NumeroReservacion, Reservacion reservacion)
		{
			try
			{
				reservacionLN.ActualizarReservacion(NumeroReservacion, reservacion);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Reservacion/Delete/5
		public ActionResult Delete(int NumeroReservacion)
		{
			var reservacion = reservacionLN.ObtenerReservacion(NumeroReservacion);

			if (reservacion == null) return RedirectToAction("Index");

			return View(reservacion);
		}

		// POST: Reservacion/Delete/5
		[HttpPost]
		public ActionResult Delete(int NumeroReservacion, FormCollection collection)
		{
			try
			{
				reservacionLN.EliminarReservacion(NumeroReservacion);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		private void CargarVistaValores()
		{
			ViewBag.Clientes = new SelectList(clienteLN.ListarClientes(), "Id", "Nombre"); ;
			ViewBag.Menus = new SelectList(menuLN.ListarMenu(), "Id", "Descripcion"); ;
			ViewBag.Mesas = new SelectList(mesaLN.ListarMesa(), "NumeroMesa", "Descripcion"); ;
		}
	}
}
