using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using DataModel;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebHoaQua.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private ICategorysBusiness _categorysBusiness;
        public CategorysController(ICategorysBusiness categorysBusiness) {
            _categorysBusiness = categorysBusiness;
        }

        [AllowAnonymous]
        [HttpGet("getlist")]
        public List<Categorys> Get() {
            return _categorysBusiness.GetList();
        }

    }
}
