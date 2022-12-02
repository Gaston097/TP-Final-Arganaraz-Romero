<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMUsuarios.aspx.cs" Inherits="Ecommerce.ABMs.ABMUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <br />
    <h1><%: Title %> </h1>
       <% if ((((dominio.Usuario)Session["user"]) == null) || (((dominio.Usuario)Session["user"]).TipoUsuario.ID != 4) )
               {
        %>

        <div style="color:red">No tiene permisos para acceder aqui</div>
        <br />
        <a class="btn btn-primary" href="../Login.aspx" > Iniciar Sesion </a>
        <%
            }
            else
            {
        %>  
    <div>
        <asp:GridView ID="dgvUsuarios" runat="server"  OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" 
            AutoGenerateColumns="false"   DataKeyNames="Id"  class="table table-dark table-bordered "
            OnPageIndexChanging="dgvUsuarios_PageIndexChanging"
            AllowPaging="True" PageSize="5" >

            <Columns>
            
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="TipoUsuario.Nombre" HeaderText="Tipo de Usuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre de Usuario" />
                <asp:BoundField DataField="eMail" HeaderText="Correo Electronico" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha de Alta" />
               

                <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar"/>
                <asp:CommandField ShowSelectButton="true" SelectText="🛠️" HeaderText="Modificar"/>
                           
            </Columns>

        </asp:GridView>
    </div>
    
     <a class="btn btn-dark" href="FormularioUsuario" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>
     
      <%
          }
  %>  

</asp:Content>
