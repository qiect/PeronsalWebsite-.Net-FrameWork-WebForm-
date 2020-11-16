using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.Helpers;

namespace PersonSite.Test
{
    public partial class TestCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string out_trade_no = Request["out_trade_no"];
            string returncode = Request["returncode"];
            string total_fee = Request["total_fee"];
            string sign = Request["sign"];

            //为按顺序连接 订单号、返回码、支付金额、商户密钥为新字符串的MD5值。
            string md5 = CommonHelper.GetMD5(out_trade_no + returncode + total_fee + "mk@2$z");
            if (sign != md5)
            {
                Response.Write("数据被篡改");
            }
            else
            {
                Response.Write("支付成功，金额："+total_fee);
            }
        }
    }
}