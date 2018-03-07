using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using BasicAuthentication.ViewModels;
using BasicAuthentication.Models;
using System;
using Bazzr.Models;


namespace BasicAuthentication.Controllers
{
	public class AccountController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_db = db;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
				User newUser = new User(user.UserName, user.Email,Request.Form["first-name"],Request.Form["last-name"],DateTime.Now,0, user.Id);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
		}
		[HttpPost("account/login")]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
		}
		[HttpPost]
		public async Task<IActionResult> LogOff()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}
		public IActionResult Login()
		{
			return View();
		}
	}
}