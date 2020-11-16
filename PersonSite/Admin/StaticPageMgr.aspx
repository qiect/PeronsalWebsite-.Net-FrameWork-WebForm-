<%@ Page Title="静态页面管理" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="StaticPageMgr.aspx.cs" Inherits="PersonSite.Admin.StaticPageMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:Button ID="btnBatchGen" runat="server" Text="批量静态化" 
        onclick="btnBatchGen_Click" />
</asp:Content>
