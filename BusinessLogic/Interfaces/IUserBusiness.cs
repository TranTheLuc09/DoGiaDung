using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IUserBusiness
    {
        Accounts Login(string taikhoan, string matkhau);
        bool Register(string taikhoan, string matkhau);
        bool Update(string fullname, string address, string phone, string username);
        Accounts GetInfo(string username);
        List<Accounts> GetAll();


        bool DeleteById(string id);
        bool UpdateByAdmin(UpdateModelByAdmin model);
    }
}
