using POSManagementSystem.DatabaseContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSManagementSystem.Models.Models;
using System.Data.Entity;

namespace POSManagementSystem.Repository.Repository
{
    public class SupplierRepository
    {
        POSManagementSystemBdContext db = new POSManagementSystemBdContext();

        public bool Add(Supplier supplier)
        {
            int isExecuted = 0;

            db.Suppliers.Add(supplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public bool Delete(Supplier supplier)
        {
            int isExecuted = 0;
            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);

            db.Suppliers.Remove(aSupplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }
        public bool Update(Supplier supplier)
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
            db.Entry(supplier).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }
        public Supplier GetByID(Supplier supplier)
        {
            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);
            return aSupplier;
        }
    }
}
