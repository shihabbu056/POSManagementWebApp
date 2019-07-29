using POSManagementSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSManagementSystem.Bll.Contracts
{
    public interface ICategoryManager:IManager<Category>
    {
        bool IsCategoryAlreadyExits(string name);
    }
}
