<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Codiato.Home.WebUI.Models.FileListingViewModel>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Browse</title>
    <script src="<%: Url.Content("~/Scripts/jquery-2.0.3.min.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('a').click(function (e) {
                e.preventDefault();
                var ckEditorNum = parseInt($('#CKEditorFuncNum').val());
                window.opener.CKEDITOR.tools.callFunction(ckEditorNum, '/uploads/' + $(this).attr('href'), '');
                window.close();
            });
        });
    </script>
</head>
<body>
    <div>
        Select files<br /><br />
        <%foreach (var item in Model.Files)
        {%>
            <a href="@item.FileName" style="font-size: larger;"><%:item.FileName%></a>
            <br />
        <%} %>
        <br /><br />
        <%:Html.HiddenFor(m => m.CKEditorFuncNum) %>
    </div>
</body>
</html>