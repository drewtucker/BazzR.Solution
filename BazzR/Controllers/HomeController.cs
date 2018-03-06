<<<<<<< HEAD
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
// using BazzrApp.Models;

namespace BazzrApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }
  }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BazzR.Controllers
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
>>>>>>> c6ba035983ffa826d215aa893dc7a5e4ac8ea062
}
