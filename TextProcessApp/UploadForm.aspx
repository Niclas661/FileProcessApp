<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadForm.aspx.cs" Inherits="TextProcessApp.TestForm" %>

<!DOCTYPE html>
<!--
    Niclas Svensson
    2017-04-27
 -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Upload a file to the server</h1>
    <h3>Accepted files: txt, rtf, md, file</h3>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <input type="file" accept=".txt,.rtf,.md,.file" id="inputFile" name="inputFile" />
        <asp:Button runat="server" ID="btnUpload" OnClick="btnUploadClick" Text="Upload" />
    </div>
    </form>

    <div id="content">
        <p>The most occurring word, with <span id="occurCount"></span> occurrences is:</p>
        <h3 id="mostOccurring"></h3>
        <p>Here is the new text, with 'foo' prepended and 'bar' appended to that word:</p>
        <p id="newText"></p>
    </div>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
    <script>
        $("#form1").submit(function (e) {
            getNewText();
            //return false;
        });

        function getNewText() {
            var fullpath = $("#inputFile").val();
            //var filename = (fullpath.indexOf('\\') >= 0 ? fullpath.lastIndexOf('\\') : fullpath.lastIndexOf('/'));
            //filename = filename.substring(0, filename.lastIndexOf('.'));
            alert(fullpath);

        }
        /*
        $('#btnUpload').click(function () {
            var url = "/api/textformat/" + $('#fileExt option:selected').val() + "/" + $('#searchFileTxtBox').val();
            $.get(url, function (data) {
                $('#content').show();
                $("#mostOccurring").text(data["MostOccurringWord"]["Key"]);
                $("#occurCount").text(data["MostOccurringWord"]["Value"]);
                $("#newText").text(data["NewContent"]);
            });
        });
        */
        $(document).ready(function () {
            $('#content').hide();
        });


    </script>
</body>
</html>
