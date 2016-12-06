<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Front.ASPX.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style type="text/css">
        #textBox{
            width:300px;
            height:150px;
            align-content:center;
            font-size:15px
        }
        </style>
    <title></title>
</head>
<body style="text-align: center">
    <form id="formLogin" runat="server" style="align-self:center">
       
    <div style="background-color:pink" >
        <div style="font-size:larger;color:red;font-weight:bold">
            <asp:Label ID="LabelMessageInfo" runat="server" Visible="true" Text=""></asp:Label>
         </div><br />
        <asp:Label ID="LabelUsername" runat="server" Text="用户名:" BorderColor="#0033CC" Font-Size="Larger" ></asp:Label><br />
        <asp:TextBox ID="TextBoxUsername" runat="server" BorderColor="#0033CC" Font-Size="Larger" ></asp:TextBox><br /><br style="text-align: center" /><br />

        <asp:Label ID="LabelPassword" runat="server" Text="密      码:" BorderColor="#0033CC" Font-Size="Larger"  ></asp:Label><br />
        <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="" BorderColor="#0033CC" Font-Size="Larger" TextMode="Password"></asp:TextBox><br /><br /><br />

        
        <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click"  Text="登录" Font-Size="Larger"/>
    
    </div>
    </form>
</body>
</html>
