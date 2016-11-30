<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CatalogArticleListMaster.aspx.cs" Inherits="Front.Article.CatalogArticleListMaster" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div >
        <asp:Label ID="LabelCatalogName" Text="" runat="server"></asp:Label>
        <asp:BulletedList ID="BulletedListCatalogArticleList" runat="server" DisplayMode="HyperLink">
            
        </asp:BulletedList>
    </div>
</asp:Content>
