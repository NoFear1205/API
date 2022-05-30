using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Category
    {
        public int CategoryID { get; set; }
        //[Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        [Display(Name ="Tên Loại sản phẩm")]
        //[MaxLength(30)]
        public string? CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
