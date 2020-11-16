using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;

namespace PersonSite.Test
{
    public partial class TestFilter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            T_FilterWordBLL bll = new T_FilterWordBLL();
            string replaceMsg;
            FilterResult result = bll.FilterMsg(TextBox1.Text, out replaceMsg);
            if (result == FilterResult.OK)
            {
                TextBox2.Text = replaceMsg;
            }
            else if (result == FilterResult.Mod)
            {
                TextBox2.Text = "需要审核";
            }
            else if (result == FilterResult.Banned)
            {
                TextBox2.Text = "禁止发布";
            }
        }
    }
}