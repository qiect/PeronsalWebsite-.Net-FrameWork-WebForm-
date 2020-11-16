using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_UserInfoBLL
    {
        public T_UserInfo Add(T_UserInfo rP_UserInfo)
        {
            return new T_UserInfoDAL().Add(rP_UserInfo);
        }

        public int DeleteByUserId(Guid userId)
        {
            return new T_UserInfoDAL().DeleteByUserId(userId);
        }

		public int Update(T_UserInfo rP_UserInfo)
        {
            return new T_UserInfoDAL().Update(rP_UserInfo);
        }
        

        public T_UserInfo GetByUserId(Guid userId)
        {
            return new T_UserInfoDAL().GetByUserId(userId);
        }
		public int GetTotalCount()
		{
			return new T_UserInfoDAL().GetTotalCount();
		}
		
		public IEnumerable<T_UserInfo> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_UserInfoDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_UserInfo> GetAll()
		{
			return new T_UserInfoDAL().GetAll();
		}
    }
}
