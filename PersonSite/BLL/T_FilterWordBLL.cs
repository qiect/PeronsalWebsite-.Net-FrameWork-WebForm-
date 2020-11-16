using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_FilterWordBLL
    {
        public T_FilterWord Add(T_FilterWord rP_FilterWord)
        {
            return new T_FilterWordDAL().Add(rP_FilterWord);
        }

        public int DeleteById(int id)
        {
            return new T_FilterWordDAL().DeleteById(id);
        }

		public int Update(T_FilterWord rP_FilterWord)
        {
            return new T_FilterWordDAL().Update(rP_FilterWord);
        }
        

        public T_FilterWord GetById(int id)
        {
            return new T_FilterWordDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_FilterWordDAL().GetTotalCount();
		}
		
		public IEnumerable<T_FilterWord> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_FilterWordDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_FilterWord> GetAll()
		{
			return new T_FilterWordDAL().GetAll();
		}
    }
}
