using AutoMapper;
using RaccoonDocumentation.Web.Infrastructure.AutoMapper;
using Xunit;

namespace RaccoonDocumentation.IntegrationTests.Web.Infrastructure.AutoMapper
{
	public class AutoMapperConfigurationTester
	{
		[Fact]
		public void AssertConfigurationIsValid()
		{
			AutoMapperConfiguration.Configure();
			Mapper.AssertConfigurationIsValid();
		}
	}
}