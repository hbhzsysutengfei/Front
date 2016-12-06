﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClientInfo.aspx.cs" Inherits="Front.ASPX.Client.ClientInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

    <div style="font-size:large;color:black;padding:3px">
        
        <asp:Label ID="LabelClientInfo" runat="server" Text="用户信息" Font-Bold="true" Font-Size="Larger"></asp:Label><br />

        <asp:Label ID="LabelUserName" runat="server" Text="用户名:"></asp:Label>
        <asp:Label ID="LabelUserNameInfo" runat="server" Text=""></asp:Label>
        
        <br />

        <asp:Label ID="LabelReaName" runat="server" Text="真实名字:"></asp:Label>
         <asp:Label ID="LabelRealNameInfo" runat="server" Text=""></asp:Label>
        <br />

        <asp:Label ID="LabelDepartment" runat="server" Text="部门:"></asp:Label>
        <asp:Label ID="LabelDepartmentInfo" runat="server" Text=""></asp:Label>
        <br />

        <asp:Label ID="LabelCatalog" runat="server" Text="栏目:"></asp:Label>
        <asp:BulletedList ID="BulletedListCatalog" DisplayMode="HyperLink" runat="server">
        </asp:BulletedList>
        <asp:LinkButton ID="LinkButtonManagementCatalog" Visible="false" Text="栏目授权" OnClick="LinkButtonManagementCatalog_Click"></asp:LinkButton>

        <br />
    </div>
   

    
   <%-- <asp:LinkButton ID="LinkButtonChangeClientInfo" runat="server"  Text="修改用户信息" />--%>

    <asp:LinkButton ID="LinkButtonChangePassword" runat="server" Text="修改密码" OnClick="LinkButtonChangePassword_Click"></asp:LinkButton>

</asp:Content>