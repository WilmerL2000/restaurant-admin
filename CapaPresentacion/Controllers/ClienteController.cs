using CapaEntidades;
using CapaLogicaNegocio.Implementacion;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
	public class ClienteController : Controller
	{
		private readonly ClienteLN clienteLN = new ClienteLN();
		// GET: Cliente
		public ActionResult Index()
		{
			return View(clienteLN.ListarClientes());
		}

		// GET: Cliente/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Cliente/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Cliente/Create
		[HttpPost]
		public ActionResult Create(Cliente cliente)
		{
			try
			{
				clienteLN.InsertarCliente(cliente);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Cliente/Edit/5
		public ActionResult Edit(int id)
		{
			var cliente = clienteLN.ObtenerCliente(id);

			if (cliente == null) return RedirectToAction("Index");

			return View(cliente);
		}

		// POST: Cliente/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Cliente cliente)
		{
			try
			{
				clienteLN.ActualizarCliente(id, cliente);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Cliente/Delete/5
		public ActionResult Delete(int id)
		{
			var cliente = clienteLN.ObtenerCliente(id);

			if (cliente == null) return RedirectToAction("Index");

			return View(cliente);
		}

		// POST: Cliente/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				var cliente = clienteLN.ObtenerCliente(id);

				if (cliente == null) return RedirectToAction("Index");

				clienteLN.EliminarCliente(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
