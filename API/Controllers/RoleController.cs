using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IRoleService _role;
        private readonly IMapper _mapper;
        
        public RoleController(IRoleService role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }
        [HttpGet]
        public  IActionResult List()
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            foreach(var item in _role.List())
            {
                roles.Add(_mapper.Map<RoleDTO>(item));
            }
            return Ok(roles);
        }
        [HttpPost]
        public IActionResult Add(RoleDTO model)
        {
            var temp = _mapper.Map<Role>(model);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_role.Add(temp))
            {
                return Ok("Add record succesfully");
            }
            else
                return BadRequest("Can't add record"); 
        }
        [HttpPut]
        public IActionResult Update(RoleDTO model)
        {
            var temp = _mapper.Map<Role>(model);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_role.Update(temp))
            {
                return Ok("Update record succesfully");
            }
            else
                return BadRequest("Can't add record");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var model = _role.Get(id);
            if (model != null)
            {
                if (_role.Delete(model))
                {
                    return Ok("Delete record succesfully");
                }
                else
                    return BadRequest("Can't Delete record");
            }
            else
            {
                return BadRequest("Record not found");
            }
            
        }
    }
}
