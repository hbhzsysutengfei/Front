<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShowPageMaster.aspx.cs" Inherits="Front.Article.ShowPageMaster" %>

<asp:Content ID="ContentArticle" ContentPlaceHolderID="content" runat="server">
    
    <div style="width:100%">
        <asp:Label ID="labelTitle"      runat="server" Font-Size="X-Large" BorderColor="#CC00FF" BorderWidth="2px" BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" /><br />
        <asp:Label ID="labelCatalog"    runat="server" Font-Size="X-Large" BorderColor="#CC00FF" BorderWidth="2px" BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" /><br />
        <asp:Label ID="labelAuthor"     runat="server" Font-Size="X-Large" BorderColor="#CC00FF" BorderWidth="2px" BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" />
        <asp:Label ID="labelUpdateTime" runat="server" Font-Size="X-Large" BorderColor="#CC00FF" BorderWidth="2px" BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" /><br />
        <asp:Button ID="buttonUpdateArticle" runat="server" Font-Size="Large" Text="修改" OnClick="buttonUpdateArticle_Click" Visible="false"/> 
        <asp:Button ID="buttonDeleteArticle" runat="server"  Font-Size="Large" Text="删除" OnClick="buttonDeleteArticle_Click" Visible="false"/>
    </div> 
    <% Response.Write(txtContent);%>
</asp:Content>
