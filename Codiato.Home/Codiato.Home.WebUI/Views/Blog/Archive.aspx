<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Blog.Master" Inherits="System.Web.Mvc.ViewPage<Codiato.Home.WebUI.Models.Post>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Model.Title %></h2>
    <%= Model.Content %>
</asp:Content>