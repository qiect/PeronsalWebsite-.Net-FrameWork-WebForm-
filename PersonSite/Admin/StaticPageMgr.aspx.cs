using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;
using System.Net;
using System.Text;
using PersonSite.DAL;
using System.Data.SqlClient;
using System.IO;

namespace PersonSite.Admin
{
    public partial class StaticPageMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBatchGen_Click(object sender, EventArgs e)
        {
            //RP_ArticleBLL artbll = new RP_ArticleBLL();
            //var arts = artbll.GetAll();
            //foreach (var art in arts)
            //{
            //    SqlParameter pName = new SqlParameter();
            //    pName.SqlDbType = System.Data.SqlDbType.NVarChar;
            //    pName.ParameterName = "@SeqName";
            //    pName.Value = "静态页面流水号";

            //    SqlParameter pResult = new SqlParameter();
            //    pResult.SqlDbType = System.Data.SqlDbType.Int;
            //    pResult.ParameterName = "@result";
            //    pResult.Direction = System.Data.ParameterDirection.Output;

            //    //调用存储过程usp_getSeqNo生成流水号
            //    SqlHelper.ExecuteStoredProcedure("usp_getSeqNo",pName,pResult);
            //    int seqNo = (int)pResult.Value;

            //    //要生成的静态页面的保存路径
            //    string path = art.PostDate.ToString(@"yyyy\/MM\/dd\/") + seqNo+".htm";
            //    string localPath = Server.MapPath("~/Art/"+path);
            //    //创建文件夹
            //    Directory.CreateDirectory(
            //        Path.GetDirectoryName(localPath));

            //    WebClient wc = new WebClient();
            //    wc.Encoding = Encoding.UTF8;
            //    //通过WebClient向服务器发Get请求，把服务器返回的html内容保存到磁盘上。以后用户直接请html文件请求。
                
            //    wc.DownloadFile("http://localhost:4171/Art/ViewArticle.aspx?id=" + art.Id, localPath);
            //}

            T_ArticleBLL artBll = new T_ArticleBLL();
            artBll.StaticAllArticle();
        }
    }
}