<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddArticleByRule.aspx.cs" Inherits="PersonSite.Admin.Art.AddArticleByRule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="avigation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <article class="page-container">
        <div class="form form-horizontal">
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2 text-r">频道：</label>
                <div class="formControls col-xs-8 col-sm-2">
                    <asp:DropDownList ID="ddlChannel" runat="server" CssClass="select-box"></asp:DropDownList>
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2">Url：</label>
                <div class="formControls col-xs-8 col-sm-6">
                    <input type="text" id="txtTitle" class="input-text" />
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2">网页规则：</label>
                <div class="formControls col-xs-8 col-sm-6">
                    <input type="text" id="pageRule" class="input-text" />
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2">内容规则：</label>
                <div class="formControls col-xs-8 col-sm-6">
                    <input type="text" id="contentRule" class="input-text" />
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2">最大条数：</label>
                <div class="formControls col-xs-8 col-sm-6">
                    <input type="text" id="maxCount   " class="input-text" />
                </div>
            </div>
            <div class="row cl">
                <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
                    <%--<asp:Button ID="btnPost" CssClass="btn btn-primary radius" runat="server" Text="提交" OnClick="btnPost_Click" />--%>
                    <input type="button" class="btn btn-primary radius " value="提交" onclick="" />
                </div>
            </div>
        </div>
    </article>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
