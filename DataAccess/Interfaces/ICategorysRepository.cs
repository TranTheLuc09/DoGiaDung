using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer.Interfaces
{
    public partial interface ICategorysRepository
    {
        bool Insert(Categorys categorys);
        bool Update (Categorys categorys);
        bool Delete(string id);
        List<Categorys> GetList();
    }
}
