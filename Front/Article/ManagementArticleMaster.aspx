<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManagementArticleMaster.aspx.cs" Inherits="Front.Article.ManagementArticleMaster" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div>
        <asp:Label ID="LabelCatalog" Text ="栏目：" runat="server" Font-Size="Larger"></asp:Label>
        <asp:DropDownList ID="DropDownListCatalog" runat="server" Width="200px"  Font-Size="Larger" AutoPostBack="true" OnSelectedIndexChanged="DropDownListCatalog_SelectedIndexChanged"></asp:DropDownList>
    </div> <br />
    <div style="font-size:large;align-items:center">
        <asp:GridView ID="GridViewArticle" runat="server" OnRowCommand="GridViewArticle_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="View" HeaderText="操作" ShowHeader="True" Text="查看" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="操作" ShowHeader="true" Text="删除" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div style="border: 3px dashed #000000; font-size:20px; border-spacing: 2px;padding:4px;">
        <asp:LinkButton ID="LinkButtonFrist" runat="server" Text="首页" Enabled="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonFormer"  runat="server" Text="上一页" Enabled="false"></asp:LinkButton>
        <asp:DropDownList ID="DropDownListPageNumber" runat="server"></asp:DropDownList>
        <asp:LinkButton ID="LinkButtonLatter" runat="server" Text="下一页" Enabled="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonLast" runat="server" Text="尾页" Enabled="false"></asp:LinkButton>
     </div>
    
    
   
    
   
   
    
    
   
    
    
   
    
    
   
    
</asp:Content>
