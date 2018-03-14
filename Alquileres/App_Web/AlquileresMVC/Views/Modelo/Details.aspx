<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AlquileresMVC.Models.Modelo>" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.DisplayNameFor() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% using (Html.BeginForm()){%>       
		<%=  Html.BeginSection("../../Content/images/hpantalla/bicycle.png", Html.DisplayNameDetailsFor().ToHtmlString().ToUpper())%>
		<%=  Html.BeginSectionBody()%>

        <%=  Html.BeginSectionItemDataRow() %>
        <%=  Html.LabelDisplayItemFor(model => model.ID)%>
        <%=  Html.LabelDisplayItemFor(model => model.Codigo)%>
		<%=  Html.LabelDisplayItemFor(model => model.Descripcion)%>
        <%=  Html.LabelDisplayItemFor(model => model.Estatus)%>
        <%=  Html.EndSectionItemDataRow()%>

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

	    });
		//]]>
	</script>
	
</asp:Content>

