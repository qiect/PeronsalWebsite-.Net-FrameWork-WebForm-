<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ModComments.aspx.cs" Inherits="PersonSite.Admin.ModComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        /*评论-审核*/
        function modcomment_shenhe(obj,id) {
            layer.confirm('审核评论？', function (index) {
                var data = {};
                data["action"] = "shenhe";
                data["id"] = id;
                $.ajax({
                    type: 'POST',
                    url: '/Admin/ajax/RequestModComments.ashx',
                    data: data,
                    dataType: 'json',
                    success: function (data) {
                        $(obj).parents("tr").remove();
                        layer.msg('审核已通过!', { icon: 1, time: 2000 });
                    }
                });
            });
        }
        /*评论-删除*/
        function public_del(obj, id) {
            layer.confirm('确认要删除吗？', function (index) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/ajax/RequestModComments.ashx',
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <table class="table table-border table-bordered table-bg table-hover table-sort">
        <thead>
            <tr class="text-c">
                <th width="25">
                    <input type="checkbox" name="" value=""></th>
                <th>ID</th>
                <th>文章ID</th>
                <th>评论时间</th>
                <th>评论内容</th>
                <th width="120">操作</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptModComments" runat="server">
                <ItemTemplate>
                    <tr class="text-c">
                        <td>
                            <input type="checkbox" value="<%#Eval("Id") %>" name="" /></td>
                        <td><%#Eval("Id") %></td>
                        <td><%#Eval("ArticleId") %></td>
                        <td><%#Eval("PostDate") %></td>
                        <td><%#Eval("Msg") %></td>
                        <td class="f-14 td-manage">
                            <a style="text-decoration: none" onclick="modcomment_shenhe(this,'<%#Eval("Id") %>')" href="javascript:;" title="审核">审核</a>
                            <a style="text-decoration: none" class="ml-5" onclick="public_del(this,'<%#Eval("Id") %>')" href="javascript:;" title="删除"><i class="Hui-iconfont">&#xe6e2;</i></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
