<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="Front.ASPX.Client.ClientList" %>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div  style="border: 3px dashed #000000; font-size:20px; border-spacing: 2px;padding:4px;">
        <asp:Label ID="LabelDepartment" Text="部门:" runat="server"  Font-Size="Larger"></asp:Label>
        <asp:DropDownList ID="DropDownListDepartment" runat="server" Width="200px"  Font-Size="Larger"  AutoPostBack="true" OnSelectedIndexChanged="DropDownListDepartment_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <br />
    <div style="font-size:large;align-items:center">
        
        <asp:GridView ID="GridViewClientList" runat="server" OnRowCommand="GridViewClientList_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="View" HeaderText="操作" ShowHeader="True" Text="查看" />
                <asp:ButtonField ButtonType="Button" CommandName="Authorize" HeaderText="操作" ShowHeader="true" Text="授权栏目" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="操作" ShowHeader="true" Text="删除" />
            </Columns>
        </asp:GridView>
    </div>

    <br />
    <div style="border: 3px dashed #000000; font-size:20px; border-spacing: 2px;padding:4px;">
        <asp:LinkButton ID="LinkButtonFrist" runat="server" Text="首页" OnClick="LinkButtonFrist_Click"></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonFormer"  runat="server" Text="上一页" OnClick="LinkButtonFormer_Click"></asp:LinkButton>
        <asp:DropDownList ID="DropDownListPageNumber" runat="server"  OnSelectedIndexChanged="DropDownListPageNumber_SelectedIndexChanged"></asp:DropDownList>
        <asp:LinkButton ID="LinkButtonLatter" runat="server" Text="下一页" OnClick="LinkButtonLatter_Click"></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonLast" runat="server" Text="尾页"  OnClick="LinkButtonLast_Click"></asp:LinkButton>
     </div>

</asp:Content>
