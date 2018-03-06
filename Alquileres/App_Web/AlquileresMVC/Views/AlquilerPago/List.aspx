<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AlquileresMVC.Models.Cantidad_Alquileres_Pagados_VW>" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= "Pagos Procesados".ToString()%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
   <% using (Html.BeginForm()){%>
        <%= Html.BeginSection("./../Content/images/hpantalla/bicycle.png", "Pagos Procesados".ToString().ToUpper())%>
        <%= Html.BeginSectionBody(true)%>        
        <%= Html.GridJQuery("Cantidad_Alquileres_Pagados_VW")%>  
        <%= Html.EndSectionBody()%> 
        <%= Html.BeginBarButtons()%>
        <%= Html.ActionLinkPrintGrid("Cantidad_Alquileres_Pagados_VW")%>
        <%= Html.ActionLinkHome()%>      
        <%= Html.EndBarButtons()%>
        <%= Html.EndSection()%>
    <%}%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
	<script type='text/javascript'>
		//<![CDATA[
	    var mvcSectionBox = $("#MvcSectionBox");
	    // 
	    // Procedimientos para Configuracion del grid
	    $(function () {
	        var jqTableGrid = mvcLocal.jqGrid.init("Cantidad_Alquileres_Pagados_VW");
	        //
	        // Specify the column names
	        jqTableGrid.mvcUI.config.options.colNames = ["Codigo", "Nombre", "Telefono", "Correo", "Nº de Alquileres",
                                                        "Fecha", "Exento", "Descuento", "Total", "Estatus"];
	        //
	        // Configure the columns
	        jqTableGrid.mvcUI.config.options.colModel =
				[
                    { name: "IDCliente", index: "IDCliente", width: 35, align: "left" },
                    { name: "Nombre", index: "Nombre", width: 100, align: "left" },
                    { name: "Telefono", index: "Telefono", width: 70, align: "left" },
                    { name: "Correo", index: "Correo", width: 100, align: "left" },
					{ name: "NumAlquiler", index: "NumAlquiler", width: 75, align: "left" },
                    { name: "Fecha", index: "Fecha", width: 100, align: "left" },
                    { name: "MontoExento", index: "MontoExento", width: 50, align: "left" },
                    { name: "Descuento", index: "Descuento", width: 50, align: "left" },
                    { name: "MontoTotal", index: "MontoTotal", width: 50, align: "left" },
                    { name: "Estatus", index: "Estatus", width: 40, align: "left" }
				];

	        jqTableGrid.mvcUI.config.searchOptions.sopt = ['cn', 'eq', 'ne'];
	        //
	        // Default sorting
	        jqTableGrid.mvcUI.config.options.sortname = "IDCliente";
	        //
	        // load and set up the jquery grid
	        mvcLocal.jqGrid.loadGrid(jqTableGrid);

	    });
        //]]>
    </script>
</asp:Content>

