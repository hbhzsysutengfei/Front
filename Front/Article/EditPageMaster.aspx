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
    
    <textarea  id="editorText" name="textEditPage" style="width:100%;height:600px">
       

    </textarea> <br />
   

    <asp:Button ID="buttonSubmit" Text="提交" runat="server" OnClick="buttonSubmit_Click" />

    
    
</asp:Content>
