<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="VideoMgr.aspx.cs" Inherits="PersonSite.Admin.VideoMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ObjectDataSource ID="odsVideos" runat="server" DeleteMethod="DeleteById" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAll" TypeName="PersonSite.BLL.T_VideoBLL">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <asp:ListView ID="lvVideos" runat="server"
        DataSourceID="odsVideos" DataKeyNames="Id">
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>
                        未返回数据。</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:Label ID="UrlLabel" runat="server" Text='<%# Eval("Url") %>' />
                </td>
                <td>
                    <asp:Label ID="DingCountLabel" runat="server" Text='<%# Eval("DingCount") %>' />
                </td>
                <td>
                    <asp:Label ID="CaiCountLabel" runat="server" Text='<%# Eval("CaiCount") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">
                                </th>
                                <th runat="server">
                                    Id</th>
                                <th runat="server">
                                    Title</th>
                                <th runat="server">
                                    Url</th>
                                <th runat="server">DingCount</th>
                                <th runat="server">CaiCount</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
