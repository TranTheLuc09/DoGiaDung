using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataModel;

namespace DataAccessLayer
{
    public class AccountRepository : IAccountRepository
    {
        private IDatabaseHelper _dbHelper;

        public AccountRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<Account> GetListAccount()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getlistacount");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Account>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
