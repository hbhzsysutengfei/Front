<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManagementArticleMaster.aspx.cs" Inherits="Front.Article.ManagementArticleMaster" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="LabelCatalog" Text ="栏目：" runat="server"></asp:Label>

   
    <asp:GridView ID="GridViewArticle" runat="server" Width="616px" AllowPaging="true" PageSize="20" ></asp:GridView>
    
</asp:Content>
