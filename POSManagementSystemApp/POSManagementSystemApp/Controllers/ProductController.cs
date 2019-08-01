using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POSManagementSystem.Bll.Bll;
using POSManagementSystem.Models.Models;

namespace POSManagementSystemApp.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        Product _product = new Product();
        // GET: Product
        public ActionResult Index()
        {
            return View(GetAllProduct());
            //var categorys = _categoryManager.GetAll();
            //var product = _productManager.GetAll();

            //List<Product> products = new List<Product>();
            //foreach (var productItem in product)
            //{
            //    var productVM = new Product();
            //    productVM.Id = productItem.Id;
            //    productVM.Name = productItem.Name;
            //    productVM.Code = productItem.Code;
            //    productVM.Discription = productItem.Discription;
            //    productVM.ReorderLevel = productItem.ReorderLevel;
            //    productVM.ImagePath = productItem.ImagePath;
            //    productVM.Category = categorys.Where(x => x.Id == productItem.CategoryId).FirstOrDefault();
            //    products.Add(productVM);
            //}
            //return View(products);
        }

        IEnumerable<Product> GetAllProduct()
        {
            var categorys = _categoryManager.GetAll();
            var product = _productManager.GetAll();

            List<Product> products = new List<Product>();
            foreach (var productItem in product)
            {
                var productVM = new Product();
                productVM.Id = productItem.Id;
                productVM.Name = productItem.Name;
                productVM.Code = productItem.Code;
                productVM.Discription = productItem.Discription;
                productVM.ReorderLevel = productItem.ReorderLevel;
                productVM.ImagePath = productItem.ImagePath;
                productVM.Category = categorys.Where(x => x.Id == productItem.CategoryId).FirstOrDefault();
                products.Add(productVM);
            }
            return products;
        }
        [HttpGet]
        public ActionResult Add()
        {
            var categorys = _categoryManager.GetAll();
            Product product = new Product();
            product.Categories = categorys; 
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id, Name, Code, CategoryId, ReorderLevel, Discription, Image, ImagePath, IsDeleted")]Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                        string extension = Path.GetExtension(product.ImageUpload.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        //product.ImagePath = fileName;
                        product.ImagePath = "~/images/product/" + fileName;
                        product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images/product/"), fileName));
                    }

                    _productManager.Add(product);
                    //if (isSaved)
                    //{
                    //    //ViewBag.SuccessMsg = "Product Saved Successfully.";
                    //    return true;

                    //}
                    //else
                    //{
                    //    ViewBag.FailMsg = "Vailed!";
                    //}
                    //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Index", GetAllProduct()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
                    //return RedirectToAction("Index");
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Index", GetAllProduct()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult Edit(int id)
        {
            _product.Id = id;
            var product = _productManager.GetByID(_product);
            Product productEdit = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Code = product.Code,
                ReorderLevel = product.ReorderLevel,
                Discription = product.Discription,
                ImagePath = product.ImagePath,
                CategoryId = product.CategoryId
            };
            ViewBag.CategoryId = new SelectList(_categoryManager.GetAll(), "Id", "Name", product.CategoryId);
            return View(productEdit);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                    string extension = Path.GetExtension(product.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    product.ImagePath = "~/images/product/" + fileName;
                    product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images/product/"), fileName));
                }

                bool isSaved = _productManager.Update(product);
                if (isSaved)
                {
                    ViewBag.SuccessMsg = "Update Successfully.";
                    
                }
                else
                {
                    ViewBag.FailMsg = "Update Vailed!";
                }
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.FailMsg = "Validation Error!";
            }

            return View(product);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _product.Id = (int)id;
            Product product = _productManager.GetByID(_product);
            //Student student = db.Students.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _product.Id = id;
            _productManager.Delete(_product);
            return RedirectToAction("Index");
        }
    }
}