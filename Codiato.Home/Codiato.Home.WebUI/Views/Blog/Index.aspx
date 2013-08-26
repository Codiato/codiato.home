<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Blog.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% Html.RenderPartial("LatestPostSummary", (Codiato.Home.WebUI.Models.Post)ViewBag.LatestBlogPost); %>

</asp:Content>
