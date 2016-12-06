<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Front.ASPX.Client.ChangePassword" %>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
     <style type="text/css">
        .div_form{
            background-color:pink;
            text-align:center;            
        }
        .textBox{
            width:300px;            
            align-content:center;
            font-size:25px;
            border-color:blue;
        }
        .pageinfo{
            color:red;
            font-size:25px;
        }
        </style>
    <div class="div_form">
        <asp:Label ID="LabelTitle" Text="修改密码" runat="server" Font-Size="XX-Large" Font-Bold="true"></asp:Label><br /><br />
        <asp:Label ID="LabelMessageInfo" Text="AA" runat="server"  CssClass="pageinfo"></asp:Label><br /><br />
        <asp:Label ID="LabelOriginalPassword" Text="原始密码：" runat="server"  CssClass="textBox"></asp:Label>
        <asp:TextBox ID="TextBoxOriginalPassword" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox><br />

        <asp:Label ID="LabelNewPassword" Text="新的密码：" runat="server"  CssClass="textBox"></asp:Label>
        <asp:TextBox ID="TextBoxNewPassword" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox><br />
        <asp:Label ID="LabelRepeatPassword" Text="再输一次：" runat="server"  CssClass="textBox"></asp:Label>
        <asp:TextBox ID="TextBoxRepeatPassword" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox><br /><br/>

        <asp:Button ID="ButtonChangePassword" OnClientClick="return confirm('是否确定')" runat="server" OnClick="ButtonChangePassword_Click"  Text="更改密码" Height="38px" Width="93px" Font-Size="X-Large" />
    </div>
   
</asp:Content>
