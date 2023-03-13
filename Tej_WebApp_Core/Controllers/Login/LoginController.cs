using Microsoft.AspNetCore.Mvc;
using Tej_WebApp_Core.Interfaces;
using Tej_WebApp_Core.Models.Login;
using Tej_WebApp_Core.ViewModels;

namespace Tej_WebApp_Core.Controllers.Login
{
    public class LoginController : Controller
    {
        private readonly ILogin _login;

        public LoginController(ILogin login)
        {
            _login = login;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[Area("Dashboard")]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                List<LoginVM> loginList = _login.LoginCheck(login.user_name);

                if (loginList.Count > 0)
                {
                    //LoginViewModel objLogin = loginList.First();
                    LoginVM objLogin = loginList.First();

                    if (objLogin.password == login.password)
                    {
                        HttpContext.Session.SetInt32("pk_login_key", objLogin.pk_login_key);
                        HttpContext.Session.SetInt32("app_users_key", objLogin.app_users_key);
                        HttpContext.Session.SetString("f_name", Convert.ToString(objLogin.f_name));
                        HttpContext.Session.SetString("user_type", Convert.ToString(objLogin.user_type));
                        HttpContext.Session.SetString("login_branch", Convert.ToString(objLogin.login_branch));
                        HttpContext.Session.SetInt32("login_branch_key", objLogin.login_branch_key);

                        return RedirectToAction("Index", "Dashboard");
                        //return RedirectToAction("Dashboard", "Dashboard");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Wrong Password";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Could not find User name";
                    return View();
                }
            }
            return View();
        }
    }
}
