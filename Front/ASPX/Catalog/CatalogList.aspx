<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CatalogList.aspx.cs" Inherits="Front.ASPX.Catalog.CatalogList" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="LabelCatalog" Text="栏目列表" runat="server"></asp:Label>
    <%--<asp:BulletedList ID="BulletedListCatalog" runat="server" DisplayMode="HyperLink">

    </asp:BulletedList>--%>
    <asp:GridView ID="GridViewCatalogs" runat="server" OnRowCommand="GridViewCatalogs_RowCommand">
        <Columns>
            <asp:ButtonField ButtonType="Button" Text="查看" HeaderText="操作" CommandName="View"  ShowHeader="true"/>
            <asp:ButtonField ButtonType="Button" Text="删除" HeaderText="操作" CommandName="Delete" ShowHeader="true"/>
        </Columns>
    </asp:GridView>

    <asp:LinkButton ID="LinkButtonCatalogAdd"  Text="添加栏目" runat="server" OnClick="LinkButtonCatalogAdd_Click"></asp:LinkButton>
</asp:Content>
