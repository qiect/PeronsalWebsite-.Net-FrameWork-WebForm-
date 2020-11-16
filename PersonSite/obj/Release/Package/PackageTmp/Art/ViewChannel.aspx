<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ViewChannel.aspx.cs" Inherits="PersonSite.Art.ViewChannel" %>

<%@ OutputCache Duration="300" VaryByParam="*" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            var id = "<%=Request["id"] %>";
            //给menu添加样式
            $("#channelmenu a").click(function () {
                $(this).addClass('active').siblings().removeClass('active');
            });
            $('[href="ViewChannel.aspx?id=' + id + '"').addClass('active').siblings().removeClass('active');
            console.log($('[href="ViewChannel.aspx?id=' + id + '"'));

            //请求数据
            $.post("/ajax/GetArticles.ashx", { "action": "articlesbychannel", "id": id }, function (data) {
                var arts = $.parseJSON(data);
                for (var i = 0; i < arts.length; i++) {
                    var art = arts[i];
                    //$("<li><a href='/Art/"+art.StaticPath+"'>"+art.Title+"</a></li>").appendTo("#ulArts");
                    $('<div class="col-lg-6"><h4><strong>' + art.Title + '</strong></h4><p>' + art.PostDate.ToString("yyyy-MM-dd hh:mm:ss") + '</p><a class="btn btn-primary btn-xs" href="/Art/' + art.StaticPath + '" role="button">详情 &raquo;</a></div>').appendTo("#rowArts");
                }
            });
            //只有国内菜单才显示
            if (id == "2" || id == "3" || id == "4" || id == "5" || id == "6" || id == "7" || id == "8") {
                $.post("/ajax/GetChannel.ashx", { "action": "cn" }, function (data) {
                    var chas = $.parseJSON(data); var menuhtml = "";
                    menuhtml += '<a class="btn btn-default active" href="ViewChannel.aspx?id=2">全部</a>';
                    for (var i = 0; i < chas.length; i++) {
                        var cha = chas[i];
                        menuhtml += '<a class="btn btn-default" href="ViewChannel.aspx?id=' + cha.Id + '">' + cha.Name + '</a>';
                    }
                    $("#channelmenu").html(menuhtml);
                });
            }

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <div id="channelmenu">
    </div>
    <div class="row" id="rowArts">
    </div>
</asp:Content>
