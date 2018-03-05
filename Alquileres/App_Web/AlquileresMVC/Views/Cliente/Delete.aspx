<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AlquileresMVC.Models.Cliente>" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.DisplayNameFor() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% using (Html.BeginForm()){%>       
		<%=  Html.BeginSection("../../Content/images/hpantalla/bicycle.png", Html.DisplayNameDeleteFor().ToHtmlString().ToUpper())%>
		<%=  Html.BeginSectionBody()%>
        <%=  Html.ValidationSummaryWidget()%>
		
        <%=  Html.BeginSectionItemDataRow() %>
		<%=  Html.LabelDisplayItemFor(model => model.ID)%>
		<%=  Html.LabelDisplayItemFor(model => model.Nombre)%>
		<%=  Html.LabelDisplayItemFor(model => model.Telefono)%>
        <%=  Html.LabelDisplayItemFor(model => model.Correo)%>
        <%=  Html.EndSectionItemDataRow()%>

		<%=  Html.MessageDeleteWidget()%>
		<%=  Html.EndSectionBody()%>
		<%=  Html.BeginBarButtons()%>
		<%=  Html.BarButtonsDelete()%>
		<%=  Html.EndBarButtons()%>
		<%=  Html.EndSection()%>
	<%}%>
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

