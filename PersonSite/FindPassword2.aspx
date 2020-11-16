<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="FindPassword2.aspx.cs" Inherits="PersonSite.FindPassword2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-4 control-label">密码问题：</label>
            <div class="col-sm-3">
                <asp:Label ID="labelPwdQuestion" runat="server" CssClass="form-control"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-4 control-label">密码答案：</label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtPwdAnswer" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="labelMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class=" col-xs-6 col-sm-offset-5">
                <asp:Button ID="btnGo" CssClass="btn btn-default" runat="server" Text="继续" OnClick="btnGo_Click" />
            </div>
        </div>
    </div>
</asp:Content>
