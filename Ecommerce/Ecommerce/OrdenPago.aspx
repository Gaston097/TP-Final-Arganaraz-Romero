<%@ Page Title="Orden de Pago" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenPago.aspx.cs" Inherits="Ecommerce.OrdenPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1> Finalizar Orden de Pago </h1>

    
    <div> ¿De que manera desea receptar la compra? </div>
    <br />
    <br />
  
    <div class="accordion accordion-flush" id="accordionFlushExample">
        <div class="accordion-item">
            <h2 class="accordion-header" id="flush-headingOne">
                <button class="accordion-button bg-secondary text-white collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne">
                Retirar a traves de envio
                </button>
            </h2>
            <div id="flush-collapseOne" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">
                    <%--
                        Agregar funcion en HTML para verificar que tenga un domicilio  
                    --%>
                    Este usuario no tiene ningun domicilio registrado a su nombre. Por favor, ingrese un
                    domicilio previo a registrar una orden de compra
                    <br />
                    <br />
                    <a type="button" class="btn btn-secondary" href="ABMs/ABMDomicilio">Ingresar un domicilio</a>
                    <%--

                        Tras verificar si hay un domicilio registrado, mostrar un boton que permita
                        finalizar la compra y generar la orden de pago

                    --%>
                </div>
            </div>
        </div>
            <div class="accordion-item">
                <h2 class="accordion-header" id="flush-headingTwo">
                    <button class="accordion-button bg-secondary text-white collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseTwo" aria-expanded="false" aria-controls="flush-collapseTwo">
                    Retirar por local
                    </button>
                </h2>
                <div id="flush-collapseTwo" class="accordion-collapse collapse" aria-labelledby="flush-headingTwo" data-bs-parent="#accordionFlushExample">
                    <div class="accordion-body">
                        Aqui va un boton para registrar la orden de pago

                    </div>
                </div>
            </div>
            
    </div>
        


</asp:Content>
