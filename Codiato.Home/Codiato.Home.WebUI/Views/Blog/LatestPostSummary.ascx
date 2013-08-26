<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Codiato.Home.WebUI.Models.Post>" %>

<% if (Model == null)
   { %>
No posts to show
<%}
   else { %>
<h2><%: Model.Title %></h2>

<%= Model.Content %>
<%} %>