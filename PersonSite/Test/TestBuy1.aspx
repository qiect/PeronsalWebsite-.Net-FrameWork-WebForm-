<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="TestBuy1.aspx.cs" Inherits="PersonSite.Test.TestBuy1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
商品名称：<asp:TextBox ID="txtProductName" runat="server"></asp:TextBox><br />
订单号：<asp:TextBox ID="txtTradeNo" runat="server"></asp:TextBox><br />
金额：<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnBuy" runat="server" Text="购买" onclick="btnBuy_Click" />
</asp:Content>
