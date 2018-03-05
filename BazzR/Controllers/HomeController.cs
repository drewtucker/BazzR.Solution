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
}
