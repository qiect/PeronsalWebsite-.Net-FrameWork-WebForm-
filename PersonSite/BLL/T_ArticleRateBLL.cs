using PersonSite.DAL;
using PersonSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonSite.BLL
{
    [System.ComponentModel.DataObject]

    public partial class T_ArticleRateBLL
    {
        public T_ArticleRate Add(T_ArticleRate rP_VideoRate)
        {
            return new T_ArticleRateDAL().Add(rP_VideoRate);
        }

        public int DeleteById(int id)
        {
            return new T_ArticleRateDAL().DeleteById(id);
        }

        public int Update(T_ArticleRate rP_VideoRate)
        {
            return new T_ArticleRateDAL().Update(rP_VideoRate);
        }


        public T_ArticleRate GetById(int id)
        {
            return new T_ArticleRateDAL().GetById(id);
        }
        public int GetTotalCount()
        {
            return new T_ArticleRateDAL().GetTotalCount();
        }

        public IEnumerable<T_ArticleRate> GetPagedData(int minrownum, int maxrownum)
        {
            return new T_ArticleRateDAL().GetPagedData(minrownum, maxrownum);
        }

        public IEnumerable<T_ArticleRate> GetAll()
        {
            return new T_ArticleRateDAL().GetAll();
        }
    }
}