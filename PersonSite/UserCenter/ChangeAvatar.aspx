<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ChangeAvatar.aspx.cs" Inherits="PersonSite.UserCenter.ChangeAvatar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/ui-lightness/jquery-ui-1.8.2.custom.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        #draggable { width: 100px; height: 100px; padding: 0.5em; }
    </style>
    <script src="/js/swfupload/swfupload.js" type="text/javascript"></script>
    <script src="/js/swfupload/handlers.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.js" type="text/javascript"></script>
    <script type="text/javascript">
        function uploadImgSuccess(file, response) {
            if (response == "notlogin") {
                //alert("用户未登录!");
                ShowLoginDiv();//如果未登录则显示登录对话框
            }
            else {
                //加上一个当前时间，避免缓存问题
                //$("#imgAvatar").attr("src",
                //response + "?ts=" + new Date());
                //将图片设置为外层div的背景
                var strs = $.parseJSON(response);
                var imgpath = strs[0];
                var imgwidth = strs[1];
                var imgheight = strs[2];

                //把图片设置为背景
                //加上当前时间防止缓存问题
                $("#avatarContainer").css("background-image",
                 "url(" + imgpath + "?ts=" + new Date() + ")");

                 //修改层的大小为图片的大小
                $("#avatarContainer").css("width", imgwidth + "px")
                .css("height",imgheight+"px");
                //注意不要写成$("#imgAvatar").attr("src",
                //response + "?ts=+ new Date()" );
            }
        };

        var swfu;
        $(function () {
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "/UserCenter/UploadAvatar.ashx",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: "*.jpg",
                file_types_description: "JPG Images",
                file_upload_limit: 0,    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadImgSuccess,
                upload_complete_handler: uploadComplete,

                // Button settings
                button_image_url: "/js/swfupload/images/XPButtonNoText_160x22.png",
                button_placeholder_id: "btnUploadImgPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">选择图片（最大2MB）</span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // Flash Settings
                flash_url: "/js/swfupload/swfupload.swf", // Relative to this file
                flash9_url: "/js/swfupload/swfupload_FP9.swf", // Relative to this file

                custom_settings: {
                    upload_target: "divFileProgressContainer"
                },

                // Debug Settings
                debug: false
            });

        });

        var cutFinish = function (data) {
            if (data == "notlogin") {
                ShowLoginDiv();
                return;
            }
            //服务器返回的是截取的文件名
            
            $("#avatarContainer").hide("slow");
            $("#imgAvatar").attr("src", data + "?ts=" + new Date())
                .show("slow");
        }

        $(function () {
            $("#draggable").draggable({ containment: 'parent' });
            $("#draggable").dblclick(function () {
                var thisOffset = $(this).offset();
                var parentOffset = $(this).parent().offset();
                var left = thisOffset.left - parentOffset.left;
                var top = thisOffset.top - parentOffset.top;
                var height = 100;
                var width = 100;
                $.post("/UserCenter/CutAvatar.ashx", 
                    {"width":width,"height":height,"top":top,"left":left},
                    cutFinish);
                //alert(left+","+top);
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <span id="btnUploadImgPlaceholder"></span>
    <div id="divFileProgressContainer"></div>

    <div id="avatarContainer" style="width:300px;height:300px;">
        <div id="draggable" style="border:1px solid black">
            拖拖拖
        </div>
    </div>
    <div>
        <img id="imgAvatar" style="display:none" />
    </div>
</asp:Content>
