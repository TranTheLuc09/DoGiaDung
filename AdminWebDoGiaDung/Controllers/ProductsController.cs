using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BusinessLogicLayer.Interfaces;

namespace WebHoaQua.Controllers
{

    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsBusiness _productsBusiness;
        public ProductsController(IProductsBusiness productsBusiness)
        {
            _productsBusiness = productsBusiness;
        }

        //Lấy danh sạch sản phẩm OK 
        [HttpGet("getlist")]
        public List<Products> GetList()
        {
            return _productsBusiness.GetList();
        }

        //Láy thông tin sản phẩm OK 
        [HttpGet("getbyid/{id}")]
        public Products GetByID(string id)
        {
            return _productsBusiness.GetById(id);
        }


        //Thêm sản phẩm OK 
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] Products products)
        {
            bool result = _productsBusiness.Insert(products);
            if (result)
            {
                return Ok(new
                {
                    status = true,
                    message = "Thêm sản phẩm thành công !",
                    data = products
                });
            }
            return Ok(new
            {
                status = false,
                message = "Thêm sản phẩm thất bại !",
                data = products
            });
        }

        //Cập nhật sản phẩm OK 
        [HttpPost("update")]
        public IActionResult Update([FromBody] Products products)
        {
            bool result = _productsBusiness.Update(products);
            if (result)
            {
                return Ok(new
                {
                    status = true,
                    message = "Cập nhật sản phẩm thành công !",
                });
            }
            return Ok(new
            {
                status = false,
                message = "Cập nhật sản phẩm thất bại !",
            });
        }

        //Xóa sản phẩm OK 
        [HttpPost("delete/{id}")]
        public IActionResult Delete(string id)
        {
            bool result = _productsBusiness.Delete(id);
            if (result)
            {
                return Ok(new
                {
                    status = true,
                    message = "Xóa sản phẩm thành công !",
                });
            }
            return BadRequest(new
            {
                status = false,
                message = "Xóa sản phẩm thất bại !",
            });
        }
    }
}
