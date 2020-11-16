<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="BuyCredit.aspx.cs" Inherits="PersonSite.UserCenter.BuyCredit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <p>
        现有积分：<asp:Literal ID="litCredit" runat="server"></asp:Literal>
    </p>
    <p>
        购买积分：<asp:TextBox ID="txtBuyCount" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuy" runat="server" Text="购买" onclick="btnBuy_Click" />
    </p>
</asp:Content>
