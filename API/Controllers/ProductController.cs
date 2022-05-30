using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModel.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Interfaces;
using System.Net;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        private readonly IMapper _mapper;
        public ProductController(IProductService product,IMapper mapper)
        {
            _product = product;
            _mapper = mapper; 
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page, string searchValue)
        {

            if (searchValue == null)
                searchValue = "";
            int pageSize = 2;
            if (page <= 0)
                page = 1;
            var temp = _product.GetAll(page,pageSize,searchValue);
            List<ProductResponseDTO> products = new List<ProductResponseDTO>();   
            foreach(var item in temp)
            {
                products.Add(_mapper.Map<ProductResponseDTO>(item));
            }
            return Ok(products);
        }
        [HttpPost]
        public  async Task<IActionResult> Create(ProductRequestDTO model)
        {
            var temp = _mapper.Map<Product>(model);
            if (ModelState.IsValid)
            {
                return Ok(_product.Add(temp));
            }
            else return BadRequest(ModelState);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(ProductRequestDTO model)
        {
            var temp = _mapper.Map<Product>(model);
            if (ModelState.IsValid)
            {
                return Ok(_product.Update(temp));
            }
            else return BadRequest(ModelState);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var model = _product.FindById(id);
            if (model == null)
            {
                return NotFound("không tìm thấy record muốn xóa");
            }
            else return Ok(_product.Delete(id));
        }
    }
}
