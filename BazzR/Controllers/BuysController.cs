using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BazzR.Controllers
{
	public class BuysController : Controller
	{
		[HttpGet("/search/all")]
		public IActionResult Index()
		{
			return View("WantToBuy");
		}
    }
}
