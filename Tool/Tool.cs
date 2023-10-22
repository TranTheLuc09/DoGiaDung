using System;
using System.Collections.Generic;
using DataModel;
using Newtonsoft.Json;

namespace Tool
{
    public class ToolS
    {
        public string InsertQuery(string table, Dictionary<string, object> datas)
        {
            string columns = "";
            string values = "";
            foreach (var data in datas)
            {
               columns += data.Key + ",";
               values += data.Value + ",";
            }

            var sql = String.Format("INSERT INTO {0}({1}) VALUES ({2})",table,columns.TrimEnd(','),values.TrimEnd(','));
            return sql;
        }

        public string UpdateQuery(string table, Dictionary<string,object> datas, string where)
        {
            string set = "";
            foreach (var data in datas)
            {
                set += data.Key + "=" + data.Value + ",";
            }
            var sql = String.Format("UPDATE {0} SET {1} WHERE {2}", table, set.TrimEnd(','), where);
            return sql;
        }

        public string DeleteQuery(string table, string where)
        {
            var sql = String.Format("DELETE FROM {0} WHERE {1}", table, where);
            return sql;
        }


    }
}