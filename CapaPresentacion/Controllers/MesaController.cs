using CapaEntidades;
using CapaLogicaNegocio.Implementacion;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
	public class MesaController : Controller
	{
		private readonly MesaLN mesaLN = new MesaLN();
		// GET: Mesa
		public ActionResult Index()
		{
			return View(mesaLN.ListarMesa());
		}

		// GET: Mesa/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Mesa/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Mesa/Create
		[HttpPost]
		public ActionResult Create(Mesa mesa)
		{
			try
			{
				mesaLN.InsertarMesa(mesa);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Mesa/Edit/5
		public ActionResult Edit(int id)
		{

			var mesa = mesaLN.ObtenerMesa(id);

			if (mesa == null) return RedirectToAction("Index");

			return View(mesa);
		}

		// POST: Mesa/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Mesa mesa)
		{
			try
			{
				mesaLN.ActualizarMesa(id, mesa);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Mesa/Delete/5
		public ActionResult Delete(int id)
		{
			var mesa = mesaLN.ObtenerMesa(id);

			if (mesa == null) return RedirectToAction("Index");

			return View(mesa);
		}

		// POST: Mesa/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				var mesa = mesaLN.ObtenerMesa(id);

				if (mesa == null) return RedirectToAction("Index");

				mesaLN.EliminarMesa(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
