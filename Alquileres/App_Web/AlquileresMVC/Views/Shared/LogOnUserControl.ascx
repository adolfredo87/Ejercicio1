<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
        if (DateTime.Now.Hour > 5 && DateTime.Now.Hour < 12 ){
            %>Buenos días, <%                      
        }else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 19 ){
            %>Buenos tardes, <%                 
        }else{
            %>Buenos noches, <%   
        } 
%>