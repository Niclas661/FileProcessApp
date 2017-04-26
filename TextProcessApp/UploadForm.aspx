<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadForm.aspx.cs" Inherits="TextProcessApp.TestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <input type="file" id="inputFile" name="inputFile" />
        <asp:Button runat="server" ID="btnUpload" OnClick="btnUploadClick" Text="Upload" />
    </div>
    </form>
</body>
</html>
