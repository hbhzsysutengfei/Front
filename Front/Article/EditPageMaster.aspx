<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="EditPageMaster.aspx.cs" Inherits="Front.Article.EditPageMaster" validateRequest="false" %>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" type="text/css" />
    <script type="text/javascript" src="../kindeditor/kindeditor.js"></script>
    <script type="text/javascript" src="../kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript">
        var options = {
            uploadJson: '../kindeditor/asp.net/upload_json.ashx',
            fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
            allowPreviewEmoticons: true,
            allowImageUpload: true,
            resizeType: 1,
        }
        KindEditor.ready(function (K) {
            window.editor = K.create('#editorText');
        });
    </script>

    <asp:TextBox ID="TextBoxTitle" runat="server" Width="200px" />
    
    <textarea  id="editorText" name="textEditPage" style="width:100%;height:600px">
       <% if (this.BoolUpdateArticle) { Response.Write(txtContent); } %>

    </textarea> <br /><br />

    
    <asp:Label ID="LabelCatalog" Text="栏目:" runat="server" Font-Size="Larger"></asp:Label>

    <asp:DropDownList ID="DropDownListCatalog" runat="server" Width="200px"  Font-Size="Larger"></asp:DropDownList>

    
     <br /> <br />  

    <asp:Button ID="buttonSubmit" Text="发布" runat="server" OnClientClick="return confirm('是否确定')" OnClick="buttonSubmit_Click" />
    

    
    
</asp:Content>
