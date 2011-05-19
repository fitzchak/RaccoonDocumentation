using System.Web.Mvc;
using AutoMapper;
using RaccoonDocumentation.Web.Infrastructure.AutoMapper.Profiles;
using RaccoonDocumentation.Web.Infrastructure.AutoMapper.Profiles.Resolvers;

namespace RaccoonDocumentation.Web.Infrastructure.AutoMapper
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.CreateMap<string, MvcHtmlString>().ConvertUsing<MvcHtmlStringConverter>();

			Mapper.AddProfile(new DocumentationMapperProfiler());
		}
	}
}