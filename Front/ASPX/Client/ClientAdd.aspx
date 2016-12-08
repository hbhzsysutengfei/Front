<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClientAdd.aspx.cs" Inherits="Front.ASPX.Client.ClientAdd" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <style type="text/css">
        .div{
            padding:2px;
            border-width:3px;
            border-color:black;
            outline-width:2px;
        }
        .label{
            font-size:20px;
            border-width:4px;
        }
        .textbox{
            font-size:20px;
            border-width:4px;
            width:200px;
        }
       .table{
           align-content:center;
           width:80%;
           border:2px  solid;
           align-self:center;
           align-items:center;
           text-align:center;
           font-size:25px;
           height:100px;
           padding:3px;         
       }
        .auto-style1 {
            height: 200px;
            text-align:left;
        }
        .td{
            text-align:left;
        }
        .label_info{
            color:red;
            font-size:20px;
        }
    </style>
    <div>
        <asp:Label ID="LabelPageMessageInfo" runat="server" CssClass="label_info"></asp:Label>
    </div>
    <table class="table" border="1" >
        <tr>
            <td colspan="2">添加用户</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelUsername" runat="server" Text="用户名:" CssClass="label"></asp:Label>
            </td>
            <td class="td">
                <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="textbox" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                    <asp:Label ID="LabelPassword" runat="server" Text="密码：" CssClass="label"></asp:Label>    
            </td>
            <td class="td">
                <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>   
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelRepeatPassword" runat="server" Text="再输一次:" CssClass="label"></asp:Label>
            </td>
            <td class="td">
                <asp:TextBox ID="TextBoxRepeatPassword" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
            <tr>
            <td>
                <asp:Label ID="LabelRealName" runat="server" Text="真实名字：" CssClass="label"></asp:Label>
            </td>
            <td class="td">
                    <asp:TextBox ID="TextBoxRealName" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
            <tr>
            <td >
                <asp:Label ID="LabelDepartment" runat="server" Text="部门:" CssClass="label"></asp:Label>
            </td>
            <td class="td">
                    <asp:DropDownList ID="DropDownListDepartment" runat="server" CssClass="textbox"></asp:DropDownList>
            </td>
        </tr>
            <tr>
            <td>
                    <asp:Label ID="LabelRoleType" runat="server" Text="用户角色:" CssClass="label"></asp:Label>
            </td>
            <td class="td">
                <asp:DropDownList ID="DropDownListRole" runat="server" CssClass="textbox" OnSelectedIndexChanged="DropDownListRole_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
            <tr>
            <td class="auto-style1">
                <asp:Label ID="LabelCatalog" runat="server" Text="栏目权限:" CssClass="label"></asp:Label>
            </td>
            <td class="auto-style1">
                    <asp:CheckBoxList ID="CheckBoxListCatalog" runat="server" CssClass="textbox" Width="117px"  ></asp:CheckBoxList>
            </td>
        </tr>
            
        <tr>
            <td colspan="2"><asp:Button ID="ButtonAddClient" runat="server" Text="添加" OnClick="ButtonAddClient_Click" CssClass="label" BackColor="#00CC00" BorderColor="#003399" Height="46px" Width="114px"/></td>
        </tr>            
    </table>
  
</asp:Content>
