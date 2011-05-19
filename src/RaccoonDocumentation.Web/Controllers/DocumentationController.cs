using System.Web.Mvc;
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

			var model = new DocumentationPageViewModel();
			return View(model);
		}
	}
}