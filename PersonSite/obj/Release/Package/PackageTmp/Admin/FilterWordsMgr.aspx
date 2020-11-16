<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="FilterWordsMgr.aspx.cs" Inherits="PersonSite.Admin.FilterWordsMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $('.table-sort').dataTable({
            "aaSorting": [[1, "desc"]],//默认第几个排序
            "bStateSave": true,//状态保存
            "aoColumnDefs": [
                //{"bVisible": false, "aTargets": [ 3 ]} //控制列的隐藏显示
                { "orderable": false, "aTargets": [0, 3] }// 不参与排序的列
            ]
        });
        function data_add_modal() {
            $("#modal-filterword").modal("show");
        }

        $("#btnAdd").click(function () {
            var $word = $("#txtWord").val(),
                $replace = $("#txtReplace").val(),
                data = {};
            data["action"] = "add";
            data["word"] = $word;
            data["replace"] = $replace;
            $.ajax({
                type: 'POST',
                url: '/Admin/ajax/RequestFilterWords.ashx',
                data: data,
                dataType: 'json',
                success: function (data) {
                    layer.msg('添加成功!', { icon: 1, time: 2000 });
                }
            })

        })

        /*过滤词-删除*/
        function public_del(obj, id) {
            layer.confirm('确认要删除吗？', function (index) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/ajax/RequestFilterWords.ashx',
                    data: { 'action': 'delete', 'id': id },
                    dataType: 'json',
                    success: function (data) {
                        $(obj).parents("tr").remove();
                        layer.msg('已删除!', { icon: 1, time: 2000 });
                    },
                    error: function (data) {
                        console.log(data.msg);
                    },
                });
            });
        }
        /*过滤词-导入*/
        function data_import() {

        }
        /*过滤词-导出*/
        function data_export() {
            layer.confirm('确认要导出文件吗？', function (index) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/ajax/RequestFilterWords.ashx',
                    data: { 'action': 'export' },
                    dataType: 'json',
                    success: function (data) {
                        layer.msg('文件已导出!', { icon: 1, time: 2000 });
                    },
                    error: function (data) {
                        console.log(data.msg);
                    },
                });
            });
        }


    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="avigation" runat="server">
    <div class="cl pd-5 bg-1 bk-gray mt-20">
        <a class="btn btn-primary radius" onclick="data_add_modal()">新增</a>
        <asp:FileUpload ID="fileuploadImport" runat="server" />
        <asp:Button ID="btnImport" runat="server" CssClass="btn btn-primary radius" OnClick="btnImport_Click" Text="导入"/>
        <%--<a class="btn btn-primary radius" onclick="data_import" href="javascript:;">导入</a>--%>
        <a class="btn btn-primary radius"  href="ExportFilterWords.ashx">导出</a>
    </div>


    <!--登录对话框-->
    <div id="modal-filterword" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content radius">
                <div class="modal-header">
                    <h3 class="modal-title">添加记录</h3>
                    <a class="close" data-dismiss="modal" aria-hidden="true" href="javascript:void();">×</a>
                </div>
                <div class="modal-body">
                    <div class="form modal-form">
                        <div class="row cl">
                            <label class="form-label col-xs-4 col-sm-4 text-r">过滤词：</label>
                            <div class="formControls col-xs-8 col-sm-4">
                                <input class="input-text" id="txtWord" autocomplete="off" placeholder="请输入过滤词" type="text" />
                            </div>
                        </div>
                        <div class="row cl">
                            <label class="form-label col-xs-4 col-sm-4 text-r">替换词：</label>
                            <div class="formControls col-xs-8 col-sm-4">
                                <input class="input-text" id="txtReplace" autocomplete="off" placeholder="请输入替换词" type="text" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" id="btnAdd">确定</button>
                    <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <table class="table table-border table-bordered table-bg table-hover table-sort">
        <thead>
            <tr class="text-c">
                <th width="25">
                    <input type="checkbox" name="" value=""></th>
                <th>ID</th>
                <th>过滤词</th>
                <th>替换词</th>
                <th width="120">操作</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptFilterWords" runat="server">
                <ItemTemplate>
                    <tr class="text-c">
                        <td>
                            <input type="checkbox" value="<%#Eval("Id") %>" name="" /></td>
                        <td><%#Eval("Id") %></td>
                        <td><%#Eval("WordPattern") %></td>
                        <td><%#Eval("ReplaceWord") %></td>
                        <td class="f-14 td-manage">
                            <a style="text-decoration: none" class="ml-5" onclick="public_edit('频道编辑','RequestFilterWords.ashx','<%#Eval("Id") %>')" href="javascript:;" title="编辑"><i class="Hui-iconfont">&#xe6df;</i></a>
                            <a style="text-decoration: none" class="ml-5" onclick="public_del(this,'<%#Eval("Id") %>')" href="javascript:;" title="删除"><i class="Hui-iconfont">&#xe6e2;</i></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
