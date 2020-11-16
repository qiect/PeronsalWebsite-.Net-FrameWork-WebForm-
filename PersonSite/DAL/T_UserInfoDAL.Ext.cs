using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using System.Data.SqlClient;

namespace PersonSite.DAL
{
    public partial class T_UserInfoDAL
    {
        public int IncCredit(Guid userId, int credit)
        {
            //用ISNULL解决初始积分为null的问题
            //Credit字段为用户积分
            return SqlHelper.ExecuteNonQuery("Update T_UserInfos Set Credit=ISNULL(Credit,0)+@count where UserId=@UserId",
                new SqlParameter("@count", credit),
                new SqlParameter("@UserId",userId));
        }
    }
}