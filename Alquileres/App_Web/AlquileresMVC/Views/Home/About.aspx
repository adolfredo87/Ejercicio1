<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) {%>
		<%= Html.BeginSection("../../Content/images/hpantalla/about.png", "About".ToString().ToUpper())%>
		<%= Html.BeginSectionBody()%>
		<%= Html.ValidationSummaryWidget()%>
		<p>
        Acerca de Sistema Alquiler de Bicicletas - Ing. Adolfredo Belizario - Para Mostrar a Reclutadores en CSharp
        </p>
		<%= Html.EndSectionBody()%>
        <%= Html.EndSection()%>
    <% } %>
</asp:Content>
