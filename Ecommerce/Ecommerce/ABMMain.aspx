<%@ Page Title="ABMMain" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMain.aspx.cs" Inherits="Ecommerce.ABMMain" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
      <h1> Menu de ABMs </h1>

    <br />

           <% if ((((dominio.Usuario)Session["user"]) == null) || (((dominio.Usuario)Session["user"]).TipoUsuario.ID != 4) )
               {
        %>

        <div style="color:red">No tiene permisos para acceder aqui</div>
        <br />
        <a class="btn btn-primary" href="Login" > Iniciar Sesion </a>
        <%
            }
            else
            {
        %>  

     <asp:Button runat="server" class="btn btn-dark"   Text="ABM de Categorias" OnClick="Unnamed_Click" style="width:326px; padding-top:20px; padding-bottom:20px; padding-left:15px; padding-right:15px;"/>
    
    <asp:Button runat="server" class="btn btn-dark" Text="ABM de Marcas" ID="btnAbmMarcas" OnClick="btnAbmMarcas_Click" style="width:326px; padding-top:20px; padding-bottom:20px; padding-left:15px; padding-right:15px;" />
      <br />
    <br />
    <asp:Button runat="server" class="btn btn-dark" OnClick="btnArt_Click" Text="ABM de Articulos" ID="btnArt"  style="width:326px; padding-top:20px; padding-bottom:20px; padding-left:15px; padding-right:15px;" />
   
     <asp:Button runat="server" class="btn btn-dark" OnClick="btnUser_Click" Text="ABM de Usuarios" ID="btnUser"  style="width:326px; padding-top:20px; padding-bottom:20px; padding-left:15px; padding-right:15px;" />
  <%
      }
        %>  


</asp:Content>
