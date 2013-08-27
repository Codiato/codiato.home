<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Panel.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A page that posts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>A page that posts</h2>

    <% using (Html.BeginForm("CreatePost", "BlogPanel")) { %>
        <fieldset>
            <legend>Blog post</legend>
        <label>Title</label>
            <%: Html.TextBox("title") %>
            <label>Content</label>
            <%: Html.TextArea("body", new { @class = "ckeditor"})%>
            <label>tags</label>
            <%: Html.TextBox("tags") %>
            <label>Static link</label>
            <%: Html.TextBox("link") %>            
            <p>
                <button type="submit" class="btn">Send post</button>
            </p>
        </fieldset>
    <%} %>

</asp:Content>
