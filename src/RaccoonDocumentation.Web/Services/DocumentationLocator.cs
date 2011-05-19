using System;
using System.IO;
using System.Web;
using RaccoonDocumentation.Web.Models;

namespace RaccoonDocumentation.Web.Services
{
	public class DocumentationLocator
	{
		public DocumentationItem Get(string slug)
		{
			if (slug == null)
				throw new InvalidOperationException("Slug cannot be null");
			
			var appDataDir = HttpContext.Current.Server.MapPath("~/App_Data");
			var docsPath = Path.Combine(appDataDir, "docs");
			var docsDir = new DirectoryInfo(docsPath);

			if (docsDir.Exists == false)
				throw new DirectoryNotFoundException("'docs' directory was not found");

			var slugPath = Path.Combine(docsPath, slug);
			if (Directory.Exists(slugPath))
				slugPath = Path.Combine(slugPath, "index.markdown");
			else
				slugPath += ".markdown";

			if (File.Exists(slugPath) == false)
				return null;

			var item = new DocumentationItem();
			item.Content = File.ReadAllText(slugPath);
			item.Menu = File.ReadAllText(slugPath);
			return item;
		}
	}
}