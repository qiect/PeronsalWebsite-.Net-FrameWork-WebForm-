using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using PersonSite.DAL;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonSite.BLL
{
    public partial class T_FilterWordBLL
    {
        //重用
        private static string bannedExprKey = typeof(T_FilterWordBLL) + "BannedExpr";
        private static string modExprKey = typeof(T_FilterWordBLL) + "ModExpr";

        public T_FilterWord GetByWord(string word)
        {
            return new T_FilterWordDAL().GetByWord(word);
        }

        /// <summary>
        /// 清理缓存
        /// </summary>
        public void ClearCache()
        {
            //string bannedExprKey = typeof(RP_FilterWordBLL) + "BannedExpr";
            //string modExprKey = typeof(RP_FilterWordBLL) + "ModExpr";

            HttpRuntime.Cache.Remove(bannedExprKey);
            HttpRuntime.Cache.Remove(modExprKey);
        }


        /// <summary>
        /// 取得禁用词的正则表达式
        /// 由方法去处理缓存的问题
        /// </summary>
        /// <returns>返回禁用词正则表达式</returns>
        private string GetBannedExpr()
        {
            //因为缓存是整个网站唯一的实例，所以要保证key的唯一性
            //我的习惯就是在Cache的名字前加一个类名，几乎不会重复
            //项目组规定，缓存的名字都是类型全名+缓存项的名字
            string bannedExpr = (string)HttpRuntime.Cache[bannedExprKey];
            if (bannedExpr != null)//如果缓存中存在，则直接返回
            {
                return bannedExpr;
            }
            T_FilterWordDAL dal = new T_FilterWordDAL();
            var banned = (from word in dal.GetBanned()
                          select word.WordPattern).ToArray();
            bannedExpr = string.Join("|", banned);

            bannedExpr = bannedExpr.Replace(@".", @"\.").Replace("{2}", ".{0,2}").Replace(@"\", @"\\");
            //如果不存在则去数据库取，然后放入缓存
            HttpRuntime.Cache.Insert(bannedExprKey, bannedExpr);
            return bannedExpr;
        }

        private string GetModExpr()
        {
            string modExpr = (string)HttpRuntime.Cache[modExprKey];
            if (modExpr != null)//如果缓存中存在，则直接返回
            {
                return modExpr;
            }
            T_FilterWordDAL dal = new T_FilterWordDAL();
            var mod = (from word in dal.GetMod()
                          select word.WordPattern).ToArray();
            modExpr = string.Join("|", mod);

            modExpr = modExpr.Replace(@".", @"\.").Replace("{2}", ".{0,2}").Replace(@"\", @"\\");
            //如果不存在则去数据库取，然后放入缓存
            HttpRuntime.Cache.Insert(modExprKey, modExpr);
            return modExpr;
        }

        private IEnumerable<T_FilterWord> GetReplaceWords()
        {
            string replaceKey = typeof(T_FilterWordBLL) + "Replace";
            IEnumerable<T_FilterWord> data = (IEnumerable<T_FilterWord>)HttpRuntime.Cache[replaceKey];
            if (data != null)//如果缓存中存在，则直接返回
            {
                return data;
            }
            T_FilterWordDAL dal = new T_FilterWordDAL();
            data = dal.GetReplace();
            //如果不存在则去数据库取，然后放入缓存
            HttpRuntime.Cache.Insert(replaceKey, data);
            return data;
        }

        public FilterResult FilterMsg(string msg, out string replacemsg)
        {
            string bannedExpr = GetBannedExpr();

            //todo：避免每次进行过滤词判断的时候都进行数据库查询。缓存，把bannedExpr缓存起来。


            string modExpr = GetModExpr();


            //先判断禁用词！有禁用词就不让发，无从谈起审核词
            //Regex.Replace(
            foreach (var word in GetReplaceWords())
            {
                msg = msg.Replace(word.WordPattern, word.ReplaceWord);
            }
            replacemsg = msg;

            if (Regex.IsMatch(replacemsg, bannedExpr))
            {
                return FilterResult.Banned;
            }
            else if (Regex.IsMatch(replacemsg, modExpr))
            {
                return FilterResult.Mod;
            }

            
            return FilterResult.OK;
        }

        /// <summary>
        /// 从流中导入过滤词
        /// </summary>
        /// <param name="stream"></param>
        public void Import(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.Default))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] strs = line.Split('=');
                    string word = strs[0];
                    string replaceWord = strs[1];
                    T_FilterWordBLL bll = new T_FilterWordBLL();
                    //判断是否已经存在。存在则更新，不存在直接插入
                    var filterWord = bll.GetByWord(word);
                    if (filterWord == null)
                    {
                        filterWord = new T_FilterWord();
                        filterWord.ReplaceWord = replaceWord;
                        filterWord.WordPattern = word;
                        bll.Add(filterWord);
                    }
                    else
                    {
                        //如果存在则更新
                        filterWord.ReplaceWord = replaceWord;
                        filterWord.WordPattern = word;
                        bll.Update(filterWord);
                    }
                }
            }
        }
    }
}