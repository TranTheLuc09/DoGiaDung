using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BusinessLogicLayer.Interfaces;

namespace WebHoaQua.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsBusiness _productsBusiness;
        public ProductsController(IProductsBusiness productsBusiness)
        {
            _productsBusiness = productsBusiness;
        }

        [AllowAnonymous]
        [HttpGet("getlist")]
        public List<Products> GetList()
        {
            return _productsBusiness.GetList();
        }

        [AllowAnonymous]
        [HttpGet("getbyid/{id}")]
        public Products GetByID(string id)
        {
            return _productsBusiness.GetById(id);
        }

    }
}
