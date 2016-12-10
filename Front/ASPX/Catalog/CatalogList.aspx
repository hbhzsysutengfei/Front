<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CatalogList.aspx.cs" Inherits="Front.ASPX.Catalog.CatalogList" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="LabelCatalog" Text="栏目列表" runat="server"></asp:Label>
    <asp:BulletedList ID="BulletedListCatalog" runat="server" DisplayMode="HyperLink">

    </asp:BulletedList>
</asp:Content>
