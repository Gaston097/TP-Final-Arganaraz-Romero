﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaMarca.aspx.cs" Inherits="Ecommerce.ABMs.AltaMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <h3>Alta item Marca</h3>
    <div class="row">
        <div class="col-6">
      <div class="mb-3">
         <label for="txtDesc" class="form-label">Nombre del nuevo item</label>
          <asp:TextBox ID="txtDesc" CssClass="form-control" runat="server"></asp:TextBox>
      </div>
         <div class="mb-3">

           
             <button type="button" class="btn btn-dark" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                Aceptar
            </button>


            <div class="modal fade" data-bs-keyboard="false" id="confirmarAgregar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static">
                <div class="modal-dialog">
                    <div class="modal-content">
                                    
                        <div class="modal-body" style="color:green">
                        Marca agregada con exito!
                        <i class="fa fa-check-circle" aria-hidden="true"></i>
                        </div>
                        <div class="modal-footer">
                       
                        </div>
                    </div>
                    </div>
                </div>
             <a class="btn btn-dark" href="ABMMarcas" > Volver a ABM de Marcas </a>


             

<div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      
      <div class="modal-body" style="color:green">
          Marca agregada con exito!
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
