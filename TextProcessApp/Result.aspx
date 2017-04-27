<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="TextProcessApp.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>The file was uploaded!</h1>

    <div id="content">
        <p>The most occurring word, with <span id="occurCount"></span> occurrences is:</p>
        <h3 id="mostOccurring"></h3>
        <p>Here is the new text, with 'foo' prepended and 'bar' appended to that word:</p>
        <p id="newText"></p>
    </div>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
    <script>
        function getNewText() {
            var url = "/api/textformat/<% =fileExtension %>/<% =fileName %>";
            $.get(url, function (data) {
                $('#content').show();
                $("#mostOccurring").text(data["MostOccurringWord"]["Key"]);
                $("#occurCount").text(data["MostOccurringWord"]["Value"]);
                $("#newText").text(data["NewContent"]);
            });
        }

        $(document).ready(function () {
            $('#content').hide();
            getNewText();
        });


    </script>
</body>
</html>
