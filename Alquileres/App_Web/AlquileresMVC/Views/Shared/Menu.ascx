<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="AlquileresMVC.Helpers.Menu" %>
<div id="mainMenu" runat="server" active="3">

   <%= Html.BeginMenuItem("Procesos")%>
        <%= Html.MenuItemLink("../../Content/images/hbotons/tasks.png", " Alquileres", "List", "Alquiler")%>
        <%= Html.MenuItemLink("../../Content/images/hbotons/payment.png", " Alquileres Por Pagar", "List", "PagoCabecera")%>
    <%= Html.EndMenuItem()%>
    
    <%= Html.BeginMenuItem("Maestros")%>
        <%= Html.MenuItemLink("../../Content/images/hbotons/customers.png", " Clientes", "List", "Cliente")%>
        <%= Html.MenuItemLink("../../Content/images/hbotons/special_offer.png", " Descuentos", "List", "Descuento")%> 
        <%= Html.MenuItemLink("../../Content/images/hbotons/price_tag.png", " Precios", "List", "Precio")%> 
        <%= Html.MenuItemLink("../../Content/images/hbotons/bicycle.png", " Bicicletas", "List", "Bicicleta")%>
        <%= Html.MenuItemLink("../../Content/images/hbotons/category.png", " Categoria Bicicleta", "List", "CategoriaBicicleta")%>
    <%= Html.EndMenuItem()%>
    
    <%= Html.BeginMenuItem("Ayuda")%>
        <%= Html.MenuItemLink("../../Content/images/hbotons/about.png", "About", "About", "Home")%>
    <%= Html.EndMenuItem()%>
    
    <asp:TextBox ID="active" runat="server" style="display:none" ></asp:TextBox>
</div>

<% 
   if (this.Session["imnu"] == null)
   {
       this.Session["imnu"] = 0;
   }
   if (Request.QueryString["imnu"] != null)
   {
       try
       {
           this.Session["imnu"] = int.Parse(Request.QueryString["imnu"]);
       }
       catch { this.Session["imnu"] = 0; }
   }
   int MenuOption = (int)this.Session["imnu"];        
%>

<script type="text/javascript">
//<![CDATA[
    $(function() {
        var mainMenu = $("#<%=this.mainMenu.ClientID %>")

        $(mainMenu).accordion
		({
		    collapsible: true,
		    heightStyle: "fill",
		    active: parseInt("<%=MenuOption %>")
		    //activate: function(event, ui) { 
		    // event activate panel menu
		    //}
		});

        mvcLocal.utility.setActionMenu(mainMenu);
    });
//]]>
</script>
