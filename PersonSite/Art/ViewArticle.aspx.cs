using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;

namespace PersonSite.Art
{
    public partial class ViewArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strId = Request["id"];
            int id;
            if (!int.TryParse(strId, out id))
            {
                Response.Write("编号错误");
            }
            else
            {
                T_ArticleBLL bll = new T_ArticleBLL();
                var article = bll.GetById(id);
                litTitle.Text = article.Title;
                libPostDate.Text = article.PostDate.ToString();
                litMsg.Text = article.Msg;
            }
        }
    }
}