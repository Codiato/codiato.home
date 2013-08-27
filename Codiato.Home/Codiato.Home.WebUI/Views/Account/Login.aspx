<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Panel.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login to panel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login to panel</h2>
    <% using (Html.BeginForm())
       { %>
    <fieldset>
        <legend>Credentials</legend>
        <div class="control-group">
            <label class="control-label" for="Username">Username</label>
            <div class="controls">
                <%: Html.TextBox("username", "", new { placeholder = "Username" })%>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="Password">Password</label>
            <div class="controls">
                <%: Html.Password("password", "", new { placeholder = "Password" })%>
            </div>
        </div>
        <div class="control-group">
            <div class="controls">
                <label class="checkbox">
                    <%: Html.CheckBox("remember") %>
                    Remember me
                </label>
                <button type="submit" class="btn">Sign in</button>
            </div>
        </div>
    </fieldset>

    <%} %>
</asp:Content>
