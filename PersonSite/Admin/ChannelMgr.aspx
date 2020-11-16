<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ChannelMgr.aspx.cs" Inherits="PersonSite.Admin.ChannelMgr" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="avigation" runat="server">

    <div class="cl pd-5 bg-1 bk-gray mt-20">
        <a class="btn btn-primary radius" onclick="dataadd()">新增</a>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="table table-border table-bordered table-bg table-hover table-sort">
        <thead>
            <tr class="text-c">
                <th width="25">
                    <input type="checkbox" name="" value=""></th>
                <th>ID</th>
                <th>父ID</th>
                <th>名称</th>
                <th width="120">操作</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptChannels" runat="server">
                <ItemTemplate>
                    <tr class="text-c">
                        <td>
                            <input type="checkbox" value="<%#Eval("Id") %>" name="" /></td>
                        <td><%#Eval("Id") %></td>
                        <td><%#Eval("ParentId") %></td>
                        <td><%#Eval("Name") %></td>
                        <td class="f-14 td-manage">
                            <a style="text-decoration: none" class="ml-5" onclick="article_edit('频道编辑','PostArticle.aspx','<%#Eval("Id") %>')" href="javascript:;" title="编辑"><i class="Hui-iconfont">&#xe6df;</i></a>
                            <a style="text-decoration: none" class="ml-5" onclick="article_del(this,'<%#Eval("Id") %>')" href="javascript:;" title="删除"><i class="Hui-iconfont">&#xe6e2;</i></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
