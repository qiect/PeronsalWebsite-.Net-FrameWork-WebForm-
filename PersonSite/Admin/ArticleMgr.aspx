<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ArticleMgr.aspx.cs" Inherits="PersonSite.Admin.ArticleMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $('.table-sort').dataTable({
            "aaSorting": [[1, "desc"]],//默认第几个排序
            "bStateSave": true,//状态保存
            "aoColumnDefs": [
                //{"bVisible": false, "aTargets": [ 3 ]} //控制列的隐藏显示
                { "orderable": false, "aTargets": [0, 8] }// 不参与排序的列
            ]
        });


        /*资讯-编辑*/
        function article_edit(title, url, id, w, h) {
            var index = layer.open({
                type: 2,
                title: title,
                content: url + '?action=edit&id=' + id
            });
            layer.full(index);
        }

        /*资讯-删除*/
        function article_del(obj, id) {
            layer.confirm('确认要删除吗？', function (index) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/ajax/RequestArticles.ashx',
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

        /*资讯-批量删除*/
        function datadel() {
            var ids = "";
            var $checked = $("input[type='checkbox']:checked");
            if ($checked.length <= 0) {
                layer.msg("至少选择一项!");
                return;
            }
            $checked.each(function () {
                ids += $(this).val() + ',';
            });
            ids.length > 0 && (ids = ids.substring(0, ids.length - 1));
            console.log(ids);
            layer.confirm('确认要批量删除吗？', function () {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/ajax/RequestArticles.ashx',
                    data: { 'action': 'batchdel', 'id': ids },
                    dataType: 'json',
                    success: function () {
                        layer.msg('批量删除成功!', { icon: 1, time: 2000 });
                    },
                    error: function (data) {
                        console.log(data.msg);
                    },
                });
            });
        }

        /*资讯-批量静态化*/
        function datastatic() {
            $.ajax({
                type: 'POST',
                url: '/Admin/ajax/RequestArticles.ashx',
                data: { 'action': 'static' },
                dataType: 'json',
                success: function (data) {
                    if (data != null && data.length > 0) {
                        layer.msg('批量静态化成功!', { icon: 1, time: 2000 });
                    }
                },
                error: function (data) {
                    console.log(data.msg);
                },
            });
        }

        function addpagedata() {
            $.ajax({
                type: 'POST',
                url: '/Admin/ajax/RequestArticles.ashx',
                data: { 'action': 'addpagedata' },
                dataType: 'json',
                success: function (data) {
                    if (data != null && data.length > 0) {
                        layer.msg('通过规则添加数据成功!', { icon: 1, time: 2000 });
                    }
                },
                error: function (data) {
                    console.log(data.msg);
                },
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="avigation" runat="server">
    <div class="cl pd-5 bg-1 bk-gray mt-20">
        <a class="btn btn-primary radius" href="PostArticle.aspx?action=addnew">新增</a>
        <a href="javascript:;" onclick="datadel()" class="btn btn-danger radius"><i class="Hui-iconfont">&#xe6e2;</i> 批量删除</a>
        <a href="javascript:;" onclick="datastatic()" class="btn btn-default radius">批量静态化</a>
        <a href="javascript:;" onclick="addpagedata()" class="btn btn-default radius">通过规则添加网页数据</a>

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <table class="table table-border table-bordered table-bg table-hover table-sort">
        <thead>
            <tr class="text-c">
                <th width="25">
                    <input type="checkbox" name="" value=""></th>
                <th width="80">ID</th>
                <th>标题</th>
                <th width="80">频道</th>
                <th width="120">静态地址</th>
                <th width="120">更新时间</th>
                <th>推荐人数</th>
                <th>反对人数</th>
                <th width="120">操作</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptArticles" EnableViewState="false" runat="server">
                <ItemTemplate>
                    <tr class="text-c">
                        <td>
                            <input type="checkbox" value="<%#Eval("Id") %>" name="" /></td>
                        <td><%#Eval("Id") %></td>
                        <td class="text-l"><u style="cursor: pointer" class="text-primary" onclick="article_edit('查看','PostArticle.aspx','<%#Eval("Id") %>')" title="查看"><%#Eval("Title") %></u></td>
                        <td><%#Eval("ChannelId") %></td>
                        <td><%#Eval("StaticPath") %></td>
                        <td><%#Eval("PostDate") %></td>
                        <td><%#Eval("DingCount") %></td>
                        <td><%#Eval("CaiCount") %></td>
                        <td class="f-14 td-manage">
                            <a style="text-decoration: none" class="ml-5" onclick="article_edit('资讯编辑','PostArticle.aspx','<%#Eval("Id") %>')" href="javascript:;" title="编辑"><i class="Hui-iconfont">&#xe6df;</i></a>
                            <a style="text-decoration: none" class="ml-5" onclick="article_del(this,'<%#Eval("Id") %>')" href="javascript:;" title="删除"><i class="Hui-iconfont">&#xe6e2;</i></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
