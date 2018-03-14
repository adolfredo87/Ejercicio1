<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AlquileresMVC.Models.Alquiler>" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.DisplayNameFor() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
   <% using (Html.BeginForm()){%>
        <%= Html.BeginSection("./../Content/images/hpantalla/bicycle.png", Html.DisplayNameFor().ToHtmlString().ToUpper())%>
        <%= Html.BeginSectionBody(true)%>        
        <%= Html.GridJQuery("Alquiler")%>  
        <%= Html.EndSectionBody()%> 
        <%= Html.BeginBarButtons()%>
        <%= Html.ActionLinkCreate()%>
        <%= Html.ActionLinkPrintGrid("Alquiler")%>
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
	        var jqTableGrid = mvcLocal.jqGrid.init("Alquiler");
	        //
	        // Especifica los nombre de las columnas
	        jqTableGrid.mvcUI.config.options.colNames = ["ID", "Cliente", "Producto", "Hora", "Dia", "Semana", 
                                                        "Precio", "Estatus", "Acciones"];
	        //
	        // configura las columnas
	        jqTableGrid.mvcUI.config.options.colModel =
				[
					{ name: "ID", index: "ID", width: 30, align: "left" },
                    { name: "Cliente", index: "Cliente", width: 100, align: "left" },
					{ name: "Producto", index: "Producto", width: 100, align: "left" },
                    { name: "TiempoHora", index: "TiempoHora", width: 80, align: "left" },
                    { name: "TiempoDia", index: "TiempoDia", width: 80, align: "left" },
					{ name: "TiempoSemana", index: "TiempoSemana", width: 50, align: "left" },
                    { name: "PrecioEstimado", index: "PrecioEstimado", width: 50, align: "left" },
                    { name: "Estatus", index: "Estatus", width: 50, align: "left" },
					mvcLocal.jqGrid.columnActionsDetailAndEdit
				];
	        
            jqTableGrid.mvcUI.config.searchOptions.sopt = ['cn', 'eq', 'ne'];
            //
	        // Default sorting
	        jqTableGrid.mvcUI.config.options.sortname = "ID";
	        //
	        // carga y setea el jquery grid
	        mvcLocal.jqGrid.loadGrid(jqTableGrid);

	    });
        //]]>
    </script>
</asp:Content>

