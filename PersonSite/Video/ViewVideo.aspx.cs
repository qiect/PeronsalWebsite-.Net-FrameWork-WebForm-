using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;

namespace PersonSite.Video
{
    public partial class ViewVideo : System.Web.UI.Page
    {
        protected string VideoUrl;
        protected string VideoTitle;
        protected int VideoId;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["id"]);
            T_VideoBLL bll = new T_VideoBLL();
            var video =  bll.GetById(id);
            if (video == null)
            {
                ShowMessage.Show("视频id错误！");
                return;
            }
            VideoUrl = video.Url;
            VideoTitle = video.Title;
            VideoId = video.Id;
        }
    }
}