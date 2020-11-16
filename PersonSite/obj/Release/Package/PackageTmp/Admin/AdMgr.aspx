<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdMgr.aspx.cs" Inherits="PersonSite.Admin.AdMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <a href="AdEdit.aspx?action=addnew">新增</a><br />
    <asp:ObjectDataSource ID="odsAds" runat="server" DeleteMethod="DeleteById" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
        TypeName="PersonSite.BLL.T_AdBLL">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <asp:ListView ID="lvAds" runat="server" DataSourceID="odsAds">
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
                    <a href='AdEdit.aspx?action=edit&id=<%#Eval("Id") %>'>编辑</a>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="PositionIdLabel" runat="server" 
                        Text='<%# Eval("PositionId") %>' />
                </td>
                <td>
                    <asp:Label ID="AdTypeLabel" runat="server" Text='<%# Eval("AdType") %>' />
                </td>
                <td>
                    <asp:Label ID="TextAdTextLabel" runat="server" 
                        Text='<%# Eval("TextAdText") %>' />
                </td>
                <td>
                    <asp:Label ID="TextAdUrlLabel" runat="server" Text='<%# Eval("TextAdUrl") %>' />
                </td>
                <td>
                    <asp:Label ID="PicAdImgUrlLabel" runat="server" 
                        Text='<%# Eval("PicAdImgUrl") %>' />
                </td>
                <td>
                    <asp:Label ID="PicAdUrlLabel" runat="server" Text='<%# Eval("PicAdUrl") %>' />
                </td>
                <td>
                    <asp:Label ID="CodeAdHTMLLabel" runat="server" 
                        Text='<%# Eval("CodeAdHTML") %>' />
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
                                    名称</th>
                                <th runat="server">
                                    广告位</th>
                                <th runat="server">
                                    广告类型</th>
                                <th runat="server">
                                    TextAdText</th>
                                <th runat="server">
                                    TextAdUrl</th>
                                <th runat="server">
                                    PicAdImgUrl</th>
                                <th runat="server">
                                    PicAdUrl</th>
                                <th runat="server">
                                    CodeAdHTML</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
