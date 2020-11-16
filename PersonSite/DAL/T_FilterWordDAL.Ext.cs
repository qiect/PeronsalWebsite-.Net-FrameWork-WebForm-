using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using System.Data.SqlClient;

namespace PersonSite.DAL
{
    public partial class T_FilterWordDAL
    {
        public T_FilterWord GetByWord(string word)
        {
            string sql = "SELECT * FROM T_FilterWords WHERE WordPattern=@WordPattern";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@WordPattern", word)))
            {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        public IEnumerable<T_FilterWord> GetBanned()
        {
            var list = new List<T_FilterWord>();
            string sql = "SELECT * FROM T_FilterWords where ReplaceWord='{BANNED}'";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<T_FilterWord> GetMod()
        {
            var list = new List<T_FilterWord>();
            string sql = "SELECT * FROM T_FilterWords where ReplaceWord='{MOD}'";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<T_FilterWord> GetReplace()
        {
            var list = new List<T_FilterWord>();
            string sql = "SELECT * FROM T_FilterWords where ReplaceWord<>'{MOD}' and ReplaceWord<>'{BANNED}'";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }
    }
}