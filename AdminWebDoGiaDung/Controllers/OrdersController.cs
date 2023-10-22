using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;

namespace WebHoaQua.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersBusiness ordersBusiness;
        public OrdersController(IOrdersBusiness ordersBusiness)
        {
            this.ordersBusiness = ordersBusiness;
        }

        //[HttpPost("insert")]
        //public IActionResult Insert(CreateOrderModel createOrderModel)
        //{

        //    var result = ordersBusiness.Insert(createOrderModel.listProducts, createOrderModel.orders, User.Identity.Name);
        //    return Ok(new
        //    {
        //        message = result,
        //    });
        //}

        [HttpPost("update")]
        public IActionResult Update(Orders orders)
        {
            var result = ordersBusiness.Update(orders);
            return Ok(new
            {
                message = result
            });
        }

        [HttpPost("delete/{id}")]
        public IActionResult Update(string id)
        {
            var result = ordersBusiness.Delete(id);
            return Ok(new
            {
                message = result
            });
        }


        [HttpPost("getlist")]
        public IActionResult GetList()
        {
            var result = ordersBusiness.GetListByAdmin();
            return Ok(new
            {
                result
            });
        }

        //[HttpPost("getbyid/{id}")]
        //public IActionResult GetByID(string id)
        //{
        //    var result = ordersBusiness.GetByID(id, User.Identity.Name);
        //    return Ok(new
        //    {
        //        result
        //    });
        //}

        [HttpGet("details/{id}")]
        public IActionResult GetDetails(string id)
        {
            var result = ordersBusiness.GetOrderDetailsByAdmin(id);
            return Ok(new
            {
                result
            });
        }
    }
}
