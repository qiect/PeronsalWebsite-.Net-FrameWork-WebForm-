<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="TestMemShip.aspx.cs" Inherits="PersonSite.Test.TestMemShip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
    Text="ValidateUser" />
    
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
    Text="CreateUser" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button3" runat="server" Text="获得当前登录用户信息" 
        onclick="Button3_Click" />
</asp:Content>
