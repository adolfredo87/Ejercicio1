<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AlquileresMVC.Models.Alquiler>" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.DisplayNameFor() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
		<%= Html.BeginSection("../../Content/images/hpantalla/bicycle.png", Html.DisplayNameEditFor().ToHtmlString().ToUpper())%>
		<%= Html.BeginSectionBody()%>
		<%= Html.ValidationSummaryWidget()%>

        <%= Html.BeginSectionItemDataRow() %>
        <%=  Html.LabelDisplayItemFor(model => model.ID)%>
        <%=  Html.LabelDisplayItemFor(model => model.Bicicleta.Marca)%>
        <%=  Html.LabelDisplayItemFor(model => model.Cliente.Nombre)%>
		<%=  Html.LabelDisplayItemFor(model => model.FechaDesde)%>
        <%=  Html.LabelDisplayItemFor(model => model.FechaHasta)%>
        <%=  Html.LabelDisplayItemFor(model => model.TiempoHora)%>
        <%=  Html.LabelDisplayItemFor(model => model.TiempoDia)%>
        <%=  Html.LabelDisplayItemFor(model => model.TiempoSemana)%>
        <%=  Html.LabelDisplayItemFor(model => model.PrecioEstimado)%>
        <%=  Html.LabelDisplayItemFor(model => model.Estatus)%>
        <%= Html.EndSectionItemDataRow()%>
            
        <%= Html.EndSectionBody()%>
        <%= Html.BeginBarButtons()%>
        <%= Html.BarButtonsEdit()%>
        <%= Html.EndBarButtons()%>
        <%= Html.EndSection()%>
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
	<script type='text/javascript'>
		//<![CDATA[
	    var mvcSectionBox = $("#MvcSectionBox");
	    $(function () {

	    });
        //]]>
    </script>

</asp:Content>

