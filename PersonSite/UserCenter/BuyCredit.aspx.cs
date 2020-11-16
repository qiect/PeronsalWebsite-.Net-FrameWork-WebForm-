using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.Helpers;
using System.Web.Security;
using PersonSite.BLL;
using PersonSite.Model;

namespace PersonSite.UserCenter
{
    public partial class BuyCredit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Membership.GetUser() == null)
            {
                ShowMessage.Show("请先登录");
                return;
            }
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            T_UserInfoBLL bll = new T_UserInfoBLL();
            var userInfo = bll.GetByUserId(userId);

            this.litCredit.Text = Convert.ToString(userInfo.Credit);
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            T_SettingBLL settingBll = new T_SettingBLL();
            //从配置平台中读取网关地址、key、商户id等信息，做到系统可配置化，不写死在程序中
            string gateAddr = settingBll.GetValue(Consts.AlipayGateAddr);
            string partnerId = settingBll.GetValue(Consts.AlipayPartnerId);
            string aliKey = settingBll.GetValue(Consts.AlipayKey);


            T_CreditOrder order = new T_CreditOrder();
            order.CreditCount = Convert.ToInt32(txtBuyCount.Text);
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            order.UserId = userId;
            order.Status = "未支付";//订单初始状态为“未支付”

            //插入订单表
            T_CreditOrderBLL orderBll = new T_CreditOrderBLL();
            order = orderBll.Add(order);

            double amount = Convert.ToInt32(txtBuyCount.Text)*0.1;//一个积分0.1元
            //string partnerId = "1";//支付宝分配给网站的订单编号，todo：配置到系统中
            string productName = txtBuyCount.Text + "个积分";
            string tradeNo = order.Id.ToString();//用订单表的id做订单号

            //为按顺序连接 总金额、 商户编号、订单号、商品名称、商户密钥的MD5值。
            string md5 = CommonHelper.GetMD5(amount.ToString("0.00") + partnerId + tradeNo + productName + aliKey);

            string url = gateAddr + "?partner=" + partnerId + "&return_url=" + Server.UrlEncode("http://localhost:4171/UserCenter/BuyCreditCallback.aspx") + "&subject=" + Server.UrlEncode(productName) + "&body=" + productName + "&out_trade_no=" + tradeNo + "&total_fee=" + amount.ToString("0.00")
                + "&seller_email=abc@abc.com&sign=" + md5;

            Response.Redirect(url);
        }
    }
}