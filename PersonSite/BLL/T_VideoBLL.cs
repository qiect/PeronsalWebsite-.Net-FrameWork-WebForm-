using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_VideoBLL
    {
        public T_Video Add(T_Video rP_Video)
        {
            return new T_VideoDAL().Add(rP_Video);
        }

        public int DeleteById(int id)
        {
            return new T_VideoDAL().DeleteById(id);
        }

		public int Update(T_Video rP_Video)
        {
            return new T_VideoDAL().Update(rP_Video);
        }
        

        public T_Video GetById(int id)
        {
            return new T_VideoDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_VideoDAL().GetTotalCount();
		}
		
		public IEnumerable<T_Video> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_VideoDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_Video> GetAll()
		{
			return new T_VideoDAL().GetAll();
		}
    }
}
