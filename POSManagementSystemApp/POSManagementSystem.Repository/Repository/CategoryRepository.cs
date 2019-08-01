using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSManagementSystem.DatabaseContext.DatabaseContext;
using POSManagementSystem.Models.Models;

namespace POSManagementSystem.Repository.Repository
{
    public class CategoryRepository
    {
        POSManagementSystemBdContext db = new POSManagementSystemBdContext();

        public bool Add(Category category)
        {
            int isExecuted = 0;

            db.Categories.Add(category);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public bool Delete(Category category)
        {
            int isExecuted = 0;
            Category aCategory = db.Categories.FirstOrDefault(c => c.Id == category.Id);

            db.Categories.Remove(aCategory);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }
        public bool Update(Category category)
        {
            int isExecuted = 0;
            //Method 1
            //Student aStudent = db.Students.FirstOrDefault(c => c.ID == student.ID);
            //if (aStudent != null)
            //{
            //    aStudent.Name = student.Name;
            //    isExecuted = db.SaveChanges();
            //}

            //Method 2
            db.Entry(category).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public Category GetByID(Category category)
        {
            Category aStudent = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            return aStudent;
        }

        public bool IsCategoryNameDuplicate(string categoryName)
        {
            var aCategory = db.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (aCategory != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
