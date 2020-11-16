using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.DAL;

namespace PersonSite.BLL
{
    public partial class T_VideoBLL
    {
        public void Ding(int videoId)
        {
            new T_VideoDAL().Rate(videoId, 1);
        }

        public void Cai(int videoId)
        {
            new T_VideoDAL().Rate(videoId, -1);
        }
    }
}