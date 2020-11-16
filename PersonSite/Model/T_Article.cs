//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{
    [Serializable()]
    public class T_Article
    {
        public int Id
        {
            get;
            set;
        }
        public int ChannelId
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public DateTime PostDate
        {
            get;
            set;
        }
        public string Msg
        {
            get;
            set;
        }
        public string StaticPath
        {
            get;
            set;
        }

        private int _dingCount;
        public int DingCount
        {
            get
            {
                return _dingCount;
            }
            set
            {
                _dingCount = string.IsNullOrEmpty(value.ToString()) ? 0 : value;
            }
        }

        private int _caiCount;
        public int CaiCount
        {
            get
            {
                return _caiCount;
            }
            set
            {
                _caiCount = string.IsNullOrEmpty(value.ToString()) ? 0 : value;
            }
        }


    }
}
