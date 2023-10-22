using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataAccessLayer.Helper;

namespace DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private IDatabaseHelper _dbHelper;
        private IProductsRepository _productsRepository;
        private Tool tool;
        public OrderRepository(IDatabaseHelper dbHelper,IProductsRepository productsRepository)
        {
            _dbHelper = dbHelper;
            _productsRepository = productsRepository;
            tool = new Tool();
        }

        public string Insert(List<OrderProductModel> lstProducts, Orders orders,string username)
        {
            try
            {
                if(lstProducts.Count == 0)
                {
                    return "no_item_in_order";
                }

                if(username != orders.username)
                {
                    return "username_false";
                }

                var orderCode = tool.RandomText(10);


                string msgError = "";
                try
                {
                    var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_orders",
                    "@id",orderCode,
                    "@username",username,
                    "@address",orders.address,
                    "@phone",orders.phone,
                    "@status","Đang xử lý");
                    if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(Convert.ToString(result) + msgError);
                    }
                }
                catch (Exception ex)
                {
                    return "create_order_error: " + ex.ToString();
                }

                foreach(var item in lstProducts)
                {
                    Products product = _productsRepository.GetById(item.id.ToString());

                    if(product == null)
                    {
                        continue;
                    }
                    if(item.quantity > product.quantity)
                    {
                        continue;
                    }

                    var result = _dbHelper.ExecuteNoneQuery(String.Format("INSERT INTO OrderDetails (order_id,product_id,product_name,quantity,image,total_price) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", orderCode, product.id, product.name, item.quantity, product.image, item.quantity * product.price));
                    if(string.IsNullOrEmpty(result))
                    {
                        _dbHelper.ExecuteNoneQuery(String.Format("UPDATE Products SET quantity = '{0}' WHERE id = '{1}'", product.quantity - item.quantity, product.id));
                    }
                    
                }
                return "create_order_success";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public bool Update(Orders orders)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_orders",
                "@status", orders.status,
                "@id",orders.id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_orders",
                "@id", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Orders> GetList(string username)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getlist_orders",
                "@username", username);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<Orders>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Orders GetByID(string id, string username)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getlist_orders_by_id",
                "@username", username,
                "@id",id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<Orders>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<OrderDetails> GetOrderDetails(string id, string username)
        {
            Orders orders = GetByID(id, username);
            if(orders == null)
            {
                return null;
            }

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_order_details",
                "@id", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<OrderDetails>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public List<Orders> GetListByAdmin()
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getlist_orders_by_admin");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<Orders>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<OrderDetails> GetOrderDetailsByAdmin(string id)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_order_details",
                "@id", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<OrderDetails>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
