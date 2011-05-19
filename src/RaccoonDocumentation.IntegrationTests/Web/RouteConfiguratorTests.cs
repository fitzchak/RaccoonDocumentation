using System;
using System.Web.Routing;
using MvcContrib.TestHelper;
using RaccoonDocumentation.Web;
using RaccoonDocumentation.Web.Controllers;
using Xunit;

namespace RaccoonDocumentation.IntegrationTests.Web
{
	public class RoutesTests : IDisposable
	{
		public RoutesTests()
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
	}
}