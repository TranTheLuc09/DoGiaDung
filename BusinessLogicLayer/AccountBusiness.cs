using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AccountBusiness : IAccountBusiness
    {
        IAccountRepository _res;
        public AccountBusiness(IAccountRepository res)
        {
            _res = res;
        }

        public List<Account> GetListAccount()
        {
            return _res.GetListAccount();
        }
    }
}
