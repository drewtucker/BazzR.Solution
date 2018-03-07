// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
//
// namespace BazzR.Controllers
// {
//     public class GamesController : Controller
//     {
//
//         [HttpPost("/game/create")]
//         public ActionResult Create()
//         {
//             string gameName = Request.Form["game-title"];
//             string gamePlatform = Request.Form["game-platform"];
//             Game newGame = new Game(gameName, gamePlatform);
//             newGame.Save();
//             return RedirectToAction("NewGameForm");
//         }
//     }
// }
