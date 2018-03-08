using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bazzr.Models;

namespace Bazzr.Controllers
{
	public class SellsController : Controller
	{
		[HttpGet("/trade/new")]
		public IActionResult Index()
		{
			User thisUser = Bazzr.Models.User.Find(User.Identity.Name);
			return View("WantToSell");
		}
  }
}
