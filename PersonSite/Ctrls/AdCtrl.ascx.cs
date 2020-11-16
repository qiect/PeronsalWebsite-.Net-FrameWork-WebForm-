using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using PersonSite.BLL;
using System.Text;

namespace PersonSite.Ctrls
{
    public partial class AdCtrl : System.Web.UI.UserControl
    {
        [DisplayName("广告位编号")]
        public int PositionId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var ad = new T_AdBLL().GetRandomAdByPosition(PositionId);
            //如果为null，则一条广告都没有
            if (ad == null)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            if (ad.AdType == 1)//文字广告
            {
                sb.Append("<a href='").Append(ad.TextAdUrl)
                    .Append("'>").Append(ad.TextAdText)
                    .Append("</a>");
            }
            else if (ad.AdType == 2)//图片广告
            {
                sb.Append("<a href='").Append(ad.PicAdUrl)
                    .Append("'>").Append("<img src='")
                    .Append(ad.PicAdImgUrl).Append("'/>")
                    .Append("</a>");
            }
            else if (ad.AdType == 3)//代码广告
            {
                sb.Append(ad.CodeAdHTML);
            }
            else
            {
                sb.Append("AdType错误！！！");
            }
            litCode.Text = sb.ToString();
        }
    }
}