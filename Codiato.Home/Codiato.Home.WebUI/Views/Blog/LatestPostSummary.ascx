<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Codiato.Home.WebUI.Models.Post>" %>

<h2><%: Model.Title %></h2>

<%= Model.Content %>