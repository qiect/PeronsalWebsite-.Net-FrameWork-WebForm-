using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_AdPositionBLL
    {
        public T_AdPosition Add(T_AdPosition rP_AdPosition)
        {
            return new T_AdPositionDAL().Add(rP_AdPosition);
        }

        public int DeleteById(int id)
        {
            return new T_AdPositionDAL().DeleteById(id);
        }

		public int Update(T_AdPosition rP_AdPosition)
        {
            return new T_AdPositionDAL().Update(rP_AdPosition);
        }
        

        public T_AdPosition GetById(int id)
        {
            return new T_AdPositionDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_AdPositionDAL().GetTotalCount();
		}
		
		public IEnumerable<T_AdPosition> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_AdPositionDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_AdPosition> GetAll()
		{
			return new T_AdPositionDAL().GetAll();
		}
    }
}
