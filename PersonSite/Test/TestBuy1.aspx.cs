using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.Helpers;

namespace PersonSite.Test
{
    public partial class TestBuy1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnBuy_Click(object sender, EventArgs e)
        {
            //为按顺序连接 总金额、 商户编号、订单号、商品名称、商户密钥的MD5值。
            string md5 = CommonHelper.GetMD5(txtAmount.Text + "1" + txtTradeNo.Text + txtProductName.Text + "mk@2$z");

            string url = "http://www.zhifubao.com:8080/AliPay/PayGate.ashx?partner=1&return_url=" + Server.UrlEncode("http://localhost:4171/Test/TestCallback.aspx") + "&subject=" + Server.UrlEncode(txtProductName.Text) + "&body=afasfdsadfasfd&out_trade_no=" + txtTradeNo.Text + "&total_fee=" + txtAmount.Text + "&seller_email=abc@abc.com&sign=" + md5;

            Response.Redirect(url);
        }
    }
}