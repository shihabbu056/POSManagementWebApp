using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementSystem.Bll.Bll;
using POSManagementSystem.Models.Models;

namespace POSManagementSystemApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        Category _category = new Category();
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            _category.Id = id;
            Category category = _categoryManager.GetByID(_category);
            Category categoryVM = new Category()
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code
            };
            _categoryManager.Delete(_category);
            return View(categoryVM);
        }

        public ActionResult Delete(int id, FormCollection formCollection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}