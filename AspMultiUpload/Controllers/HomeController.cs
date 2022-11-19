using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMultiUpload.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] files)
        {

            if (ModelState.IsValid)
            {    
                foreach (HttpPostedFileBase file in files)
                { 
                    if (file != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        string extension = Path.GetExtension(file.FileName);
                        string newFileName = fileName + "-" + DateTime.Now.ToString("yyyymmssffff") + extension;
                        string UploadPath = Path.Combine(Server.MapPath("~/Content/UploadedFiles/"), newFileName);
             
                        file.SaveAs(UploadPath);
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }
            }
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}