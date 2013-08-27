<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Codiato.Home.WebUI.Models.Post>" %>

<article>
    <div class="blog-post">
        <h2><a href="<%: Url.Action("Archive", new { urlKey = Model.StaticLink })%>"><%: Model.Title %></a></h2>
        <div class="post-date">
            <span class="date-month"><%: Model.PublishDate.ToString("MMM") %></span>
            <span class="date-day"><%: Model.PublishDate.Day %></span>
            <span class="date-year"><%: Model.PublishDate.Year %></span>
        </div>
        <div class="post-content">
            <%= Model.Content %>
        </div>
        <div class="post-footer">
            <span class="comment-box"><a href="#">Leave a comment</a></span><span class="tag-box">Tags: <%: string.Join(",", Model.Tags.Select(t => t.TagName).ToArray()) %></span>
        </div>
    </div>
</article>