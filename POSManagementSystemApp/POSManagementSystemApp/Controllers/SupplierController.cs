using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementSystem.Bll.Bll;
using POSManagementSystem.Models.Models;

namespace POSManagementSystemApp.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(_supplierManager.GetAll());
        }
        public static string GetFileNameToSave(string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }
        private byte[] GetImageData(string imgName)
        {
            byte[] imageData = null;

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase imgFile = Request.Files["Image"];
                if (imgFile != null && imgFile.ContentLength > 0)
                {
                    var fileName = GetFileNameToSave(imgName + DateTime.Now);
                    imgFile.SaveAs(Server.MapPath("~/images/supplier/" + fileName));
                    //imgFile.SaveAs(Server.MapPath(Path.Combine()));

                    using (var binary = new BinaryReader(imgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(imgFile.ContentLength);
                    }
                }
            }
            return imageData;
        }
        public bool HasFile(byte[] file)
        {

            return file != null;
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var imageData = GetImageData(supplier.Name);
                if (HasFile(imageData))
                {
                    
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            return View();
        }
    }
}