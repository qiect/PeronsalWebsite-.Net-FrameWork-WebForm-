<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="RegUser.aspx.cs" Inherits="PersonSite.RegUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-4 control-label">用户名：</label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-4 control-label">密码：</label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtPwd" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server"
                    ControlToCompare="txtPwd2" ControlToValidate="txtPwd" ErrorMessage="两次输入的密码不一致"></asp:CompareValidator>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-4 control-label">重复密码：</label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtPwd2" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-4 control-label">邮箱：</label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-4 control-label">密码问题：</label>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlQuestion" CssClass="form-control" runat="server">
                    <asp:ListItem>你的小学名字？</asp:ListItem>
                    <asp:ListItem>你的中学名字？</asp:ListItem>
                    <asp:ListItem>你母亲贵姓？</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-4 control-label">密码答案：</label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtAnswer" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-4 control-label">QQ：</label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtQQ" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class=" col-xs-6 col-sm-offset-5">
                <asp:Button ID="btnReg" runat="server" CssClass="btn btn-default" OnClick="btnReg_Click" Text="注册" />
                <asp:Label ID="labelMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
