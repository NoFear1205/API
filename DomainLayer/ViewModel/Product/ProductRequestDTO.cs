using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModel.Product
{
    public class ProductRequestDTO
    {
        public int? Id { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage ="Tên sản phẩm không được để trống")]
        [MaxLength(30)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        [MaxLength(100)]
        public string? Provider { get; set; }
        public int CategoryID { get; set; }
    }
}
