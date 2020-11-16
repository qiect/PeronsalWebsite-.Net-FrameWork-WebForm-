using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;
using PersonSite.Model;

namespace PersonSite.Admin
{
    public partial class AdEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                T_AdPositionBLL positionBll = new T_AdPositionBLL();
                ddlAdPosition.DataSource = positionBll.GetAll();
                ddlAdPosition.DataTextField = "Name";
                ddlAdPosition.DataValueField = "Id";
                ddlAdPosition.DataBind();

                string action = Request["action"];
                if (action == "edit")
                {
                    int id = Convert.ToInt32(Request["id"]);
                    T_AdBLL adBll = new T_AdBLL();
                    var ad= adBll.GetById(id);
                    txtName.Text = ad.Name;
                    ddlAdPosition.SelectedValue = ad.PositionId.ToString();
                    ddlAdType.SelectedValue = ad.AdType.ToString();
                    txtTextAdText.Text = ad.TextAdText;
                    txtTextAdUrl.Text = ad.TextAdUrl;

                    txtPicAddImgSrc.Text = ad.PicAdImgUrl;
                    txtPicAdUrl.Text = ad.PicAdUrl;

                    txtCodeAdHTML.Text = ad.CodeAdHTML;
                }
                else if (action == "addnew")
                {
                }
                else
                {
                    Response.Write("action错误");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string action = Request["action"];
            if (action == "edit")
            {
                int id = Convert.ToInt32(Request["id"]);
                T_AdBLL adBll = new T_AdBLL();
                var ad = adBll.GetById(id);

                FillUIToModel(ad);

                adBll.Update(ad);
                Response.Redirect("AdMgr.aspx");
            }
            else if (action == "addnew")
            {
                T_AdBLL adBll = new T_AdBLL();
                T_Ad ad = new T_Ad();

                FillUIToModel(ad);

                adBll.Add(ad);
                Response.Redirect("AdMgr.aspx");
            }
            else
            {
                Response.Write("action错误");
            }
        }

        /// <summary>
        /// 把UI中的内容填充到Model中
        /// </summary>
        /// <param name="ad"></param>
        private void FillUIToModel(T_Ad ad)
        {
            ad.Name = txtName.Text;
            ad.PositionId = Convert.ToInt32(ddlAdPosition.SelectedValue);
            ad.AdType = Convert.ToInt32(ddlAdType.SelectedValue);
            ad.TextAdText = txtTextAdText.Text;
            ad.TextAdUrl = txtTextAdUrl.Text;

            ad.PicAdImgUrl = txtPicAddImgSrc.Text;
            ad.PicAdUrl = txtPicAdUrl.Text;

            ad.CodeAdHTML = txtCodeAdHTML.Text;
        }
    }
}