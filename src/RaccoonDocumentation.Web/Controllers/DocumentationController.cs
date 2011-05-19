using System.Web.Mvc;
using RaccoonDocumentation.Web.Infrastructure.AutoMapper;
using RaccoonDocumentation.Web.Services;
using RaccoonDocumentation.Web.ViewModels;

namespace RaccoonDocumentation.Web.Controllers
{
	public class DocumentationController : Controller
	{
		public ActionResult Index(string slug)
		{
			var documentationResolver = new DocumentationResolver();
			var documentationItem = documentationResolver.Resolve(slug);
			if (documentationItem == null)
				return HttpNotFound("Slug not exist");

			var model = documentationItem.MapTo<DocumentationPageViewModel>();
			return View(model);
		}
	}
}