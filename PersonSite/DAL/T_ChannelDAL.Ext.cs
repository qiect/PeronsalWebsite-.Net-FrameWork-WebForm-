using PersonSite.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonSite.DAL
{
    public partial class T_ChannelDAL
    {
        public IEnumerable<T_Channel> GetByParentId(int parentId)
        {
            var list = new List<T_Channel>();
            string sql = "SELECT * FROM T_Channels WHERE ParentId = @ParentId";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@ParentId", parentId)))
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