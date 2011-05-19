using System.Web.Mvc;
using System.Web.Routing;
using RaccoonDocumentation.Web.Helpers.Routes;

namespace RaccoonDocumentation.Web
{
	public class RouteConfigurator
	{
		private const string MatchPositiveInteger = @"\d{1,10}";

		private readonly RouteCollection routes;

		public RouteConfigurator(RouteCollection routes)
		{
			this.routes = routes;
		}

		public void Configure()
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

			#region "Default"

			routes.MapRouteLowerCase("Default",
				"",
				new { controller = "Documentation", action = "Index", slug = "/" }
				);

			#endregion
		}
	}
}