<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AlquileresMVC.Models.CategoriaBicicleta>" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.DisplayNameFor() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
   <% using (Html.BeginForm()){%>
        <%= Html.BeginSection("./../Content/images/hpantalla/bicycle.png", Html.DisplayNameFor().ToHtmlString().ToUpper())%>
        <%= Html.BeginSectionBody(true)%>        
        <%= Html.GridJQuery("CategoriaBicicleta")%>  
        <%= Html.EndSectionBody()%> 
        <%= Html.BeginBarButtons()%>
        <%= Html.ActionLinkCreate()%>
        <%= Html.ActionLinkPrintGrid("CategoriaBicicleta")%>
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
	        var jqTableGrid = mvcLocal.jqGrid.init("CategoriaBicicleta");
	        //
	        // Specify the column names
	        jqTableGrid.mvcUI.config.options.colNames = ["ID", "Codigo", "Categoria", "Acciones"];
	        //
	        // Configure the columns
	        jqTableGrid.mvcUI.config.options.colModel =
				[
					{ name: "ID", index: "ID", width: 50, align: "left" },
					{ name: "Codigo", index: "Codigo", width: 50, align: "left" },
					{ name: "Categoria", index: "Categoria", width: 180, align: "left" },
					mvcLocal.jqGrid.columnActions
				];

	        jqTableGrid.mvcUI.config.searchOptions.sopt = ['cn', 'eq', 'ne'];
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

