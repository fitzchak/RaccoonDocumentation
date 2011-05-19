using System.Text.RegularExpressions;
using RaccoonDocumentation.Web.Models;

namespace RaccoonDocumentation.Web.Services
{
	public class MenuService
	{
		public MenuItem ParseLine(string line)
		{
			var item = new MenuItem
			           	{
			           		Slug = ParseSlug(line),
			           		Title = ParseTitle(line),
			           	};

			return item;
		}

		private string ParseSlug(string line)
		{
			var slugRegex = new Regex(@"^(\w|[-/])+");
			var match = slugRegex.Match(line);
			if (match.Success)
				return match.Value;
			return null;
		}

		private string ParseTitle(string line)
		{
			var titleRegex = new Regex(@"\s.+");
			var match = titleRegex.Match(line);
			if (match.Success)
				return match.Value.TrimStart();
			return null;
		}
	}
}