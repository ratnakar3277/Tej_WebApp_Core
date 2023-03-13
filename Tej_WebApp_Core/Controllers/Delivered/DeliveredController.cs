using Microsoft.AspNetCore.Mvc;
//using System.Drawing.Imaging;
using System.Drawing;
using Tej_WebApp_Core.Interfaces;
using Tej_WebApp_Core.Models.Delivered;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;

namespace Tej_WebApp_Core.Controllers.Delivered
{
    public class DeliveredController : Controller
    {

        private readonly IDelivered _dlv;

        public DeliveredController(IDelivered dlv)
        {
            _dlv = dlv;
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int? pk_consmt_key, int? pk_deliver_by, int? pk_branch_key)
        {
            if (pk_consmt_key == null && pk_deliver_by == null && pk_branch_key == null)
            {
                return RedirectToAction("Index", "DlvTaskList");
            }
            ViewBag.crt_by = HttpContext.Session.GetInt32("app_users_key");
            return View();
        }



        [HttpPost]
        public IActionResult Create(int pk_consmt_key, int pk_deliver_by, int pk_branch_key, IFormFile postedFile, DeliveredModel dlv)
        {
            
            ModelState.Remove("Name");
            ModelState.Remove("FileType");
            ModelState.Remove("DataFiles");

            var fileName = Path.GetFileName(postedFile.FileName);
            var contentType = postedFile.ContentType;           
            dlv.Name = fileName;
            dlv.FileType = contentType;

            using (var stream = new MemoryStream())
            {
                //For reduce size
                //var image = System.Drawing.Image.FromStream(postedFile.OpenReadStream());
                //var resized = new Bitmap(image, new Size(256, 256));
                //using var imageStream = new MemoryStream();
                //resized.Save(imageStream, ImageFormat.Jpeg);
                //var imageBytes = imageStream.ToArray();
                //postedFile.CopyToAsync(imageStream);
                //var fileData = imageStream.ToArray();
                //dlv.DataFiles = fileData;


                postedFile.CopyToAsync(stream);
                var fileData = stream.ToArray();
                dlv.DataFiles = fileData;
            }

            if (pk_consmt_key == 0)
            {
                return RedirectToAction("Index", "DlvTaskList");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (pk_consmt_key != 0)
                    {

                        _dlv.InsertDelvery(dlv);
                    }
                    else
                    {
                        return RedirectToAction("Index", "DlvTaskList");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction("Index", "DlvTaskList");
            }
            else
            {
                //if(dlv.relation == null)
                //{
                //    ViewBag.RelErrorMsg = "Please select Relation";
                //}
                //if (dlv.id_proof == null)
                //{
                //    ViewBag.IdErrorMsg = "Please select Id Proof";
                //}
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
            }
            //return RedirectToAction("Index", "DlvTaskList", new { Area = "DlvTaskList" });
            return View();
        }
    }
}