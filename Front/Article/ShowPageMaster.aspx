<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShowPageMaster.aspx.cs" Inherits="Front.Article.ShowPageMaster" %>

<asp:Content ID="ContentArticle" ContentPlaceHolderID="content" runat="server">
    <style>
        .div{
            font-size:larger;
            border-width:2px;
            border-color:black;
        }
    </style>
    
    <div class="div">
        <asp:Label ID="labelTitle"      runat="server"  /><br />
        <asp:Label ID="labelCatalog"    runat="server"  /><br />
        <asp:Label ID="labelAuthor"     runat="server"  />
        <asp:Label ID="labelUpdateTime" runat="server" /><br />
        <asp:Button ID="buttonUpdateArticle" runat="server" Font-Size="Large" Text="修改" OnClick="buttonUpdateArticle_Click" Visible="false"/> 
        <asp:Button ID="buttonDeleteArticle" runat="server"  Font-Size="Large" Text="删除" OnClick="buttonDeleteArticle_Click" Visible="false"/>
    </div> 
    <% Response.Write(txtContent);%>
</asp:Content>
