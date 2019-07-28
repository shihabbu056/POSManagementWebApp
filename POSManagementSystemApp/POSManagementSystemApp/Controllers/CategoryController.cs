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
            return View();
        }
        public ActionResult Add(Category category)
        {
            //_student.ID = 101;
            _category.Name = category.Name;
            _category.Code = category.Code;
            _categoryManager.Add(_category);
            return View();
        }
        public ActionResult Delete(int id)
        {
            _category.Id = id;
            _categoryManager.Delete(_category);
            return View();
        }
        public ActionResult Update(Category category)
        {
            _category.Id = category.Id;
            //Method 1

            //_student.Name = "Kamal";
            //_studentManager.Update(_student);

            Category aCategory = _categoryManager.GetByID(_category);
            if (aCategory != null)
            {
                aCategory.Name = category.Name;
                _categoryManager.Update(aCategory);

            }
            return View();
        }
    }
}