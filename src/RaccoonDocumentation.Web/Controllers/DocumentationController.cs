﻿using System.Web.Mvc;

namespace RaccoonDocumentation.Web.Controllers
{
	public class DocumentationController : Controller
	{
		public ActionResult Index(string slug)
		{
			return View();
		}
	}
}