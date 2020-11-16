<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ViewSearch.aspx.cs" Inherits="PersonSite.Search.ViewSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">

    <div>
        <ul>
            <asp:Repeater EnableViewState="false" ID="repeaterResult" runat="server">
                <ItemTemplate>
                    <li>
                        <a href="/Art/<%#Eval("StaticPath")%>"><%#Eval("Title") %></a>
                        <%--<a class="btn btn-primary btn-xs" href="/Art/' + art.StaticPath + '" role="button">详情 &raquo;</a>--%>
                        <br />
                        <%#Eval("BodyPreview")%>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <br />
        <div class="row">
            <div class="col-md-8"></div>
            <div class="col-md-4">
                <%=PagerHTML%>
            </div>
        </div>

    </div>

</asp:Content>
