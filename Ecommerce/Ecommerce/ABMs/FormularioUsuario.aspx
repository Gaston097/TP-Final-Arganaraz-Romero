<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="Ecommerce.ABMs.FormularioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


       
    <br />
    <h1> Formulario Item Usuario </h1>


        <div class="row">
            <div class="col-6">
                
                <div class="mb-3">
                     <label for="ddlTipoUsuario" class="form-label">Tipo de Usuario</label>
                     <br />
                     <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control border btn dropdown-toggle">
                     </asp:DropDownList>
                </div>

                <div class="mb-3">
                     <label for="txtUsuario" class="form-label">Nombre del Usuario</label>
                     <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                     <label for="txtContrasena" class="form-label">Contraseña</label>
                     <asp:TextBox ID="txtContrasena" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
                
                <div class="mb-3">
                     <label for="txtEmail" class="form-label">Correo Electronico</label>
                     <asp:TextBox ID="txtEmail" CssClass="form-control " runat="server"></asp:TextBox>
                </div>





    <div class="mb-3">
        <button type="button" class="btn btn-dark" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
             Aceptar
        </button>
        <a class="btn btn-dark" href="ABMUsuarios" > Volver a ABM de Usuarios </a>


        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
      
              <div class="modal-body" style="color:green">
                  Usuario agregado con exito!
                  <i class="fa fa-check-circle" aria-hidden="true"></i>
              </div>

              <div class="modal-footer">
                 <asp:Button CssClass="btn btn-dark" ID="Button1" OnClick="btnAceptar_Click" runat="server" Text="Aceptar"/>
              </div>
            </div>
          </div>
        </div>


          </div>
      </div>
    </div>







</asp:Content>
