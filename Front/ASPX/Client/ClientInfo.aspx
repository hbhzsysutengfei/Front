<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClientInfo.aspx.cs" Inherits="Front.ASPX.Client.ClientInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="LabelClientInfo" runat="server"></asp:Label>
    
    <asp:LinkButton ID="LinkButtonChangeClientInfo" runat="server"  Text="修改用户信息"  OnClick="LinkButtonChangeClientInfo_Click"/>

</asp:Content>
