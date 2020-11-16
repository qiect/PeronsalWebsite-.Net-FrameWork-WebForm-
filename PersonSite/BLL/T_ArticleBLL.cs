using System;
using System.Collections.Generic;
using System.Text;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]
    public partial class T_ArticleBLL
    {
        public T_Article Add(T_Article rP_Article)
        {
            return new T_ArticleDAL().Add(rP_Article);
        }

        public int DeleteById(int id)
        {
            return new T_ArticleDAL().DeleteById(id);
        }

		public int Update(T_Article rP_Article)
        {
            return new T_ArticleDAL().Update(rP_Article);
        }
        

        public T_Article GetById(int id)
        {
            return new T_ArticleDAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new T_ArticleDAL().GetTotalCount();
		}
		
		public IEnumerable<T_Article> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_ArticleDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_Article> GetAll()
		{
			return new T_ArticleDAL().GetAll();
		}
    }
}
