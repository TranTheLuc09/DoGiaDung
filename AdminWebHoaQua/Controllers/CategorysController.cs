using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using DataModel;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebHoaQua.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private ICategorysBusiness _categorysBusiness;
        public CategorysController(ICategorysBusiness categorysBusiness)
        {
            _categorysBusiness = categorysBusiness;
        }

        [HttpGet("getlist")]
        public List<Categorys> Get()
        {
            return _categorysBusiness.GetList();
        }


        [HttpPost("insert")]
        public IActionResult Insert([FromBody] Categorys category)
        {
            bool result = _categorysBusiness.Insert(category);
            if (result)
            {
                return Ok(new
                {
                    status = true,
                    message = "Thêm danh mục thành công !",
                    data = category
                });
            }
            return BadRequest(new
            {
                status = true,
                message = "Thêm danh mục thất bại !",
                data = category
            });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] Categorys category)
        {
            bool result = _categorysBusiness.Update(category);
            if (result)
            {
                return Ok(new
                {
                    status = true,
                    message = "Sửa danh mục thành công !",
                    data = category
                });
            }
            return BadRequest(new
            {
                status = true,
                message = "Sửa danh mục thất bại !",
                data = category
            });
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(string id)
        {
            bool reusult = _categorysBusiness.Delete(id);
            if (reusult)
            {
                return Ok(new
                {
                    status = true,
                    message = "Xóa danh mục thành công !"
                });
            }
            return BadRequest(new
            {
                status = true,
                message = "Xóa danh mục thất bại !"
            });

        }

    }
}
