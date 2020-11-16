using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using PersonSite.DAL;

namespace PersonSite.BLL
{
    public partial class T_AdBLL
    {
        public T_Ad GetRandomAdByPosition(int positionId)
        {
            return new T_AdDAL().GetRandomAdByPosition(positionId);
        }
    }
}