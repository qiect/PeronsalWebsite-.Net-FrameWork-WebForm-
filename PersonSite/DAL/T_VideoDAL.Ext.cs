using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PersonSite.DAL
{
    public partial class T_VideoDAL
    {
        public void Rate(int videoId, int action)
        {
            if (action == -1)
            {
                SqlHelper.ExecuteNonQuery("Update T_Videos set CaiCount=CaiCount+1 where Id=@Id",
                    new SqlParameter("@Id",videoId));
            }
            else if (action == 1)
            {
                SqlHelper.ExecuteNonQuery("Update T_Videos set DingCount=DingCount+1 where Id=@Id",
                    new SqlParameter("@Id", videoId));
            }
        }
    }
}