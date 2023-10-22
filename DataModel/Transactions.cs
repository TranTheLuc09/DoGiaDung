using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Transactions
    {
        public int id { get; set; }
        public string username { get; set; }
        public int before_money { get; set; }
        public int change_money { get; set; }
        public int after_money { get; set; }
        public string content { get; set; }
        public DateTime date_created { get; set; }
    }
}
