using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_AdBLL
    {
        public T_Ad Add(T_Ad rP_Ad)
        {
            return new T_AdDAL().Add(rP_Ad);
        }

        public int DeleteById(int id)
        {
            return new T_AdDAL().DeleteById(id);
        }

		public int Update(T_Ad rP_Ad)
        {
            return new T_AdDAL().Update(rP_Ad);
        }
        

        public T_Ad GetById(int id)
        {
            return new T_AdDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_AdDAL().GetTotalCount();
		}
		
		public IEnumerable<T_Ad> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_AdDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_Ad> GetAll()
		{
			return new T_AdDAL().GetAll();
		}
    }
}
