using Microsoft.AspNetCore.Mvc;

namespace Tej_WebApp_Core.Controllers.Dashboard
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Logout()
		{
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
		}
	}
}
