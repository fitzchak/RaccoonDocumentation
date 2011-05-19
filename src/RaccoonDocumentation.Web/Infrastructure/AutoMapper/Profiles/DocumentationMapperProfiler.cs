using AutoMapper;
using RaccoonDocumentation.Web.Infrastructure.AutoMapper.Profiles.Resolvers;
using RaccoonDocumentation.Web.Models;
using RaccoonDocumentation.Web.ViewModels;

namespace RaccoonDocumentation.Web.Infrastructure.AutoMapper.Profiles
{
	public class DocumentationMapperProfiler : Profile
	{
		protected override void Configure()
		{
			Mapper.CreateMap<DocumentationItem, DocumentationPageViewModel>()
				.ForMember(x => x.Content, o => o.MapFrom(m => MarkdownResolver.Resolve(m.Content)))
				;
		}
	}
}