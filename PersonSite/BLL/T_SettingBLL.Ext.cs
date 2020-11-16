using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.DAL;

namespace PersonSite.BLL
{
    public partial class T_SettingBLL
    {
        public string GetValue(string name)
        {
            T_SettingDAL dal = new T_SettingDAL();
            var setting = dal.GetByName(name);
            if (setting == null)
            {
                throw new ArgumentNullException("找不到"+name+"的值");
            }
            return setting.Value;
        }

        public void SetValue(string name, string value)
        {
            T_SettingDAL dal = new T_SettingDAL();
            var setting = dal.GetByName(name);
            if (setting == null)
            {
                throw new ArgumentNullException("找不到" + name + "的值");
            }
            setting.Value = value;
            Update(setting);
        }
    }
}