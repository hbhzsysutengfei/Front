<%@ Page Title="SuperAdminPage" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DefaultPageForSuperAdmin.aspx.cs" Inherits="Front.ASPX.DefaultPageForSuperAdmin" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <style>
        .div{
            font-size:20px;
            padding:10px;
        }
    </style>

    <div class="div" >
        <asp:Label ID="LabelClient" runat="server" Text="用户功能"></asp:Label>
        <asp:BulletedList ID="BulletedListClient" runat="server"  DisplayMode="HyperLink">
        </asp:BulletedList>
    </div>

    <div class="div" >
        <asp:Label ID="LabelArticle" runat="server" Text="文章功能"></asp:Label>
        <asp:BulletedList ID="BulletedListArticle" runat="server" DisplayMode="HyperLink">
            
        </asp:BulletedList>
    </div>

    <div class="div">
        <asp:Label ID="LabelCatalog" runat="server" Text="栏目功能"></asp:Label>
        <asp:BulletedList ID="BulletedListCatalog" runat="server" DisplayMode="HyperLink">
           
        </asp:BulletedList>
    </div>

    <div class="div">
        <asp:Label ID="LabelDepartment" runat="server" Text="部门功能"></asp:Label>
        <asp:BulletedList ID="BulletedListDepartment" runat="server" DisplayMode="HyperLink">
           
        </asp:BulletedList>
    </div>

    

</asp:Content>
