using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POSManagementSystem.Models.Contracts;

namespace POSManagementSystem.Models.Models
{
    public class Category: IModel, IDeletable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Remote("IsCategoryNameExist", "Category", HttpMethod = "POST", ErrorMessage = "Category Already Exist, Try Another")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public bool WithDeleted()
        {
            return IsDeleted;
        }
    }
}
