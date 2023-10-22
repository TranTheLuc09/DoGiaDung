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
    public class OrdersBusiness : IOrdersBusiness
    {
        private IOrderRepository _res;
        public OrdersBusiness(IOrderRepository res)
        {
            _res = res;
        }
        public string Insert(List<OrderProductModel> lstProducts, Orders orders, string username)
        {
            return _res.Insert(lstProducts, orders, username);
        }

        public bool Update(Orders orders)
        {
            return _res.Update(orders);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<Orders> GetList(string username)
        {
            return _res.GetList(username);
        }
        public Orders GetByID(string id, string username)
        {
            return _res.GetByID(id,username);
        }
        public List<OrderDetails> GetOrderDetails(string id, string username)
        {
            return _res.GetOrderDetails(id,username);
        }

        public List<Orders> GetListByAdmin()
        {
            return _res.GetListByAdmin();
        }
        public List<OrderDetails> GetOrderDetailsByAdmin(string id)
        {
            return _res.GetOrderDetailsByAdmin(id);
        }
    }
}
