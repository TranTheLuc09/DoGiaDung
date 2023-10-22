using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface ICategorysBusiness
    {
        bool Insert(Categorys categorys);
        bool Update(Categorys categorys);
        bool Delete(string id);
        List<Categorys> GetList();
    }
}
