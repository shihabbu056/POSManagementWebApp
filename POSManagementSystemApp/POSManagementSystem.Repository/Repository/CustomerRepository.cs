﻿using POSManagementSystem.DatabaseContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSManagementSystem.Models.Models;
using System.Data.Entity;

namespace POSManagementSystem.Repository.Repository
{
    public class CustomerRepository
    {
        POSManagementSystemBdContext db = new POSManagementSystemBdContext();

        public bool Add(Customer customer)
        {
            int isExecuted = 0;

            db.Customers.Add(customer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public bool Delete(Customer customer)
        {
            int isExecuted = 0;
            Customer aCustomer = db.Customers.FirstOrDefault(c => c.Id == customer.Id);

            db.Customers.Remove(aCustomer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }
        public bool Update(Customer customer)
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
            db.Entry(customer).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }
        public Customer GetByID(Customer customer)
        {
            Customer aCustomer = db.Customers.FirstOrDefault(c => c.Id == customer.Id);
            return aCustomer;
        }
    }
}
