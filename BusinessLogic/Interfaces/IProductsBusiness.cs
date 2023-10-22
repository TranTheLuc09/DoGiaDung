using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IProductsBusiness
    {
        bool Insert(Products products);
        bool Update(Products products);
        bool Delete(string id);
        List<Products> GetList();
        Products GetById(string id);
    }
}
