<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMUsuarios.aspx.cs" Inherits="Ecommerce.ABMs.ABMUsuarios" %>
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
            AutoGenerateColumns="false"   DataKeyNames="Id"  class="table table-dark table-bordered table-striped "
            OnPageIndexChanging="dgvUsuarios_PageIndexChanging"
            AllowPaging="True" PageSize="5" >

            <Columns>
            
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="TipoUsuario.Nombre" HeaderText="Tipo de Usuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre de Usuario" />
                <asp:BoundField DataField="eMail" HeaderText="Correo Electronico" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha de Alta" />
               <asp:TemplateField HeaderText="Accion" ItemStyle-Width="100" HeaderStyle-Width="100" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnModificar" OnClick="btnModificar_Click" runat="server" CssClass="btn btn-info" data-toggle="tooltip" ToolTip="Modificar">
                            <i class="fa-solid fa-pencil"></i>
                            </asp:LinkButton>            
                 </ItemTemplate>
                </asp:TemplateField>
                           
            </Columns>

        </asp:GridView>
    </div>
    
     <a class="btn btn-success" href="FormularioUsuario" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>
     
      <%
          }
  %>  

</asp:Content>
