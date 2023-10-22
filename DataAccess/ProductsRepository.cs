using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataModel;

namespace DataAccessLayer
{
    public class ProductsRepository : IProductsRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProductsRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Insert(Products products)
        {
            //string msgErr = "";
            //try
            //{
            //    var sql = String.Format("SELECT * FROM Categorys WHERE id = '{0}'",products.category_id);
            //    var row = _dbHelper.ExecuteQueryToDataTable(sql, out msgErr);
            //    if (row.ConvertTo<Accounts>().FirstOrDefault() != null)
            //    {
            //        return false;
            //    }
            //    sql = String.Format("INSERT INTO Products(name,price,quantity,description,category_id,image) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", products.name,products.price,products.quantity,products.description,products.category_id,products.image);
            //    _dbHelper.ExecuteNoneQuery(sql);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_product",
                "@name", products.name,
                "@price", products.price,
                "@quantity",products.quantity,
                "@description",products.description,
                "@category_id", products.category_id,
                "@image", products.image);
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

        public bool Update(Products products)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_product",
                "@name", products.name,
                "@price", products.price,
                "@quantity", products.quantity,
                "@description", products.description,
                "@category_id", products.category_id,
                "@image", products.image,
                "@id",products.id);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_product",
                "@id",id);
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

        public List<Products> GetList()
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getlist_product");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<Products>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Products GetById(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getlist_product_by_id","@id",id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<Products>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
