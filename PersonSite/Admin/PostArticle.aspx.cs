using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;
using PersonSite.Model;
using PersonSite.Search;

namespace PersonSite.Admin
{
    public partial class PostArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                T_ChannelBLL chaBll = new T_ChannelBLL();
                ddlChannel.DataSource = chaBll.GetAll();
                ddlChannel.DataTextField = "Name";
                ddlChannel.DataValueField = "Id";
                ddlChannel.DataBind();

                string action = Request["action"];
                if (action == "edit")
                {
                    int id = Convert.ToInt32(Request["id"]);
                    T_ArticleBLL bll = new T_ArticleBLL();
                    var art = bll.GetById(id);
                    ddlChannel.SelectedValue = art.ChannelId.ToString();
                    txtTitle.Text = art.Title;
                    txtMsg.Text = art.Msg;
                    txtDingCount.Text = art.DingCount.ToString();
                    txtCaiCount.Text = art.CaiCount.ToString();
                    litPostDate.Text = art.PostDate.ToString();

                }
                else if (action == "addnew")
                {

                }
                else
                {
                    Response.Write("参数错误");
                }
            }

        }



        protected void btnPost_Click(object sender, EventArgs e)
        {
            string action = Request["action"];
            if (action == "edit")
            {
                //如果action=edit则是编辑一条数据
                int id = Convert.ToInt32(Request["id"]);
                T_ArticleBLL bll = new T_ArticleBLL();
                //先从数据库取出旧数据
                var art = bll.GetById(id);
                //从界面读取值更新model
                art.ChannelId = Convert.ToInt32(ddlChannel.SelectedValue);
                art.Title = txtTitle.Text;
                art.Msg = txtMsg.Text;
                art.DingCount = Convert.ToInt32(txtDingCount.Text);
                art.CaiCount = Convert.ToInt32(txtCaiCount.Text);
                //把对model的修改保存到数据库中
                bll.Update(art);

                bll.StaticArticle(art.Id);//保存修改的时候重新生成静态页

                IndexManager.GetInstance().AddArticle(art.Id);

                //返回列表界面
                Response.Redirect("ArticleMgr.aspx");
            }
            else if (action == "addnew")
            {
                T_Article article = new T_Article();
                article.ChannelId = Convert.ToInt32(ddlChannel.SelectedValue);
                article.Msg = txtMsg.Text;
                article.PostDate = DateTime.Now;
                article.Title = txtTitle.Text;
                article.DingCount = Convert.ToInt32(txtDingCount.Text);
                article.CaiCount = Convert.ToInt32(txtCaiCount.Text);
                T_ArticleBLL bll = new T_ArticleBLL();
                article = bll.Add(article);

                bll.StaticArticle(article.Id);//保存新增的时候生成静态页

                //把任务加入索引库中
                IndexManager.GetInstance().AddArticle(article.Id);

                Response.Redirect("ArticleMgr.aspx");//回到列表页面，避免讨厌的Postback问题
            }
            else
            {
                Response.Write("参数错误");
            }

        }
    }
}