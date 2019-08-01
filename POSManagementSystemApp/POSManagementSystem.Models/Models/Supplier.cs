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
    public class Supplier: IModel, IDeletable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Email Number Must be Provide!"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public long Contact { get; set; }
        public string ContactPerson { get; set; }
        public byte[] Image { get; set; }
        [Display(Name = "Supplier Photo")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Supplier()
        {
            ImagePath = "~/images/product/default.png";
        }
        public bool IsDeleted { get; set; }

        public bool WithDeleted()
        {
            return IsDeleted;
        }
    }
}
