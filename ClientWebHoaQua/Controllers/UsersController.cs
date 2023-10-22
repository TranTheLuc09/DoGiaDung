using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHoaQua.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBusiness.Login(model.Username, model.Password);
            if (user == null)
                return Ok(new
                {
                    status = false,
                    message = "Tài khoản hoặc mật khẩu không chính xác !"
                });

            return Ok(new {
                status = true,
                username = user.username,
                token = user.token 
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            bool register = _userBusiness.Register(model.username, model.password);
            if(!register)
            {
                return Ok(new
                {
                    status = false,
                    message = "Đăng kí tài khoản không thành công !"
                });
            }

            return Ok(new
            {
                status = true,
                message = "Đăng kí tài khoản thành công !",
                username = model.username,
                password = model.password
            });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateModel model)
        {
            bool update = _userBusiness.Update(model.fullname, model.address, model.phone, User.Identity.Name);
            if (update)
            {
                return Ok(new
                {
                    status = true,
                    message = "Cập nhật thông tin thành công!"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    message = "Cập nhật thông tin thất bại!"
                });
            }
        }

        [HttpPost("getinfo")]
        public IActionResult GetInfo()
        {
            var results = _userBusiness.GetInfo(User.Identity.Name) ;
            return Ok(results);
        }

        [HttpPost("checkaccount")]
        public IActionResult CheckAccounts()
        {
            return Ok(new
            {
                status = true
            });
        }
    }
}
