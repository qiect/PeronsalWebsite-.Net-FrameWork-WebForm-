using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PersonSite.DAL
{
    public partial class T_VideoRateDAL
    {
        public int Get24HRateCount(string ip, int videoId)
        {
            return (int)SqlHelper.ExecuteScalar("select count(*) from T_VideoRates where IP=@IP and VideoId=@videoId and datediff(hour,CreateDate,getdate())<=24",
                new SqlParameter("@IP", ip),
                new SqlParameter("@videoId", videoId));
        }
    }
}