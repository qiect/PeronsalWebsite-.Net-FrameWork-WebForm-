using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonSite.Search
{
    public partial class ViewSearch : System.Web.UI.Page
    {
        private ILog logger = LogManager.GetLogger(typeof(ViewSearch));

        protected string PagerHTML { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果kw为空，则是第一次进入界面
            string kw = Request["kw"];
            if (string.IsNullOrWhiteSpace(kw))
            {
                return;
            }

            var pager = new PersonSite.Search.RupengPager();
            pager.UrlFormat = "ViewSearch.aspx?pagenum={n}&kw=" + Server.UrlEncode(kw);
            pager.PageSize = 10;
            //解析当前页面
            pager.TryParseCurrentPageIndex(Request["pagenum"]);

            int startRowIndex = (pager.CurrentPageIndex - 1) * pager.PageSize;

            SearchBLL searchBll = new SearchBLL();
            int totalCount;
            IEnumerable<SearchResult> result = searchBll.Search(kw, startRowIndex, 10, out totalCount);
            pager.TotalCount = totalCount;
            PagerHTML = pager.Render();//渲染页码条HTML

            repeaterResult.DataSource = result;
            repeaterResult.DataBind();       
        }
    }
}