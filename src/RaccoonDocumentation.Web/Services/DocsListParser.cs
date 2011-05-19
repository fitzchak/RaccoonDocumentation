using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using RaccoonDocumentation.Web.Models;

namespace RaccoonDocumentation.Web.Services
{
	public static class DocsListParser
	{
		static readonly Regex DocsListFinder = new Regex(@"\[FILES-LIST\]", RegexOptions.Compiled);

		public static MenuItem ParseLine(string line)
		{
			var item = new MenuItem
			           	{
			           		Slug = ParseSlug(line),
			           		Title = ParseTitle(line),
			           	};

			return item;
		}

		private static string ParseSlug(string line)
		{
			var slugRegex = new Regex(@"^(\w|[-/])+");
			var match = slugRegex.Match(line);
			if (match.Success)
				return match.Value;
			return null;
		}

		private static string ParseTitle(string line)
		{
			var titleRegex = new Regex(@"\s.+");
			var match = titleRegex.Match(line);
			if (match.Success)
				return match.Value.TrimStart();
			return null;
		}

		public static IEnumerable<MenuItem> ParseAll(string content)
		{
			var lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			return lines.Select(ParseLine);
		}

		public static string ParseDocsList(this string content, string menu, string slug)
		{
			return DocsListFinder.Replace(content, match => GenerateDocsListMenu(menu, slug));
		}

		private static string GenerateDocsListMenu(string menu, string slug)
		{
			var result = ParseAll(menu)
				.Select(item => string.Format("- [{0}]({1})", item.Title, UrlHelper.Action("Index", "Documentation", new { slug = slug + "/" + item.Slug })));
			return string.Join(Environment.NewLine, result);
		}

		private static UrlHelper urlHelper;
		private static UrlHelper UrlHelper
		{
			get
			{
				return urlHelper ?? (urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext));
			}
		}
	}
}