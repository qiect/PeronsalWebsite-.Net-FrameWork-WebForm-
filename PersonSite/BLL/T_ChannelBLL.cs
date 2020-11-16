using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_ChannelBLL
    {
        public T_Channel Add(T_Channel rP_Channel)
        {
            return new T_ChannelDAL().Add(rP_Channel);
        }

        public int DeleteById(int id)
        {
            return new T_ChannelDAL().DeleteById(id);
        }

		public int Update(T_Channel rP_Channel)
        {
            return new T_ChannelDAL().Update(rP_Channel);
        }
        

        public T_Channel GetById(int id)
        {
            return new T_ChannelDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_ChannelDAL().GetTotalCount();
		}
		
		public IEnumerable<T_Channel> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_ChannelDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_Channel> GetAll()
		{
			return new T_ChannelDAL().GetAll();
		}
    }
}
