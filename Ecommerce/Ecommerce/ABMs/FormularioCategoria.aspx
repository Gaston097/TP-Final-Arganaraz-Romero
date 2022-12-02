<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="Ecommerce.ABMs.FormularioCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <h3>Formulario Item Categoria</h3>

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

    <div class="row">
        <div class="col-6">
      <div class="mb-3">
         <label for="txtDesc" class="form-label">Nombre del item</label>
          <asp:TextBox ID="txtDesc" CssClass="form-control" runat="server"></asp:TextBox>
      </div>
         <div class="mb-3">

           
             <button type="button" class="btn btn-dark" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                Aceptar
            </button>



             <a class="btn btn-dark" href="ABMCategorias" > Volver a ABM de Categorias </a>


             
<div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      
      <div class="modal-body" style="color:green">
          Categoria agregada con exito!
          <i class="fa fa-check-circle" aria-hidden="true"></i>
      </div>

      <div class="modal-footer">
         <asp:Button CssClass="btn btn-dark" ID="Button1" OnClick="btnAceptar_Click" runat="server" Text="Aceptar"/>
      </div>
    </div>
  </div>
</div>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                     <div class="row">
                      <div class="col-6">
                         <div class="mb-3">                           
                             <br />
                             <asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" CssClass="btn btn-danger" text="Eliminación" />
                         </div>
                          <%if (Confirmacion) { %>
                         <div class="mb-3">
                             <asp:CheckBox ID="ChkConfirmaEliminacion" runat="server" Text="Confirmar Eliminación" />
                             <asp:Button ID="btnEliminarConfirma" OnClick="btnEliminarConfirma_Click"  runat="server" CssClass="btn btn-danger" text="Eliminar" />
                         </div>
                       <%  } %> 
                      </div>
              </div>
                </ContentTemplate>
             </asp:UpdatePanel>

          </div>
      </div>
    </div>

 
      <%
      }
        %>  



</asp:Content>
