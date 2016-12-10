<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CatalogInfo.aspx.cs" Inherits="Front.ASPX.Catalog.CatalogInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="LabelCatalogName" Text="栏目名称:" runat="server"></asp:Label>
    <asp:Label ID="LabelCatalogNameInfo" runat="server"></asp:Label><br />

    <asp:Label ID="LabelClientsForCatalog" runat="server" Text="授权用户:" ></asp:Label>
    <asp:BulletedList ID="BulletedListClients" runat="server">

    </asp:BulletedList>
    <asp:LinkButton ID="LinkButtonCatalogArticles" runat="server" Text="栏目文章" OnClick="LinkButtonCatalogArticles_Click"></asp:LinkButton><br />
    <asp:LinkButton ID="LinlButtonCatalogArticleManagement" runat="server" Text="文章管理" OnClick="LinlButtonCatalogArticleManagement_Click"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButtonAuthorize" runat="server"  Text="管理用户" OnClick="LinkButtonAuthorize_Click"></asp:LinkButton><br />
 </asp:Content>
