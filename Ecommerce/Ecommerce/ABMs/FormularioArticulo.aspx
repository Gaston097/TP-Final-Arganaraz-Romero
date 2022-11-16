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
         <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
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
                  Categoria agregada con exito!
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
