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
    public class ProductsBusiness : IProductsBusiness
    {
        private IProductsRepository _res;
        public ProductsBusiness(IProductsRepository res)
        {
            _res = res;
        }

        public bool Insert(Products products)
        {
            return _res.Insert(products);
        }

        public bool Update(Products products)
        {
            return _res.Update(products);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public List<Products> GetList()
        {
            return _res.GetList();
        }

        public Products GetById(string id)
        {
            return _res.GetById(id);
        }
    }
}
