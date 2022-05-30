using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Category;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _cate;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService cate,IMapper mapper)
        {
            _cate = cate;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = _cate.GetAll();
            List<CategoryResponseDTO> result = new List<CategoryResponseDTO>();
            foreach (var item in list)
            {
                result.Add(_mapper.Map<CategoryResponseDTO>(item));
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryRequestDTO model)
        {
            var temp = _mapper.Map<Category>(model);
            if (ModelState.IsValid)
            {
                return Ok(_cate.Add(temp));
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CategoryRequestDTO model)
        {
            var temp = _mapper.Map<Category>(model);
            if (ModelState.IsValid)
            {
                return Ok(_cate.Update(temp));
            }
            else return BadRequest(ModelState);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var model = _cate.GetById(id);
            if ( model == null)
            {
                return NotFound("Không tìm thấy record cần xóa");
            }else if (!_cate.InUsed(id))
            {
                return BadRequest("Record không thể xóa");
            }
            else
            {
                return Ok(_cate.Delete(model));
            }
        }
    }
}
