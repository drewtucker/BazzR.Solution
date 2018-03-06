
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bazzr.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet("/")]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("/about")]
		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		[HttpGet("/contact")]
		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		[HttpGet("/error")]
		public IActionResult Error()
		{
			return View();
		}
	}
}
