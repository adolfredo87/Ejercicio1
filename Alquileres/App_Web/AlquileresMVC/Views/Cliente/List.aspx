<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AlquileresMVC.Models.Cliente>" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.DisplayNameFor() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
   <% using (Html.BeginForm()){%>
        <%= Html.BeginSection("./../Content/images/hpantalla/bicycle.png", Html.DisplayNameFor().ToHtmlString().ToUpper())%>
        <%= Html.BeginSectionBody(true)%>        
        <%= Html.GridJQuery("Cliente")%>  
        <%= Html.EndSectionBody()%> 
        <%= Html.BeginBarButtons()%>
        <%= Html.ActionLinkCreate()%>
        <%= Html.ActionLinkPrintGrid("Cliente")%>
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
	        var jqTableGrid = mvcLocal.jqGrid.init("Cliente");
	        //
	        // Specify the column names
	        jqTableGrid.mvcUI.config.options.colNames = ["ID", "Nombre", "Telefono", "Correo", "Acciones"];
	        //
	        // Configure the columns
	        jqTableGrid.mvcUI.config.options.colModel =
				[
					{ name: "ID", index: "ID", width: 50, align: "left" },
					{ name: "Nombre", index: "Nombre", width: 100, align: "left" },
					{ name: "Telefono", index: "Telefono", width: 80, align: "left" },
					{ name: "Correo", index: "Correo", width: 70, align: "left" },
					mvcLocal.jqGrid.columnActions
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

