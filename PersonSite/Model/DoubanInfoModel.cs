using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonSite.Model
{
    /// <summary>
    /// 通过豆瓣api获取的信息
    /// </summary>
    public class DoubanInfoModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string VideoName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string VideoImg { get; set; }
        /// <summary>
        /// 演员
        /// </summary>
        public string Actor { get; set; }
        /// <summary>
        /// 视频类型  动作等
        /// </summary>
        public string VideoType { get; set; }
        /// <summary>
        /// 导演
        /// </summary>
        public string Directors { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public string Rating { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public string VideoYear { get; set; }
    }
}