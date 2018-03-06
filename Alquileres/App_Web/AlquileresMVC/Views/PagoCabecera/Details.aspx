<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AlquileresMVC.Models.PagoCabecera>" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= "Pagos Pendientes".ToString()%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% using (Html.BeginForm()){%>       
		<%=  Html.BeginSection("../../Content/images/hpantalla/bicycle.png", "Detalle Pagos Pendientes".ToString().ToUpper())%>
		<%=  Html.BeginSectionBody()%>
		
		<%=  Html.BeginSectionItemDataRow() %>
		<%=  Html.LabelDisplayItemFor(model => model.IDCliente)%>
		<%=  Html.LabelDisplayItemFor(model => model.Fecha)%>
        <%=  Html.LabelDisplayItemFor(model => model.MontoTotal)%>
        <%=  Html.LabelDisplayItemFor(model => model.Estatus)%>
        <%=  Html.EndSectionItemDataRow()%>

        <%=  Html.GridJQueryDisplayItem(model => model, "Alquileres")%>

		<%=  Html.EndSectionBody()%>
		<%=  Html.BeginBarButtons()%>
		<%=  Html.ActionLinkBack() %>
		<%=  Html.EndBarButtons()%>
		<%=  Html.EndSection()%>
	<%}%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
	<script type='text/javascript'>
		//<![CDATA[
	    var mvcSectionBox = $("#MvcSectionBox");
	    $(function () {
	        var jqTableGrid = mvcLocal.jqGrid.initAjax("Alquileres");
	        //
	        // Specify the url get data
	        jqTableGrid.mvcUI.config.options.url = "../GetListAlquileres/<%= Model.IDCliente %>";
	        //
	        // Specify the column names
	        jqTableGrid.mvcUI.config.options.colNames = ["ID", "Cliente", "Bicicleta", "Hora", "Dia", "Semana",
                                                        "Precio", "Estatus"];
	        //
	        // Configure the columns
	        jqTableGrid.mvcUI.config.options.colModel = [
                    { name: "ID", index: "ID", width: 30, align: "left" },
                    { name: "Cliente", index: "Cliente", width: 100, align: "left" },
					{ name: "Bicicleta", index: "Bicicleta", width: 100, align: "left" },
                    { name: "TiempoHora", index: "TiempoHora", width: 80, align: "left" },
                    { name: "TiempoDia", index: "TiempoDia", width: 80, align: "left" },
					{ name: "TiempoSemana", index: "TiempoSemana", width: 50, align: "left" },
                    { name: "PrecioEstimado", index: "PrecioEstimado", width: 50, align: "left" },
                    { name: "Estatus", index: "Estatus", width: 50, align: "left", sortable: false }
			];
	        //
	        // Default sorting
	        jqTableGrid.mvcUI.config.options.sortname = "ID";
	        //
	        // load and set up the jquery grid
	        mvcLocal.jqGrid.loadGrid(jqTableGrid);

	    });
		//]]>
	</script>
	
</asp:Content>

