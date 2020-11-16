using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;
using PersonSite.Helpers;

namespace PersonSite.Admin.Settings
{
    public partial class AlipaySetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //先执行Page_load再执行btnSave_Click
            if (!IsPostBack)
            {
                T_SettingBLL bll = new T_SettingBLL();

                txtGateAddr.Text = bll.GetValue(Consts.AlipayGateAddr);
                txtPartnerId.Text = bll.GetValue(Consts.AlipayPartnerId);
                txtKey.Text = bll.GetValue(Consts.AlipayKey);
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            T_SettingBLL bll = new T_SettingBLL();
            bll.SetValue(Consts.AlipayGateAddr, txtGateAddr.Text);
            bll.SetValue(Consts.AlipayPartnerId, txtPartnerId.Text);
            bll.SetValue(Consts.AlipayKey, txtKey.Text);
        }
    }
}