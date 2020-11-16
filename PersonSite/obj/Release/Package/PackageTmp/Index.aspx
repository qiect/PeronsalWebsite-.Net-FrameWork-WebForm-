<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PersonSite.Index" %>

<%@ OutputCache Duration="300" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*
        * Off Canvas
        * --------------------------------------------------
        */
        @media screen and (max-width: 767px) {
            .row-offcanvas {
                position: relative;
                -webkit-transition: all .25s ease-out;
                -o-transition: all .25s ease-out;
                transition: all .25s ease-out;
            }

            .row-offcanvas-right {
                right: 0;
            }

            .row-offcanvas-left {
                left: 0;
            }

            .row-offcanvas-right .sidebar-offcanvas {
                right: -50%; /* 6 columns */
            }

            .row-offcanvas-left .sidebar-offcanvas {
                left: -50%; /* 6 columns */
            }

            .row-offcanvas-right.active {
                right: 50%; /* 6 columns */
            }

            .row-offcanvas-left.active {
                left: 50%; /* 6 columns */
            }

            .sidebar-offcanvas {
                position: absolute;
                top: 0;
                width: 50%; /* 6 columns */
            }
        }
    </style>
    <script>
        $(document).ready(function () {
            $('[data-toggle="offcanvas"]').click(function () {
                $('.row-offcanvas').toggleClass('active')
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noformMain" runat="server">

    <div class="row row-offcanvas row-offcanvas-right">

        <div class="col-xs-12 col-sm-10">
            <p class="pull-right visible-xs">
                <button type="button" class="btn btn-primary btn-xs" data-toggle="offcanvas">Toggle nav</button>
            </p>
            <div class="jumbotron">
                <h3></h3>
                <ul>
                </ul>
            </div>


            <div class="row" id="rowArts">
            </div>
            <!--/row-->
        </div>
        <!--/.col-xs-12.col-sm-9-->

        <div class="col-xs-6 col-sm-2 sidebar-offcanvas" id="sidebar">
            <div class="input-group">
                <input type="text" class="form-control" placeholder="关键字搜索" id="txtKeyWord" autocomplete="off" />
                <span class="input-group-btn">
                    <button class="btn btn-default" type="button" id="btnSearch"><span class="glyphicon glyphicon-search"></span></button>
                </span>
            </div>
            <hr />
            <h4>热门频道</h4>
            <div class="list-group" id="channelmenu">
            </div>
        </div>
        <!--/.sidebar-offcanvas-->
    </div>
    <!--/row-->
    <script>
        $(function () {
            //给menu添加样式
            //$("#channelmenu a").click(function () {
            //    $(this).addClass('active').siblings().removeClass('active');
            //});

            //请求数据top3
            $.post("/ajax/GetArticles.ashx", { "action": "top3" }, function (data) {
                var arts3 = $.parseJSON(data);
                var h3Html = '<a href="/Art/' + arts3[0].StaticPath + '">' + arts3[0].Title + '</a>';
                var liHtml = '<li><a href="/Art/' + arts3[1].StaticPath + '">' + arts3[1].Title + '</a></li><li><a href="/Art/' + arts3[2].StaticPath + '">' + arts3[2].Title + '</a></li>'
                $("h3", $(".jumbotron")).html(h3Html);
                $("ul", $(".jumbotron")).html(liHtml);
            })

            //请求数据get50news
            $.post("/ajax/GetArticles.ashx", { "action": "get50news" }, function (data) {
                var arts = $.parseJSON(data);
                for (var i = 0; i < arts.length; i++) {
                    var art = arts[i];
                    //$("<li><a href='/Art/"+art.StaticPath+"'>"+art.Title+"</a></li>").appendTo("#ulArts");
                    $('<div class="col-lg-6"><a title=' + art.Title + ' href="/Art/' + art.StaticPath + '" role="button">' + art.Title + '</a><br/>' + art.PostDate.ToString("yyyy-MM-dd hh:mm:ss") + '<hr/></div>').appendTo("#rowArts");
                }
            });

            //绑定菜单列表
            $.post("/ajax/GetChannel.ashx", { "action": "cn" }, function (data) {
                var chas = $.parseJSON(data);
                for (var i = 0; i < chas.length; i++) {
                    var cha = chas[i];
                    $('<a class="list-group-item col-lg-6" href="/Art/ViewChannel.aspx?id=' + cha.Id + '">' + cha.Name + '</a>').appendTo("#channelmenu");
                }
            })
            //初始化搜索
            initSearch();
        });


        var initSearch = function () {
            //点击搜索
            $("#btnSearch").click(function () {
                var keyWord = $("#txtKeyWord").val();
                console.log("keyWord" + keyWord);
                if (keyWord.length > 0) {
                    location.href = "/Search/ViewSearch.aspx?kw=" + escape(keyWord);
                } else {
                    alert("请输入关键字！");
                }

            });
            //回车
            $(document).keyup(function (event) {
                if (event.keyCode == 13) {
                    $("#btnSearch").trigger("click");
                }
            });
        }
    </script>
</asp:Content>
