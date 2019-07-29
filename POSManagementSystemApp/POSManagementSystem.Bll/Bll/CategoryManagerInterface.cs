using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSManagementSystem.Bll.Base;
using POSManagementSystem.Bll.Contracts;
using POSManagementSystem.Models.Models;
using POSManagementSystem.Repositor.Contracts;
using POSManagementSystem.Repositor.Contracts.Base;
using POSManagementSystem.Repository.Repository;

namespace POSManagementSystem.Bll.Bll
{
    public class CategoryManagerInterface: Manager<Category>,ICategoryManager
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManagerInterface() : base(new CategoryRepositoryInterface())
        {
            this._categoryRepository = (CategoryRepositoryInterface)base.BaseRepository;
        }

        public CategoryManagerInterface(ICategoryRepository category): base(category)
        {
            this._categoryRepository = category;
        }
        //public CategoryManagerInterface(IRepository<Category> baseRepository) : base(baseRepository)
        //{
        //}

        public bool IsCategoryAlreadyExits(string name)
        {
            var category = _categoryRepository.Get(c => c.Name.ToLower().Equals(name.ToLower()));
            if (category.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
