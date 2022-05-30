using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Ảnh minh họa")]
        public string? Image { get; set; }
        /*[Required(ErrorMessage = "Tên sản phầm không được để trống")]
        [StringLength(30)]*/
        [Display(Name ="Tên sản phẩm")]
        public string? Name { get; set; }
        /*[Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        [StringLength(100)]*/
        [Display(Name = "Tên nhà cung cấp")]
        public string? Provider { get; set; }       
        public int CategoryID { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Category? Category { get; set; }  
        
    }
}
