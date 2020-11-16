<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdEdit.aspx.cs" Inherits="PersonSite.Admin.AdEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var adTypeChange = function () {
            var adType = $("#ddlAdType").val();
            if (adType == "1") {
                $("#textAd").show();
                $("#picAd").hide();
                $("#codeAd").hide();
            }
            else if (adType == "2") {
                $("#textAd").hide();
                $("#picAd").show();
                $("#codeAd").hide();
            }
            else if (adType == "3") {
                $("#textAd").hide();
                $("#picAd").hide();
                $("#codeAd").show();
            }
            else {
                alert("adType错误" + adType);
            }
        };
        $(function () {
            adTypeChange();//页面刚显示的时候就根据当前的值切换显示
            $("#ddlAdType").change(adTypeChange);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <p>
        名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </p>
    <p>
        广告位：<asp:DropDownList ID="ddlAdPosition" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        类型：<asp:DropDownList ClientIDMode="Static"  ID="ddlAdType" runat="server">
            <asp:ListItem Value="1">文字</asp:ListItem>
            <asp:ListItem Value="2">图片</asp:ListItem>
            <asp:ListItem Value="3">代码</asp:ListItem>
        </asp:DropDownList>
    </p>
    <div id="textAd" style="display:none">
    <p>
        文字广告内容：<asp:TextBox ID="txtTextAdText" runat="server"></asp:TextBox>
    </p>
    <p>
        文字广告链接：<asp:TextBox ID="txtTextAdUrl" runat="server"></asp:TextBox>
    </p>
    </div>

    <div id="picAd" style="display:none">
    <p>
        图片广告图片地址：<asp:TextBox ID="txtPicAddImgSrc" runat="server"></asp:TextBox>
    </p>
    <p>
        图片广告链接：<asp:TextBox ID="txtPicAdUrl" runat="server"></asp:TextBox>
    </p>

    </div>

     <div id="codeAd" style="display:none">
    <p>
        代码广告HTML代码：<asp:TextBox ID="txtCodeAdHTML" runat="server" Height="84px" 
            TextMode="MultiLine" Width="376px"></asp:TextBox>
    </p>
    </div>
    <p>
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="保存" />
    </p>
</asp:Content>
