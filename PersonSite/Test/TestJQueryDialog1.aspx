<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="TestJQueryDialog1.aspx.cs" Inherits="PersonSite.Test.TestJQueryDialog1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/ui-lightness/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.2.custom.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#btn1").click(function () {
                $("#div1").dialog({
                    height: 140,
                    modal: true
                });
            });
            $("#btnClose").click(function () {
                $("#div1").dialog("close");
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
<input type="button" value="test1" id="btn1" />
<div id="div1" style="display:none">
这是我的对话框<input type="text" /><br />
<input type="button" value="关闭" id="btnClose" />
</div>
</asp:Content>
