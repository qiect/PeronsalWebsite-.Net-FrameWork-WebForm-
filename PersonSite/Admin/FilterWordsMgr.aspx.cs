using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using PersonSite.BLL;
using PersonSite.Model;
using System.Text;

namespace PersonSite.Admin
{
    public partial class FilterWordsMgr : System.Web.UI.Page
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
            var resultList = new T_FilterWordBLL();
            rptFilterWords.DataSource = resultList.GetAll();
            rptFilterWords.DataBind();

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            T_FilterWordBLL bll = new T_FilterWordBLL();
            bll.Import(fileuploadImport.FileContent);
            rptFilterWords.DataBind();

            bll.ClearCache();//注意只有通过ListView控件新增的时候，Inserted事件才会触发。所以这种通过代码导入的方式，还是要手动清理缓存
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('导入成功');", true);
        }
    }
}