using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSManagementSystem.Models.Models;
using POSManagementSystem.Repositor.Contracts;
using POSManagementSystem.Repository.Base;

namespace POSManagementSystem.Repository.Repository
{
    public class CategoryRepositoryInterface: DeletableRepository<Category>, ICategoryRepository
    {
    }
}
