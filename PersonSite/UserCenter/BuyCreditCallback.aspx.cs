using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.Helpers;
using PersonSite.BLL;

namespace PersonSite.UserCenter
{
    public partial class BuyCreditCallback : System.Web.UI.Page
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
                Response.Write("数据被篡改。非常抱歉，我们的系统出现故障，放心我们会100%保证您的资金安全，和联系我们的客服处理，电话。。。。。");
                return;
            }
            //Guid userId = new Guid(out_trade_no);
            //double count = Convert.ToDouble(total_fee) * 10;
            //RP_UserInfoBLL userBll = new RP_UserInfoBLL();
            //userBll.IncCredit(userId, (int)count);

            int orderId = Convert.ToInt32(out_trade_no);
            T_CreditOrderBLL orderBll = new T_CreditOrderBLL();
            var order = orderBll.GetById(orderId);
            if (order == null)
            {
                Response.Write("订单号不存在！非常抱歉....");
                return;
            }
            //积分和人民币的转换率为10:1。
            double alipayCount = Convert.ToDouble(total_fee) * 10;
            if (order.CreditCount != (int)alipayCount)
            {
                //toto：把报错信息写到配置平台中
                Response.Write("订单金额不符！非常抱歉....");
                return;
            }
            //防止F5刷新订单重复确认造成金额能够不断增加的bug
            if (order.Status == "已支付")
            {
                Response.Write("订单已经确认，请耐心等待！");
                return;
            }

            T_UserInfoBLL userBll = new T_UserInfoBLL();
            //给用户增加指定的积分
            userBll.IncCredit(order.UserId, order.CreditCount);
            order.Status = "已支付";//修改订单状态，防止重复确认
            orderBll.Update(order);

            //todo:发邮件通知业务人员处理订单。“订单编号为***的订单支付成功”
            Response.Write("积分购买成功");
        }
    }
}