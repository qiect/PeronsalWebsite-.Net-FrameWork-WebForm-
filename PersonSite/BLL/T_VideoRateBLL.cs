using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_VideoRateBLL
    {
        public T_VideoRate Add(T_VideoRate rP_VideoRate)
        {
            return new T_VideoRateDAL().Add(rP_VideoRate);
        }

        public int DeleteById(int id)
        {
            return new T_VideoRateDAL().DeleteById(id);
        }

		public int Update(T_VideoRate rP_VideoRate)
        {
            return new T_VideoRateDAL().Update(rP_VideoRate);
        }
        

        public T_VideoRate GetById(int id)
        {
            return new T_VideoRateDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_VideoRateDAL().GetTotalCount();
		}
		
		public IEnumerable<T_VideoRate> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_VideoRateDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_VideoRate> GetAll()
		{
			return new T_VideoRateDAL().GetAll();
		}
    }
}
