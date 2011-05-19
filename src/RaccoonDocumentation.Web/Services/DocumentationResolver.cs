using System.Linq;
using RaccoonDocumentation.Web.Models;

namespace RaccoonDocumentation.Web.Services
{
	public class DocumentationResolver
	{
		public DocumentationItemResolved Resolve(string slug)
		{
			var resolved = new DocumentationItemResolved();

			var documentationItem = new DocumentationLocator().Get(slug);
			if (documentationItem == null)
				return null;

			resolved.Content = documentationItem.Content;
			resolved.Menu = new MenuService()
				.ParseAll(documentationItem.Menu)
				.ToList();

			return resolved;
		}
	}
}