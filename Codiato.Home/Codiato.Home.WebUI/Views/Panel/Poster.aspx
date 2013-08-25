<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Panel.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    پست کننده
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>پست کننده</h2>

    <%: Html.TextArea("content", new { @class = "ckeditor"})%>

</asp:Content>
