using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.Product
{
    public class ProductResponseDTO
    {
        public int? Id { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Provider { get; set; }
        public string CategoryName { get; set; }
    }
}
