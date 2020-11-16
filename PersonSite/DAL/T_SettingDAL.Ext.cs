using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using System.Data.SqlClient;

namespace PersonSite.DAL
{
    public partial class T_SettingDAL
    {
        public T_Setting GetByName(string name)
        {
            string sql = "SELECT * FROM T_Settings WHERE Name = @Name";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Name", name)))
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
    }
}