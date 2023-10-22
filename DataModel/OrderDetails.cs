using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class OrderDetails
    {
        public int id { get; set; }
        public string order_id { get; set; }
        public int product_id { get; set; }
        public string product_name {  get; set; }
        public int quantity { get; set; }
        public string image { get; set; }
        public string total_price { get; set; }
    }
}
