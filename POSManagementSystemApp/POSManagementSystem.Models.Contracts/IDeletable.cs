using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSManagementSystem.Models.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        bool WithDeleted();
    }
}
