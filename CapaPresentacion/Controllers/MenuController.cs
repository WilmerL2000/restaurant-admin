using CapaEntidades;
using CapaLogicaNegocio.Implementacion;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
	public class MenuController : Controller
	{
		private readonly MenuLN menuLN = new MenuLN();
		// GET: Menu
		public ActionResult Index()
		{
			return View(menuLN.ListarMenu());
		}

		// GET: Menu/Details/5
		public ActionResult Details(int id)
		{

			return View();
		}

		// GET: Menu/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Menu/Create
		[HttpPost]
		public ActionResult Create(Menu menu)
		{
			try
			{
				menuLN.InsertarMenu(menu);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Menu/Edit/5
		public ActionResult Edit(int id)
		{
			var menu = menuLN.ObtenerMenu(id);

			if (menu == null) return RedirectToAction("Index");

			return View(menu);

		}

		// POST: Menu/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Menu menu)
		{
			try
			{
				menuLN.ActualizarMenu(id, menu);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Menu/Delete/5
		public ActionResult Delete(int id)
		{
			var menu = menuLN.ObtenerMenu(id);

			if (menu == null) return RedirectToAction("Index");

			return View(menu);
		}

		// POST: Menu/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{

				var menu = menuLN.ObtenerMenu(id);

				if (menu == null) return RedirectToAction("Index");

				menuLN.EliminarMenu(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
