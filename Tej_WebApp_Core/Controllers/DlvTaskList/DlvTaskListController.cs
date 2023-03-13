using Microsoft.AspNetCore.Mvc;
using Tej_WebApp_Core.Interfaces;

namespace Tej_WebApp_Core.Controllers.DlvTaskList
{
    public class DlvTaskListController : Controller
    {
        private readonly IDlvTaskList _dlvtask;

        public DlvTaskListController(IDlvTaskList dlvtask)
        {
            _dlvtask = dlvtask;
        }
        public IActionResult Index()
        {
            ViewBag.app_users_key = HttpContext.Session.GetInt32("app_users_key");
            return View(_dlvtask.GetList(ViewBag.app_users_key,""));
        }


        [HttpPost]        public IActionResult Index(IFormCollection form)        {
            string consmt_no = form["consmt_no"];
            ViewBag.app_users_key = HttpContext.Session.GetInt32("app_users_key");
            return View(_dlvtask.GetList(ViewBag.app_users_key,consmt_no));        }
    }
}
