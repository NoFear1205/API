﻿using DomainLayer.Model;
using DomainLayer.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Interfaces;
using System.Security.Claims;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : Controller
    {
        private readonly IUserService _user;
        private readonly IUserRoleService _userrole;
        private readonly IAuthenService _authen;
        public AuthController(IUserService user, IUserRoleService userrole, IAuthenService authen)
        {
            _user = user;
            _userrole = userrole;
            _authen = authen;
        }
       
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!(model.Password == model.RePassword))
            {
                ModelState.AddModelError("RePassword", "Nhập lại mật khẩu không đúng");
                return BadRequest(ModelState);
            };
            if (_user.FindById(model.UserName) != null)
            {
                ModelState.AddModelError("Username", "Username is already");
                return BadRequest(ModelState);
            }
            _authen.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User()
            {
                Username = model.UserName,
                HashPassword = passwordHash,
                PasswordSalt = passwordSalt,
            };
            if (_user.Add(user)) 
            {
                var temp = _user.FindById(user.Username);
                foreach(var item in model.RoleID) {
                    _userrole.Add(new User_Role()
                    {
                        UserID = temp.Id,
                        RoleID = item
                    });
                }
                return Ok(user);
            }
            else 
                return BadRequest("Không thể thêm tài khoản");
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var temp = _user.FindById(model.Username);

            if (temp == null)
            {
                ModelState.AddModelError("Username", "Username in correct");
                return Unauthorized(ModelState);
            } else if (!_authen.VerifyPasswordHash(model.Password, temp.HashPassword, temp.PasswordSalt))
            {
                ModelState.AddModelError("Password", "Password in correct");
                return Unauthorized(ModelState);
            }
            List<string> roles = new List<string>();
            foreach (var item in _userrole.GetByUserId(temp.Id))
            {
                roles.Add(item.Roles.RoleName);
            };
            string token = _authen.CreateToken(temp, roles);

            RefreshToken refreshToken = _authen.GenerateRefreshToken(temp.Id);
            RefreshToken oldToken = _authen.GetRefreshToken(temp.Id);
            oldToken.refreshToken = refreshToken.refreshToken;
            oldToken.Expires = refreshToken.Expires;
            if (oldToken == null)
            {
                 _authen.AddRefreshToken(refreshToken);
            }
            else
            {
                 _authen.UpdateRefreshToken(oldToken);
            }
            return Ok(new Tokens() { AccessToken=token,RefreshToken=refreshToken.refreshToken});
        }
        [HttpPut("Changepassword")]
       //[AllowAnonymous]
        public IActionResult Changepassword([FromBody] ChangePasswordRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }else if(model.repassword != model.newpassword)
            {
                ModelState.AddModelError("repassword", "nhập lại mật khẩu không đúng");
                return BadRequest(ModelState);
            }
            string name = User.FindFirstValue(ClaimTypes.Role);
            var temp = _user.FindById(name);
            if (_authen.VerifyPasswordHash(model.password, temp.HashPassword, temp.PasswordSalt))
            {
                _authen.CreatePasswordHash(model.newpassword, out byte[] passwordHash, out byte[] passwordSalt);
                temp.HashPassword = passwordHash;
                temp.PasswordSalt = passwordSalt;
                if (_user.Update(temp))
                    return Ok("Đổi mật khẩu thành công");
                else return BadRequest("Xảy ra lỗi trong quá trình đổi mật khẩu");
            }
            else
            {
                ModelState.AddModelError("password", "Mật khẩu cũ không đúng");
                return BadRequest(ModelState);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] string RefreshToken, string username)
        {
            var user = _user.FindById(username);
            var temp = _authen.GetRefreshToken(user.Id);

            if (!temp.refreshToken.Equals(RefreshToken))
            {
                return Unauthorized("Invalid attempt!");
            }
            List<string> roles = new List<string>();
            foreach (var item in _userrole.GetByUserId(user.Id))
            {
                roles.Add(item.Roles.RoleName);
            };
            string newJwtToken = _authen.CreateToken(user, roles);
            if (newJwtToken == null)
            {
                return Unauthorized("Invalid attempt!");
            }
            return Ok(new Tokens() { AccessToken = newJwtToken, RefreshToken = temp.refreshToken });
        }
    }
}
