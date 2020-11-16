using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.DAL;

namespace PersonSite.BLL
{
    public partial class T_VideoRateBLL
    {
        public int Get24HRateCount(string ip, int videoId)
        {
            return new T_VideoRateDAL().Get24HRateCount(ip, videoId);
        }
    }
}