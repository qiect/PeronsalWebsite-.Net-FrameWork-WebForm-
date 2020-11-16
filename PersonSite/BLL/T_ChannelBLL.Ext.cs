using PersonSite.DAL;
using PersonSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonSite.BLL
{
    public partial class T_ChannelBLL
    {
        /// <summary>
        /// 获取国内频道列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_Channel> GetListByCn()
        {
            return new T_ChannelDAL().GetByParentId(2);
        }
        /// <summary>
        /// 获取顶级频道列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IEnumerable<T_Channel> GetListByParent()
        {
            return new T_ChannelDAL().GetByParentId(0);
        }
    }
}