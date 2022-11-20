<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Ecommerce.ABMs.FormularioArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <h1> Formulario Item Articulo </h1>


        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Codigo del Articulo</label>
                    <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                     <label for="txtNombre" class="form-label">Nombre del Articulo</label>
                     <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                     <label for="txtDescripcion" class="form-label">Descripcion</label>
                     <asp:TextBox ID="txtDescripcion" CssClass="form-control " runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                     <label for="ddlCategoria" class="form-label">Categoria</label>
                     <br />
                     <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control border btn dropdown-toggle">
                     </asp:DropDownList>
                </div>

                <div class="mb-3">
                     <label for="ddlMarca" class="form-label">Marca</label>
                     <br />
                     <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control border btn dropdown-toggle">
                     </asp:DropDownList>
                </div>

                <%-- 
                  REALIZAR DROPDOWN PARA:
                  >CATEGORIA
                  >MARCA
                  >ESTADO COMERCIAL
                
                            --%>
                <div class="mb-3">
                     <label for="txtPrecio" class="form-label">Precio</label>
                     <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                     <label for="txtImagen" class="form-label">Imagen</label>
                     <asp:TextBox ID="txtImagen" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                     <label for="ddlEstadoComercial" class="form-label">Estado Comercial</label>
                     <br />
                     <asp:DropDownList ID="ddlEstadoComercial" runat="server" CssClass="form-control border btn dropdown-toggle">
                     </asp:DropDownList>
                </div>
    
                <div class="mb-3">
                     <label for="txtDescuento" class="form-label">Descuento</label>
                     <asp:TextBox ID="txtDescuento" CssClass="form-control" runat="server"></asp:TextBox>
                </div>


    <div class="mb-3">
        <button type="button" class="btn btn-dark" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
             Aceptar
        </button>
        <a class="btn btn-dark" href="ABMArticulos" > Volver a ABM de Articulos </a>


        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
      
              <div class="modal-body" style="color:green">
                  Articulo agregado con exito!
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
 






</asp:Content>
