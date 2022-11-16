<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioMarca.aspx.cs" Inherits="Ecommerce.ABMs.FormularioMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <h3>Formulario Item Marca</h3>
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

             
             <a class="btn btn-dark" href="ABMMarcas" > Volver a ABM de Marcas</a>


             
            <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
              <div class="modal-dialog">
                <div class="modal-content">
      
                  <div class="modal-body" style="color:green">
                      Marca agregada con exito!
                      <i class="fa fa-check-circle" aria-hidden="true"></i>
                  </div>

                  <div class="modal-footer">
                      <asp:Button CssClass="btn btn-dark" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
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
                             <asp:Button ID="btnEliminarConfirma" OnClick="btnEliminarConfirma_Click" runat="server" CssClass="btn btn-danger" text="Eliminar" />
                         </div>
                       <%  } %> 
                      </div>
              </div>
                </ContentTemplate>
             </asp:UpdatePanel>
               
          </div>
      </div>
    </div>

 



</asp:Content>
