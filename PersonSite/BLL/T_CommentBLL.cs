using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_CommentBLL
    {
        public T_Comment Add(T_Comment rP_Comment)
        {
            return new T_CommentDAL().Add(rP_Comment);
        }

        public int DeleteById(int id)
        {
            return new T_CommentDAL().DeleteById(id);
        }

		public int Update(T_Comment rP_Comment)
        {
            return new T_CommentDAL().Update(rP_Comment);
        }
        

        public T_Comment GetById(int id)
        {
            return new T_CommentDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_CommentDAL().GetTotalCount();
		}
		
		public IEnumerable<T_Comment> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_CommentDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_Comment> GetAll()
		{
			return new T_CommentDAL().GetAll();
		}
    }
}
