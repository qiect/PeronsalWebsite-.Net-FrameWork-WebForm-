using Newtonsoft.Json;
using PersonSite.BLL;
using PersonSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PersonSite.Admin.ajax
{
    /// <summary>
    /// RequestFilterWords 的摘要说明
    /// </summary>
    public class RequestFilterWords : IHttpHandler
    {
        T_FilterWordBLL bll = new T_FilterWordBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"],
                id = context.Request["id"],
                word = context.Request["word"],
                replace = context.Request["replace"],
                msg = "";
            if (string.IsNullOrEmpty(action))
            {
                context.Response.Write("请求非法！");
            }
            switch (action)
            {
                case "add":
                    {
                        msg = Add(word, replace);
                        bll.ClearCache();//对数据做了增删改，则需要清理过滤词缓存
                        break;
                    }
                case "edit":
                    {
                        msg = "";
                        bll.ClearCache();
                        break;
                    }
                case "delete":
                    {
                        msg = bll.DeleteById(Convert.ToInt32(id)).ToString();
                        bll.ClearCache();
                        break;
                    }
                case "import":
                    {
                        msg = "";
                        break;
                    }
                case "export":
                    {
                        msg = Export();
                        break;
                    }
            }
            context.Response.Write(msg);

        }

        private string Add(string word, string replace)
        {
            T_FilterWord fw = new T_FilterWord();
            fw.WordPattern = word;
            fw.ReplaceWord = replace;
            var result = bll.Add(fw);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        private string Import()
        {
            //bll.Import(fileuploadImport.FileContent);
            bll.ClearCache();//注意只有通过ListView控件新增的时候，Inserted事件才会触发。所以这种通过代码导入的方式，还是要手动清理缓存
            return "导入成功";
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        private string Export()
        {
            //context.Response.AddHeader("Content-Disposition", "attachment");
            //context.Response.AddHeader("Content-Disposition", "attachment;filename=word.txt");
            string encodeFileName = HttpUtility.UrlEncode("过滤词.txt");
            StringBuilder sb = new StringBuilder();
            //在浏览器弹出下载对话框保存Response，而不是直接显示到浏览器
            //filename设置默认文件名
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", encodeFileName));

            var filterwords = bll.GetAll();//因为数据量不大，所以也没用SqlDataReader
            foreach (var filterword in filterwords)
            {
                sb.AppendLine(filterword.WordPattern + "=" + filterword.ReplaceWord);
            }
            return sb.ToString();
            //不要这样写：
            //File.WriteAllText(HttpContext.Current.Server.MapPath("~/1.txt"),"asfasfdasfasdfsa");
            //HttpContext.Current.Response.Redirect("/1.txt");
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}