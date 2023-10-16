using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountBusiness AccountBusiness;
        public AccountController(IAccountBusiness accountBusiness)
        {
            AccountBusiness = accountBusiness;
        }

        [HttpGet("getListAccount")]
        public List<Account> GetListAccount()
        {
            var result = AccountBusiness.GetListAccount();
            return result;
        }

    }
}
