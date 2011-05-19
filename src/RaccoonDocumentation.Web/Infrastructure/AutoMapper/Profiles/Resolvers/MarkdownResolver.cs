using System.Web.Mvc;
using MarkdownSharp;

namespace RaccoonDocumentation.Web.Infrastructure.AutoMapper.Profiles.Resolvers
{
    public class MarkdownResolver
    {
        public static MvcHtmlString Resolve(string inputBody)
        {
            var html = FormatMarkdown(inputBody);
            return MvcHtmlString.Create(html);
        }

        public static string FormatMarkdown(string content)
        {
            var md = new Markdown(new MarkdownOptions
        	{
        		AutoHyperlink = true,
        		AutoNewLines = true,
        		EncodeProblemUrlCharacters = true,
        		LinkEmails = false,
        		StrictBoldItalic = true,
        	});
            
            return md.Transform(content);
        }
    }
}