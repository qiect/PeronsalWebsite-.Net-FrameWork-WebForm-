<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PersonSite.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <p>
        用户名：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </p>
    <p>
        密码：<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" />
        <asp:Label ID="labelMsg" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
