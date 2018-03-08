using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bazzr.Models;

namespace Bazzr.Controllers
{
	public class BuysController : Controller
	{
		[HttpGet("/search/all")]
		public IActionResult Index()
		{
			List<Sell_Transaction> allSellTransactions = Sell_Transaction.GetAll();
			return View("WantToBuy", allSellTransactions);
		}

		[HttpGet("/search/details/{id}")]
		public ActionResult GameDetails(int id)
		{
			Dictionary<string, object> model = new Dictionary<string, object>();
			Sell_Transaction thisST = Sell_Transaction.Find(id);

			Game thisGame = Game.Find(thisST.GetGameId());

			model.Add("thisST", thisST);
			model.Add("thisGame", thisGame);
			return View(model);
		}

  }
}
