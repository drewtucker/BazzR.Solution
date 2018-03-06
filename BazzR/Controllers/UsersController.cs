using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BazzR.Controllers
{
	public class UsersController : Controller
	{
		[HttpGet("/user/create")]
		public ActionResult NewUserForm()
		{
			return View();
		}

		[HttpPost("/user/create/{id}")]
		public ActionResult Create()
		{
		    //read parameters from form
		    //User newUser = new User(//parameters);
		    //newUser.Save();
		    return RedirectToAction("Index", "Home");
		}

		[HttpGet("/user/password/reset")]
		public ActionResult PasswordResetForm()
		{
			return View("PasswordReset");
		}

		[HttpGet("/user/profile")]
		public ActionResult UserProfile()
		{
			return View();
		}

		[HttpGet("/user/profile/edit")]
		public ActionResult EditUserProfile()
		{
			return View();
		}
	}
}
