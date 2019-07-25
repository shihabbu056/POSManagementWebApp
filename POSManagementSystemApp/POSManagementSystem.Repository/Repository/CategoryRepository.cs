using System;
using System.Collections.Generic;
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
        public void Create()
        {

        }

        public int Edit(int id)
        {
            return id;
        }

        //public List<Category> GetAllCategories(int id){
            
        //}

        public int GetById(int id)
        {
            return id;
        }
    }
}
