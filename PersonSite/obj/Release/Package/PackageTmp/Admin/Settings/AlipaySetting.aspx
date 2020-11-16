<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AlipaySetting.aspx.cs" Inherits="PersonSite.Admin.Settings.AlipaySetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
网关地址：<asp:TextBox ID="txtGateAddr" runat="server"></asp:TextBox><br />
商户编号：<asp:TextBox ID="txtPartnerId" runat="server"></asp:TextBox><br />
商户key：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox><br />
<asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
</asp:Content>
