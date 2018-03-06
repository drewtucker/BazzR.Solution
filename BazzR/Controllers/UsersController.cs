using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BazzR.Controllers
{
	public class UsersController : Controller
	{
		[HttpPost("/user/create/{id}")]
		public ActionResult Create()
		{
		    //read parameters from form
		    //User newUser = new User(//parameters);
		    //newUser.Save();
		    return RedirectToAction("Index", "Home");
		}
	}
}
