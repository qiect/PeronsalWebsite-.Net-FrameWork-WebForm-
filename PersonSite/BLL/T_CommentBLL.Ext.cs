using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.DAL;
using PersonSite.Model;

namespace PersonSite.BLL
{
    public partial class T_CommentBLL
    {
        public IEnumerable<T_Comment> GetByArticleId(int articleId)
        {
            return new T_CommentDAL().GetByArticleId(articleId);
        }

        public IEnumerable<T_Comment> GetModComments()
        {
            return new T_CommentDAL().GetModComments();
        }
    }
}