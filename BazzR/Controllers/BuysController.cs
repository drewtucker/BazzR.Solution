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
			Dictionary<string, object> dict = new Dictionary<string, object>();
			List<Sell_Transaction> allSellTransactions = Sell_Transaction.GetAll();
			List<Game> allGames = Game.GetAll();
			dict.Add("allGames", allGames);
			dict.Add("allSellTransactions", allSellTransactions);
			ViewBag.Dictionary = dict;
			return View("WantToBuy");
		}

		[HttpGet("/search/details/{id}")]
		public ActionResult GameDetails(int id)
		{

			Dictionary<string, object> dict = new Dictionary<string, object>();
			Sell_Transaction thisST = Sell_Transaction.Find(id);
			List<Game> allGames = Game.GetAll();
			Game thisGame = Game.Find(thisST.GetGameId());
			dict.Add("thisST", thisST);
			dict.Add("allGames", allGames);
			dict.Add("thisGame", thisGame);
			ViewBag.Dictionary = dict;
			return View();
		}

  }
}
