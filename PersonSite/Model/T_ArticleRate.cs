using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonSite.Model
{
    [Serializable()]
    public class T_ArticleRate
    {
        public int Id
        {
            get;
            set;
        }
        public int ArticleId
        {
            get;
            set;
        }
        public int Action
        {
            get;
            set;
        }
        public DateTime CreateDate
        {
            get;
            set;
        }
        public string IP
        {
            get;
            set;
        }
    }
}