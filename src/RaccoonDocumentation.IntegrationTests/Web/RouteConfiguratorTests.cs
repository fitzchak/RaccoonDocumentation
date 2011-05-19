using System;
using System.Web.Routing;
using MvcContrib.TestHelper;
using RaccoonDocumentation.Web;
using RaccoonDocumentation.Web.Controllers;
using Xunit;

namespace RaccoonDocumentation.IntegrationTests.Web
{
	public class RouteConfiguratorTests : IDisposable
	{
		public RouteConfiguratorTests()
		{
			new RouteConfigurator(RouteTable.Routes).Configure();
		}

		public void Dispose()
		{
			RouteTable.Routes.Clear();
		}

		[Fact]
		public void DefaultRoute()
		{
			"~/".ShouldMapTo<DocumentationController>(c => c.Index("/"));
		}

		[Fact]
		public void DocumentationControllerRoutes()
		{
			"~/intro".ShouldMapTo<DocumentationController>(c => c.Index("/intro"));
			"~/intro/what-is-nosql".ShouldMapTo<DocumentationController>(c => c.Index("/intro/what-is-nosql"));
		}
	}
}