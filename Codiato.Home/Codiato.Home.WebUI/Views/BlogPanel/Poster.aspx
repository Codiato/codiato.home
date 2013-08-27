<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Panel.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    پست کننده
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>پست کننده</h2>

    <% using (Html.BeginForm("CreatePost", "BlogPanel")) { %>
        <fieldset>
            <legend>مشخصات پست جدید بلاگ</legend>
        <label>عنوان</label>
            <%: Html.TextBox("title") %>
            <label>متن پست</label>
            <%: Html.TextArea("body", new { @class = "ckeditor"})%>
            <label>تگ های پست</label>
            <%: Html.TextBox("tags") %>
            <label>لینک ثابت</label>
            <%: Html.TextBox("link") %>
            <span class="help-block">این لینک ثابتی است که فلان فلان</span>
            <p>
                <button type="submit" class="btn">ارسال پست</button>
            </p>
        </fieldset>
    <%} %>

</asp:Content>
