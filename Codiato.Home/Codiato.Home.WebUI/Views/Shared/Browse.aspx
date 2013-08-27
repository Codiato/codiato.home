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
                window.opener.CKEDITOR.tools.callFunction(ckEditorNum, '/content/uploads/' + $(this).attr('href'), '');
                window.close();
            });
        });
    </script>
</head>
<body>
    <div>        
        <%foreach (var item in Model.Files)
        {%>
            <div style="border-radius: 5px; background: #dedede; margin: 5px; padding: 5px;">
                <img width="50px" src="<%: Url.Content(string.Format("/content/uploads/{0}", item.FileName)) %>" alt="<%: item.FileName %>" /><a href="<%:item.FileName%>" style="font-size: larger;"><%:item.FileName%></a>
            </div>
        <%} %>        
        <%:Html.HiddenFor(m => m.CKEditorFuncNum) %>
    </div>
</body>
</html>