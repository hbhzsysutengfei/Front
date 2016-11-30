<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Front.Default" MasterPageFile="~/MasterPage.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <style type="text/css">        
        .linkbutton{
            float:right;
            font-size:larger;
            color:red;
        }
        .lable{
            float:left;
            font-size:larger;
            color:blue;
        }
        .div_article{
            align-items:center;
            width:48%;
            height:400px;
            float:left;
            padding-right:10px;
            border-width: 5px;
            border-color:black;
        }
        .bulletedlist{
            border-width:5px;
            border-color:blue;
            outline-width:5px;
        }

       
    </style>
    
    <h1>Main Page</h1>
    <%--<asp:Button ID="buttonShowPage" runat="server"  OnClick="buttonShowPage_Click" Text="TestPageFor Article"/>--%>

    <div >
        <div class="div_article">
            <asp:Label ID="LabelCatalogFirst" runat="server" Text="栏目一" CssClass="lable"></asp:Label>
           
            <asp:LinkButton ID="LinkButtonCatalogFirst" runat="server" Text="更多" CssClass="linkbutton" OnClick="LinkButtonCatalogFirst_Click" BorderStyle="Dashed"></asp:LinkButton>
            
            <asp:BulletedList ID="BulletedListFirst" runat="server" DisplayMode="HyperLink"  Height="84%" style="margin-top: 36px" Width="89%" CssClass="bulletedlist" BorderColor="#33CCCC" BorderStyle="Dotted">
                <asp:ListItem Value="/Article/ShowPageMaster.aspx?articleId=200603f0314a47709d6ee1e47dbbf1aa" Text="PageNotFound"></asp:ListItem>
            </asp:BulletedList>
            
        </div>
        <div class="div_article">
            <asp:Label ID="LabelCatalogSecond" runat="server" Text="栏目二" CssClass="lable"></asp:Label>
           
            <asp:LinkButton ID="LinkButtonCatalogSecond" runat="server" Text="更多" CssClass="linkbutton"  OnClick="LinkButtonCatalogSecond_Click" BorderStyle="Dashed"></asp:LinkButton>
            
            <asp:BulletedList ID="BulletedListSecond" runat="server" DisplayMode="HyperLink"  Height="84%" style="margin-top: 36px" Width="89%" CssClass="bulletedlist" BorderColor="#33CCCC" BorderStyle="Dotted">
                <asp:ListItem Value="https://www.baidu.com" Text="baidu"></asp:ListItem>
            </asp:BulletedList>  
        </div>
       
        <div class="div_article">
            <asp:Label ID="LabelCatalogThird" runat="server" Text="栏目三" CssClass="lable"></asp:Label>
           
            <asp:LinkButton ID="LinkButtonCatalogThird" runat="server" Text="更多" CssClass="linkbutton" OnClick="LinkButtonCatalogThird_Click"  BorderStyle="Dashed"></asp:LinkButton>
            
            <asp:BulletedList ID="BulletedListThird" runat="server" DisplayMode="HyperLink"  Height="84%" style="margin-top: 36px" Width="89%" CssClass="bulletedlist" BorderColor="#33CCCC" BorderStyle="Dotted">
                <asp:ListItem Value="https://www.baidu.com" Text="baidu"></asp:ListItem>
            </asp:BulletedList>  
        </div>
        <div class="div_article">
            <asp:Label ID="LabelCatalogForth" runat="server" Text="栏目四" CssClass="lable"></asp:Label>
           
            <asp:LinkButton ID="LinkButtonCatalogForth" runat="server" Text="更多" CssClass="linkbutton"  OnClick="LinkButtonCatalogForth_Click" BorderStyle="Dashed"> </asp:LinkButton>
            
            <asp:BulletedList ID="BulletedListForth" runat="server" DisplayMode="HyperLink"  Height="84%" style="margin-top: 36px" Width="89%" CssClass="bulletedlist" BorderColor="#33CCCC" BorderStyle="Dotted" >
                <asp:ListItem Value="https://www.baidu.com" Text="baidu"></asp:ListItem>
            </asp:BulletedList>  
        </div>       
    </div>   
</asp:Content>
