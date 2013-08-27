<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Codiato will introduce itself soon</title>    
    <link rel="icon" type="image/png" href="<%: Url.Content("~/content/images/favicon.png") %>" />
    <link rel="apple-touch-icon" href="<%: Url.Content("~/content/images/apple-touch-icon-57.png") %>" />
    <link rel="apple-touch-icon" sizes="72x72" href="<%: Url.Content("~/content/images/apple-touch-icon-72.png") %>" />
    <link rel="apple-touch-icon" sizes="114x114" href="<%: Url.Content("~/content/images/apple-touch-icon-114.png") %>g" />
    <link rel="apple-touch-icon" sizes="144x144" href="<%: Url.Content("~/content/images/apple-touch-icon-144.png") %>" />
    <link type="text/css" href="<%: Url.Content("~/content/uc.css") %>" rel="stylesheet" />
    <body>
        <div id="uc">
            <img src="<%: Url.Content("~/content/images/coming-soon-codiato.png") %>"" alt="Workers are working. Website comming soon." />
        </div>
        <div id="copyright">&copy; Copyright 2013 Codiato.com</div>
        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-42789570-1', 'codiato.com');
            ga('send', 'pageview');

        </script>
    </body>
</html>
