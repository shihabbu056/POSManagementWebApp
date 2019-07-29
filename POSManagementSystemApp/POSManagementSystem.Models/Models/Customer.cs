using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSManagementSystem.Models.Contracts;

namespace POSManagementSystem.Models.Models
{
    public class Customer:IModel, IDeletable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long Contact { get; set; }
        public int LoyaltyPoint { get; set; }
        public byte[] Image { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }

        public bool WithDeleted()
        {
            return IsDeleted;
        }
    }
}
