using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BazzR.Controllers
{
	public class SellsController : Controller
	{
		[HttpGet("/trade/new")]
		public IActionResult Index()
		{
			return View("WantToSell");
		}
  }
}
