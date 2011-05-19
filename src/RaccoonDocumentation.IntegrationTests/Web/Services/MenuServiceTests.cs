using RaccoonDocumentation.Web.Services;
using Xunit;

namespace RaccoonDocumentation.IntegrationTests.Web.Services
{
	public class MenuServiceTests
	{
		private readonly MenuService service = new MenuService();

		[Fact]
		public void ParseLine_ReturnsMenuItem()
		{
			var result = service.ParseLine("/intro Intro");
			Assert.Equal("/intro", result.Slug);
			Assert.Equal("Intro", result.Title);
		}
	}
}