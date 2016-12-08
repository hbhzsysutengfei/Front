<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CatalogAuthorize.aspx.cs" Inherits="Front.ASPX.Catalog.CatalogAuthorize" %>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">  
    
    <asp:Label ID="LabelPageMessageInfo" runat="server" ForeColor="Red" ></asp:Label>
    <br />
    <div>
         栏目名称:<asp:Label ID="LabelCatalogName" runat="server" Text=""></asp:Label>
    </div>
    <div>
       用户：
    </div>

    <div>
        <asp:CheckBoxList runat="server" ID="CheckBoxListClients">
        </asp:CheckBoxList>
    </div>
    
    <asp:Button ID="LinkButtonAuthorize" runat="server" Text="授权" BackColor="#CC3300" BorderStyle="Ridge" Font-Bold="True" Font-Size="X-Large" Height="36px" Width="69px" OnClick="LinkButtonAuthorize_Click">

    </asp:Button>
</asp:Content>
