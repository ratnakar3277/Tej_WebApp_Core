using Microsoft.AspNetCore.Mvc;
using Tej_WebApp_Core.Interfaces;
using Tej_WebApp_Core.Models.UnDelivered;

namespace Tej_WebApp_Core.Controllers.UnDelivered
{
    public class UnDeliveredController : Controller
    {
        private readonly IUnDelivered _unDelivered;
        public UnDeliveredController(IUnDelivered unDelivered)
        {
            _unDelivered = unDelivered;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int? pk_consmt_key, string Consmt_no, int? pk_deliver_by, int? pk_branch_key)
        {
            if (pk_consmt_key == null && Consmt_no == null && pk_deliver_by == null && pk_branch_key == null)
            {
                return RedirectToAction("Index", "DlvTaskList");
            }
            //  ViewBag.Consmtno = Consmt_no;
            TempData["cnote_no"] = Consmt_no;
            return View();

        }
        [HttpPost]
        public IActionResult Create(int? pk_consmt_key, string consmt_no, int? pk_deliver_by, int? pk_branch_key, UnDeliveredModel unDelivered)
        {
            ModelState.Remove("remark");

            if (ModelState.IsValid)
            {

            }

            ViewBag.reason = unDelivered.reason;

            if (ModelState.IsValid)
            {
                // ViewBag.reason = unDelivered.reason;

                if (pk_consmt_key != 0)
                {
                    _unDelivered.UnDeliveredUpdate(unDelivered);
                }
                else
                {
                    return RedirectToAction("Index", "DlvTaskList");
                }
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
            }
            //  return RedirectToAction("Index", "DlvTaskList");

            return RedirectToAction("Index", "DlvTaskList");
            //return View();
        }

    }
}