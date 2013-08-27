<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Panel.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A page that posts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>A page that posts</h2>

    <% using (Html.BeginForm(Model == null ? "CreatePost" : "EditPost", "BlogPanel")) { %>
        <fieldset>
            <legend>Blog post</legend>
        <label>Title</label>
            <%: Html.TextBox("Title") %>
            <label>Content</label>
            <%: Html.TextArea("Content", new { @class = "ckeditor"})%>
            <label>Tags</label>
            <%: Html.TextBox("tags", Model == null ? "" : ((Codiato.Home.WebUI.Models.Post)Model).CSedTags) %>
            <% if (Model == null)
               { %>
            <label>Static link</label>
            <%: Html.TextBox("StaticLink") %>
            <%} %>
            <p>
                <button type="submit" class="btn">Send post</button>
            </p>
        </fieldset>
    <%} %>

    <%--<% if (Model != null) { %>
    <script type="text/javascript">
        CKEDITOR.instances.Body.setData('<%: ((Codiato.Home.WebUI.Models.Post)Model).Content%>', function () {
            this.checkDirty();  // true
        });
    </script>
    <%} %>--%>
</asp:Content>
