using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using POSManagementSystem.Models.Contracts;

namespace POSManagementSystem.Models.Models
{
    public class Product: IModel, IDeletable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int ReorderLevel { get; set; }
        public string Discription { get; set; }
        public byte[] Image { get; set; }
        [Display(Name = "Product Image")]
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public IEnumerable<Category> Categories { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Product()
        {
            ImagePath = "~/images/product/default.png";
        }

        public bool WithDeleted()
        {
            return IsDeleted;
        }
    }
}
