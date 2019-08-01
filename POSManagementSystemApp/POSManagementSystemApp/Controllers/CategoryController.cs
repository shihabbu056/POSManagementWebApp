using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POSManagementSystem.Bll.Bll;
using POSManagementSystem.Models.Models;
using POSManagementSystem.Bll.Contracts;
using POSManagementSystem.DatabaseContext.DatabaseContext;

namespace POSManagementSystemApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        //private ICategoryManager _categoryManagerInterface;
        Category _category = new Category();

        //public CategoryController(ICategoryManager categoryInterface, CategoryManager categoryManager)
        //{
        //    this._categoryManagerInterface = categoryInterface;
        //    this._categoryManager = categoryManager;
        //}
        // GET: Category
        public ActionResult Index()
        {
            return View(_categoryManager.GetAll());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id, Name, Code, IsDeleted")]Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryManager.Add(category))
                {
                    ViewBag.SuccessMsg = "Category Saved Successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.FailMsg = "Vailed!";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error!";
            }

            return View();
        }
        public ActionResult Edit(int id)
        {
            _category.Id = id;
            var category = _categoryManager.GetByID(_category);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryManager.Update(category))
                {
                    ViewBag.SuccessMsg = "Update Successfully.";
                    return RedirectToAction("Index","Category");
                }
                else
                {
                    ViewBag.FailMsg = "Update Vailed!";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error!";
            }

            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _category.Id = (int)id;
            Category category = _categoryManager.GetByID(_category);
            //Student student = db.Students.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _category.Id = id;
            _categoryManager.Delete(_category);
            return RedirectToAction("Index");
        }
        public JsonResult IsCategoryNameExist(string categoryName)
        {
            POSManagementSystemBdContext dbpri = new POSManagementSystemBdContext();
            Category cat = dbpri.Categories.Find(categoryName);
            if (cat==null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json("Category Already Exist, Try Another", JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Delete(int id, FormCollection formCollection)
        //{
        //    try
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}