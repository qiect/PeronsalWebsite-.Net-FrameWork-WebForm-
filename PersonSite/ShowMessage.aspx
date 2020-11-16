<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ShowMessage.aspx.cs" Inherits="PersonSite.ShowMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <center><asp:Literal ID="litMsg" runat="server"></asp:Literal></center>
    <a href="javascript:void(0)" onclick="history.go(-1)">返回上一页</a>
</asp:Content>
