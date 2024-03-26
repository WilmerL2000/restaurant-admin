using CapaLogicaNegocio.Implementacion;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
	public class ReservacionController : Controller
	{
		private readonly ClienteLN clienteLN = new ClienteLN();
		private readonly MenuLN menuLN = new MenuLN();
		private readonly MesaLN mesaLN = new MesaLN();

		// GET: Reservacion
		public ActionResult Index()
		{
			return View();
		}

		// GET: Reservacion/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Reservacion/Create
		public ActionResult Create()
		{

			var clienteData = new SelectList(clienteLN.ListarClientes(), "Id", "Nombre");
			var menusData = new SelectList(menuLN.ListarMenu(), "Id", "Descripcion");
			var mesaData = new SelectList(mesaLN.ListarMesa(), "NumeroMesa", "NumeroMesa");

			ViewBag.Clientes = clienteData;
			ViewBag.Menus = menusData;
			ViewBag.Mesas = mesaData;
			return View();
		}

		// POST: Reservacion/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Reservacion/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Reservacion/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Reservacion/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Reservacion/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
