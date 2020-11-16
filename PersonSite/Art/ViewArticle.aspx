<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ViewArticle.aspx.cs" Inherits="PersonSite.Art.ViewArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="/js/ckeditor/ckeditor.js" type="text/javascript"></script>--%>
    <%--<script src="/js/ckeditor/config.js" type="text/javascript"></script>--%>
    <%--<link href="/js/ckeditor/contents.css" rel="stylesheet" type="text/css" />--%>
    <script src="/js/common.js"></script>
    <script type="text/javascript">
        //提交评论完成后的处理
        var postFinish = function (data) {
            //var oEditor = CKEDITOR.instances.txtComment;
            if (data == "ok") {
                //把评论的内容添加到界面上
                $("<li>"+$("#txtComment").val()+"</li>").appendTo("#ulComments");
                //$("<li>" + oEditor.getData() + "</li>").appendTo("#ulComments");


            }
            else if (data == "mod") {
                alert("等待审核");
            }
            else if (data == "banned") {
                alert("您的评论内容含有禁用词汇，请注意文明用语！");
            }
            else {
                alert("服务器返回错误:" + data);
            }
            //清空CKEditor
            //oEditor.setData("");//设置txtComment的内容也不能影响CKEditor
            $("#txtComment").val("");//评论提交成功后清除文本框
        };
        $(function () {
            //启动的时候通过ajax加载评论
            $.post("/ajax/GetComments.ashx", { "articleId": "<%=Request["id"] %>" },
            function (data) {
                var comments = $.parseJSON(data);//和eval一样是把json字符串转换为对象
                for (var i = 0; i < comments.length; i++) {
                    //把每条评论添加到ulComments上
                    var comment = comments[i];
                    $("<li>" + ubbToHtml(comment.Msg) + "</li>").appendTo("#ulComments");
                }
            });
            //todo:做静态页的时候思考为什么通过ajax加载评论，为什么有的网站在另外一个页面显示评论
            $("#btnPostComment").click(function () {
                var msg = $("#txtComment").val();
                //判断是否为空
                if (msg == null || msg == "" || msg == undefined) {
                    alert("请输入评论内容");
                    return;
                }
                //CKEditor是把原先的textarea替换（replace）调，然后画自己的内容，所以读取textarea的value并不能得到CKEditor当前编辑的内容
                //var oEditor = CKEDITOR.instances.txtComment;
                //var msg = oEditor.getData();
                //通过ajax提交评论
                $.post("/ajax/PostComment.ashx",
                    { "articleId": "<%=Request["id"] %>", "msg": msg },
                    postFinish);
            });
        });

        //    $(function () {
        //        CKEDITOR.replace('txtComment',
        //{
        //    extraPlugins: 'bbcode',
        //    removePlugins: 'bidi,button,dialogadvtab,div,filebrowser,flash,format,forms,horizontalrule,iframe,indent,justify,liststyle,pagebreak,showborders,stylescombo,table,tabletools,templates',
        //    toolbar:
        //    [
        //        ['Source', '-', 'Save', 'NewPage', '-', 'Undo', 'Redo'],
        //        ['Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
        //        ['Link', 'Unlink', 'Image'],
        //        '/',
        //        ['FontSize', 'Bold', 'Italic', 'Underline'],
        //        ['NumberedList', 'BulletedList', '-', 'Blockquote'],
        //        ['TextColor', '-', 'Smiley', 'SpecialChar', '-', 'Maximize']
        //    ],
        //    smiley_images:
        //    [
        //        'regular_smile.gif', 'sad_smile.gif', 'wink_smile.gif', 'teeth_smile.gif', 'tounge_smile.gif',
        //        'embaressed_smile.gif', 'omg_smile.gif', 'whatchutalkingabout_smile.gif', 'angel_smile.gif', 'shades_smile.gif',
        //        'cry_smile.gif', 'kiss.gif'
        //    ],
        //    smiley_descriptions:
        //    [
        //        'smiley', 'sad', 'wink', 'laugh', 'cheeky', 'blush', 'surprise',
        //        'indecision', 'angel', 'cool', 'crying', 'kiss'
        //    ]
        //});
        //    });
    </script>
    <script type="text/javascript">
        var rateFinish = function (data) {
            if (data == "duplicate") {
                alert("同一段视频24小时之内只能打分一次");
            }
            else {
                alert("打分成功");
            }
        }
        var imgStyle = function () {
            $("img").addClass("img-responsive");
        }

        $(function () {
            imgStyle();
            $("#btnDing").button({
                icons: { primary: 'ui-icon-check' }
            }).click(function () {
                $.post("/ajax/RateArticle.ashx",
                { "articleId": "<%=Request["id"] %>", "action": 1 }, rateFinish);
            });
            $("#btnCai").button({
                icons: { primary: 'ui-icon-closethick' }
            }).click(function () {
                $.post("/ajax/RateArticle.ashx",
                { "articleId": "<%=Request["id"] %>", "action": -1 }, rateFinish);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h4 class="text-primary">
                <asp:Literal ID="litTitle" runat="server"></asp:Literal><br />
            </h4>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:Literal ID="litMsg" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-10">
            <strong>发表时间：<asp:Literal ID="libPostDate" runat="server"></asp:Literal>
            </strong>
        </div>
        <div class="col-lg-2">
            <a class="btn btn-default" id="btnDing"><span class="glyphicon glyphicon-thumbs-up"></span>推荐</a>
            <a class="btn btn-default" id="btnCai"><span class="glyphicon glyphicon-thumbs-down "></span>反对</a>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12">
            <h4>评论列表</h4>
            <div class="">
                <ol id="ulComments">
                </ol>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <textarea class="form-control" placeholder="说两句吧..." id="txtComment"></textarea><br />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1 col-lg-offset-11">
            <input type="button" class="btn btn-default" value="评论" id="btnPostComment" />
        </div>
    </div>
</asp:Content>
