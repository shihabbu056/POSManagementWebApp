using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSManagementSystem.Repositor.Contracts.Base;
using POSManagementSystem.Models.Models;

namespace POSManagementSystem.Repositor.Contracts
{
    public interface ICategoryRepository:IRepository<Category>
    {
    }
}
