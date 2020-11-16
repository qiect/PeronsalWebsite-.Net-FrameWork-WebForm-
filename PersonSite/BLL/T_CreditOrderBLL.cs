using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{

    public partial class T_CreditOrderBLL
    {
        public T_CreditOrder Add(T_CreditOrder rP_CreditOrder)
        {
            return new T_CreditOrderDAL().Add(rP_CreditOrder);
        }

        public int DeleteById(int id)
        {
            return new T_CreditOrderDAL().DeleteById(id);
        }

		public int Update(T_CreditOrder rP_CreditOrder)
        {
            return new T_CreditOrderDAL().Update(rP_CreditOrder);
        }
        

        public T_CreditOrder GetById(int id)
        {
            return new T_CreditOrderDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_CreditOrderDAL().GetTotalCount();
		}
		
		public IEnumerable<T_CreditOrder> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_CreditOrderDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_CreditOrder> GetAll()
		{
			return new T_CreditOrderDAL().GetAll();
		}
    }
}
