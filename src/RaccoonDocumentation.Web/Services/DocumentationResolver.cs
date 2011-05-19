using System;
using System.IO;
using System.Web;
using RaccoonDocumentation.Web.Models;

namespace RaccoonDocumentation.Web.Services
{
	public class DocumentationResolver
	{
		public DocumentationItem Resolve(string slug)
		{
			var path = LocateDocPath(slug);
			if (path == null)
				return null;

			var content = File.ReadAllText(path)
				.ParesDocumentation()
				.ParseDocsList(path, slug);

			return new DocumentationItem {Content = content};
		}

		private string LocateDocPath(string slug)
		{
			if (slug == null)
				throw new InvalidOperationException("Slug cannot be null");

			var appDataDir = HttpContext.Current.Server.MapPath("~/App_Data");
			var docsPath = Path.Combine(appDataDir, "docs");
			if (Directory.Exists(docsPath) == false)
				throw new DirectoryNotFoundException("'docs' directory was not found");

			var slugPath = Path.Combine(docsPath, slug);
			if (Directory.Exists(slugPath))
				slugPath = Path.Combine(slugPath, "index.markdown");
			else
				slugPath += ".markdown";

			if (File.Exists(slugPath) == false)
				return null;

			return slugPath;
		}
	}
}