using PersonSite.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonSite.Admin
{
    public partial class ChannelMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSourceBind();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataSourceBind()
        {
            var resultList = new T_ChannelBLL();
            rptChannels.DataSource = resultList.GetAll();
            rptChannels.DataBind();

        }
    }
}