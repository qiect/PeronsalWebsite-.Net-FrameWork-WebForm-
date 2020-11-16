using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{

    public partial class T_SettingBLL
    {
        public T_Setting Add(T_Setting rP_Setting)
        {
            return new T_SettingDAL().Add(rP_Setting);
        }

        public int DeleteById(int id)
        {
            return new T_SettingDAL().DeleteById(id);
        }

		public int Update(T_Setting rP_Setting)
        {
            return new T_SettingDAL().Update(rP_Setting);
        }
        

        public T_Setting GetById(int id)
        {
            return new T_SettingDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_SettingDAL().GetTotalCount();
		}
		
		public IEnumerable<T_Setting> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_SettingDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_Setting> GetAll()
		{
			return new T_SettingDAL().GetAll();
		}
    }
}
