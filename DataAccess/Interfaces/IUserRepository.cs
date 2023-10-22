using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer.Interfaces
{
    public partial interface IUserRepository
    {
        Accounts Login(string username, string password);
        bool Register(string username, string password);
        bool Update(string fullname,string address,string phone,string username);
        Accounts GetInfo(string username);
        List<Accounts> GetAll();

        bool DeleteById(string id);
        bool UpdateByAdmin(UpdateModelByAdmin model);
    }
}
