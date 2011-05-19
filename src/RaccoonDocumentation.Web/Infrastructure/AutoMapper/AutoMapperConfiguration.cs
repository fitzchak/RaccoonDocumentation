using AutoMapper;
using RaccoonDocumentation.Web.Infrastructure.AutoMapper.Profiles;

namespace RaccoonDocumentation.Web.Infrastructure.AutoMapper
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.AddProfile(new DocumentationMapperProfiler());
		}
	}
}