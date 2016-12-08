<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CatalogAdd.aspx.cs" Inherits="Front.ASPX.Catalog.CatalogAdd" %>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <style type="text/css">
     .table{
           align-content:center;
           width:61.8%;
           border:solid;
           align-self:center;
           align-items:center;
           text-align:center;
           font-size:25px;
           height:100px;
           padding:3px;         
       }
        .label{
            font-size:20px;
            border-width:4px;
        }
        .label_message{
            font-size:20px;
            color:red;
        }
        .textbox{
            font-size:20px;
            border-width:4px;
            width:200px;
        }
        .td{
            text-align:left;
            padding:2px;
        }

    </style>
    <asp:Label ID="LabelPageMessageInfo" runat="server"></asp:Label>
    <table class="table">
        <tr>
            <td colspan="2"><asp:Label ID="LabelTile" runat="server" Text="添加栏目" CssClass="label" Font-Size="25px" Font-Bold="true"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelCatalogName" runat="server" Text="栏目名称:" CssClass="label"></asp:Label></td>
            <td class="td"><asp:TextBox ID="TextBoxCatalogName" runat="server" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:LinkButton ID="LinkButtonAddCatalog" runat="server" Text="下一步" OnClick="LinkButtonAddCatalog_Click">

                </asp:LinkButton>
            </td>
        </tr> 
    </table>
    
</asp:Content>
