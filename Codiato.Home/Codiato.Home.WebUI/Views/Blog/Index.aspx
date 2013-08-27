<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Blog.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section>
        <% foreach (Codiato.Home.WebUI.Models.Post post in Model) { %>
            <% Html.RenderPartial("SinglePost", post); %>
        <%} %>
    </section>

</asp:Content>
