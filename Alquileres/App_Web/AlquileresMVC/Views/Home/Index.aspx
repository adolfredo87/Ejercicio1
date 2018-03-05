<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AlquileresMVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page - Demostracion para Reclutadores en CSharp ASP.NET MVC - Sistema Alquiler de Bicicletas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) {%>
		<%= Html.BeginSection("../../Content/images/hpantalla/bicycle.png", "Bienvenido a Sistema Alquiler de Bicicletas".ToString().ToUpper())%>
		<%= Html.BeginSectionBody()%>
		<%= Html.ValidationSummaryWidget()%>
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" valign="top">
            <tr>
                <td width="100%" colspan="2" valign="top" align="center">
                    <table border="0" width="100%">
                        <%--Campos del form--%>
                        <tr>
                            <td valign="top">
                                <form action="" method="post" name="form1" id="form1">
                                <table width="100%" height="530px" align="left" cellpadding="5" cellspacing="2" style="border: 0px solid #CCCCCC;">
                                    <tr>
                                        <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF">
                                            &nbsp;
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="2">
                                                    <tr rowspan="2" align="center">
                                                        <td colspan="2" align="center" height="50%" width="50%">
                                                            <fieldset>
                                                                <img src="../../Content/images/hheinz/portadaBicicleta.jpg" align="center" valing="top"
                                                                    style="border: 0px solid #808080; height: 300px; width: 600px;" />
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                </form>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%= Html.EndSectionBody()%>
        <%= Html.EndSection()%>
    <% } %>
</asp:Content>