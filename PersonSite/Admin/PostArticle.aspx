<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PostArticle.aspx.cs" Inherits="PersonSite.Admin.PostArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/ckeditor/ckeditor.js" type="text/javascript"></script>
    <%--<script src="/js/swfupload/swfupload.js" type="text/javascript"></script>--%>
    <%--<script src="/js/swfupload/handlers.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        //<![CDATA[
        // Replace the <textarea id="editor1"> with an CKEditor instance.
        var editor = CKEDITOR.replace('<%=txtMsg.ClientID %>');
        //]]>
    </script>
    <script type="text/javascript">
        //SWFUpload上传成功后调用uploadImgSuccess，第二个参数为服务端的返回（保存的路径）
        function uploadImgSuccess(file, response) {
            var oEditor = CKEDITOR.instances.txtMsg;
            if (oEditor.mode == 'wysiwyg') {
                //把返回值的图片地址插入编辑器。
                // Insert HTML code.
                // http://docs.cksource.com/ckeditor_api/symbols/CKEDITOR.editor.html#insertHtml
                oEditor.insertHtml("<img src='" + response + "'/>");
            }
            else {
                alert('只有在所见即所得模式中才能上传图片!');
            }

            //alert(response);
        };
        $(function () {
            //initUpImg();
        });

        var initUpImg = function () {
            var swfu;
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "/Admin/UploadArticleImg.ashx",
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
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <article class="page-container">
        <div class="form form-horizontal">
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2 text-r">频道：</label>
                <div class="formControls col-xs-8 col-sm-2">
                    <asp:DropDownList ID="ddlChannel" runat="server" CssClass="select-box"></asp:DropDownList>


                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2">标题：</label>
                <div class="formControls col-xs-8 col-sm-10">
                    <asp:TextBox ID="txtTitle" CssClass="input-text" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2">发表日期：</label>
                <div class="formControls col-xs-8 col-sm-2">
                    <asp:Literal ID="litPostDate" runat="server"></asp:Literal>
                </div>
                <label class="form-label col-xs-4 col-sm-2">推荐人数：</label>
                <div class="formControls col-xs-8 col-sm-2">
                    <asp:TextBox ID="txtDingCount" CssClass="input-text" runat="server" Text="0"></asp:TextBox>
                </div>
                <label class="form-label col-xs-4 col-sm-2">反对人数：</label>
                <div class="formControls col-xs-8 col-sm-2">
                    <asp:TextBox ID="txtCaiCount" CssClass="input-text" runat="server" Text="0"></asp:TextBox>
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2">正文：</label>
            </div>
            <div class="row cl">
                <div class="col-xs-4 col-sm-1"></div>
                <div class="col-sm-11">
                    <asp:TextBox ID="txtMsg" ClientIDMode="Static" runat="server" Height="500px" TextMode="MultiLine"
                        Width="382px"></asp:TextBox>
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2">上传图片：</label>
                <div class="formControls col-xs-8 col-sm-10">
                    <span class="input-file" id="btnUploadImgPlaceholder"></span>
                    <div id="divFileProgressContainer"></div>
                </div>
            </div>
            <div class="row cl">
                <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
                    <asp:Button ID="btnPost" CssClass="btn btn-primary radius" runat="server" Text="提交" OnClick="btnPost_Click" />
                </div>
            </div>
        </div>
    </article>
</asp:Content>
