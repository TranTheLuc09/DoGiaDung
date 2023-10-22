using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer.Interfaces
{
    public partial interface IOrderRepository
    {
        string Insert(List<OrderProductModel> lstProducts,Orders orders,string username);
        bool Update(Orders orders);
        bool Delete(string id);
        List<Orders> GetList(string username);
        Orders GetByID(string id, string username);
        List<OrderDetails> GetOrderDetails(string id, string username);

        List<Orders> GetListByAdmin();
        List<OrderDetails> GetOrderDetailsByAdmin(string id);
    }
}
