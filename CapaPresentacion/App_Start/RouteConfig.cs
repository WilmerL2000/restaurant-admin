using System.Web.Mvc;
using System.Web.Routing;

namespace CapaPresentacion
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

			//routes.MapRoute(
			//	name: "Menu",
			//	url: "{controller}/{action}",
			//	defaults: new { controller = "Menu", action = "Index"}
			//);
		}
	}
}
