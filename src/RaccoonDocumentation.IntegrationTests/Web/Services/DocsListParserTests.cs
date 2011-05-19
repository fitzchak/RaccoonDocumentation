using System.Linq;
using RaccoonDocumentation.Web.Services;
using Xunit;

namespace RaccoonDocumentation.IntegrationTests.Web.Services
{
	public class DocsListParserTests
	{
		[Fact]
		public void ParseLine_ReturnsMenuItem()
		{
			var result = DocsListParser.ParseLine("/intro Intro");
			Assert.Equal("/intro", result.Slug);
			Assert.Equal("Intro", result.Title);
		}

		[Fact]
		public void ParseLine_ReturnsMenuItem_WithNotRegularSpaceSeparator()
		{
			var result = DocsListParser.ParseLine("/intro	Intro");
			Assert.Equal("/intro", result.Slug);
			Assert.Equal("Intro", result.Title);
		}

		[Fact]
		public void ParseLine_ReturnsMenuItem_WithTabDelim()
		{
			var result = DocsListParser.ParseLine("adding-ravendb-to-your-application\tAdding RavenDB to your application");
			Assert.Equal("adding-ravendb-to-your-application", result.Slug);
			Assert.Equal("Adding RavenDB to your application", result.Title);
		}

		[Fact]
		public void ParseLine_ReturnsMenuItem_WithTitleContainsSpaces()
		{
			var result = DocsListParser.ParseLine("/consumer	Consumer usage");
			Assert.Equal("/consumer", result.Slug);
			Assert.Equal("Consumer usage", result.Title);
		}

		[Fact]
		public void ParesAll_ReturnsAllMenuItems()
		{
			var result = DocsListParser.ParseAll(@"/intro	Intro
/theory	Theory
/consumer	Consumer usage
/server	Server side
/studio	The Studio
/ravenlight	RavenLight
/appendixes	Appendixes");

			Assert.Equal(7, result.Count());
		}
	}
}