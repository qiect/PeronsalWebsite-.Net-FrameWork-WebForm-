<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="FindPassword.aspx.cs" Inherits="PersonSite.FindPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-4 control-label">用户名：</label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="labelMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class=" col-xs-6 col-sm-offset-5">
                <asp:Button ID="btnOK" CssClass="btn btn-default" runat="server" Text="继续" OnClick="btnOK_Click" />
            </div>
        </div>
    </div>


</asp:Content>
