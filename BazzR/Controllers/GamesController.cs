using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bazzr.Models;
using Bazzr;

namespace Bazzr.Controllers
{
    public class GamesController : Controller
    {
      [HttpGet("/game/new")]
      public ActionResult NewGameForm()
      {
        return View();
      }

      [HttpPost("/game")]
        public ActionResult Create()
        {
          string gameName = Request.Form["game-title"];
          string gamePlatform = Request.Form["game-platform"];
          string gameDescription = Request.Form["game-description"];
          string gamePhotopath = Request.Form["game-photopath"];
          int gameMetascore = int.Parse(Request.Form["game-metascore"]);
          Game newGame = new Game(gameName, gamePlatform, gameDescription, gamePhotopath, gameMetascore);
          newGame.Save();
          // return RedirectToAction("UserProfile");
          return RedirectToAction("NewGameForm");
        }
    }
}
