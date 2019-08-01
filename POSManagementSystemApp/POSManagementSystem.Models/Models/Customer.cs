using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using POSManagementSystem.Models.Contracts;

namespace POSManagementSystem.Models.Models
{
    public class Customer:IModel, IDeletable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public long Contact { get; set; }
        public int LoyaltyPoint { get; set; }
        public byte[] Image { get; set; }
        public string ImagePath { get; set; }
        //[NotMapped]
        //public HttpPostedFileBase ImageUpload { get; set; }

        //public Customer()
        //{
        //    ImagePath = "~/images/customer/blank.png";
        //}
        public bool IsDeleted { get; set; }

        public bool WithDeleted()
        {
            return IsDeleted;
        }
    }
}
