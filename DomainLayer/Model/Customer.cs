using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public  class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Display(Name ="Tên khách hàng")]
        [Required(ErrorMessage ="Tên khách hàng không được để trống")]
        [StringLength(30)]
        public string? CustomerName { get; set; }
        [Display(Name ="Địa chỉ")]
        [Required(ErrorMessage ="Địa chỉ không được để trống")]
        public string?  Address { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage ="Số điện thoại không được để trống")]
        [StringLength(10)]
        [Phone]
        public string? Phone { get; set; }
        [Display(Name ="Ngày sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Ngày sinh không được để trống")]
        public DateTime Birthday { get; set; }

    }
}
