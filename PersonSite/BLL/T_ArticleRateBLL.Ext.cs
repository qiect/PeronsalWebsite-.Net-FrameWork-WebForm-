using PersonSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonSite.BLL
{
	public partial class T_ArticleRateBLL
	{
        public int Get24HRateCount(string ip, int videoId)
        {
            return new T_ArticleRateDAL().Get24HRateCount(ip, videoId);
        }
	}
}