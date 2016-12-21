<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CatalogInfo.aspx.cs" Inherits="Front.ASPX.Catalog.CatalogInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <style type="text/css">
        .button{
            color:black;
            width:150px;
            height:40px;
            font-size:25px;
            border-color:red;
            border-width:3px;
        }
        .linkbutton{
            font-size:28px;
            padding:4px;
            
        }
    </style>

    <asp:Label ID="LabelCatalogName" Text="栏目名称:" runat="server"></asp:Label>
    <asp:Label ID="LabelCatalogNameInfo" runat="server"></asp:Label><br />

    <asp:LinkButton ID="LinkButtonClientsForCatalog"    runat="server" Text="查看授权" OnClick="LinkButtonClientsForCatalog_Click" CssClass="linkbutton"></asp:LinkButton>    
    <asp:LinkButton ID="LinkButtonDeleteClientForCatalog" Text="删除授权" runat="server" OnClick="LinkButtonDeleteClientForCatalog_Click" CssClass="linkbutton"></asp:LinkButton>
    <asp:LinkButton ID="LinkButtonAuthorizeClientToCatalog" Text="添加授权" runat="server" OnClick="LinkButtonAuthorizeClientToCatalog_Click" CssClass="linkbutton"></asp:LinkButton>
    <asp:LinkButton ID="LinkButtonCatalogArticles"      runat="server" Text="栏目文章" OnClick="LinkButtonCatalogArticles_Click" CssClass="linkbutton"></asp:LinkButton>
    <asp:LinkButton ID="LinlButtonCatalogArticleManagement" runat="server" Text="文章管理" OnClick="LinlButtonCatalogArticleManagement_Click" CssClass="linkbutton"></asp:LinkButton>
    
    <asp:Panel ID="PanelValidClients" runat="server" Visible="true" Enabled="true" BorderStyle="Dotted">        
        <asp:BulletedList ID="BulletedListClients" runat="server">
        </asp:BulletedList>
    </asp:Panel>
    <br />

    <asp:Panel ID="PanelDeleteClientForCatalog" runat="server" Enabled="false" Visible="false" BorderStyle="Dashed">
        <asp:CheckBoxList ID="CheckBoxListValidUser" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="ButtonDeleteClientForCatalog" Text="删除授权" runat="server" OnClick="ButtonDeleteClientForCatalog_Click"  CssClass="button"/>
    </asp:Panel>

    <br />
    
    <asp:Panel ID="PanelAuthorizeClientToCatalog" runat="server" Visible="true" Enabled="false" BorderStyle="Dashed">
        <asp:CheckBoxList ID="CheckBoxListAddClient" runat="server" >
        </asp:CheckBoxList>
        <asp:Button ID="BottonAuthorizeClientToCatalog" runat="server" Text="提交"  OnClick="BottonAuthorizeClientToCatalog_Click" CssClass="button" BorderStyle="Dotted"/>
    </asp:Panel>
 </asp:Content>
