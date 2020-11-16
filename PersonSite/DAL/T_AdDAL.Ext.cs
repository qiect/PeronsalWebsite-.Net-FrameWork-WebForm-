using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using System.Data.SqlClient;

namespace PersonSite.DAL
{
    public partial  class T_AdDAL
    {
        /// <summary>
        /// 得到positionId=positionId的随机一条广告
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public T_Ad GetRandomAdByPosition(int positionId)
        {
            //随机取一条数据，因为newid()生成的字符串是随机的
            string sql = "select top 1 * from T_Ads where PositionId=@posId  order by newid()";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@posId", positionId)))
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