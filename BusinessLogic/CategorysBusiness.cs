using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessLogicLayer
{
    public class CategorysBusiness : ICategorysBusiness
    {
        private ICategorysRepository _res;
        public CategorysBusiness(ICategorysRepository res)
        {
            _res = res;
        }

        public bool Insert(Categorys categorys)
        {
            return _res.Insert(categorys);
        }

        public bool Update(Categorys categorys)
        {
            return _res.Update(categorys);    
        }

        public bool Delete(string id) {
            return _res.Delete(id);
        }

        public List<Categorys> GetList()
        {
            return _res.GetList();
        }


    }
}
