<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Ecommerce.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1><%: Title %></h1>

    
    <br />

    <asp:GridView ID="dgvCarrito" runat="server"  OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged"  AutoGenerateColumns="false" class="table table-bordered table-condensed table-hover " >

        <Columns>
            
            <asp:BoundField DataField="Id" HeaderText="ID Producto" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                 <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:ImageField   ControlStyle-Width="50" ControlStyle-Height="50" ControlStyle-CssClass="rounded mx-auto d-block" DataImageUrlField="URLImagen" HeaderText="Imagen">
            </asp:ImageField> 
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

            <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderText="Acción" />
             

              
        </Columns>
    </asp:GridView>
   
    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
      <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
      </svg>
    <asp:Label ID="lblt" CssClass="label" runat="server" Text=" Total a Pagar:" Font-Size="25px"></asp:Label>
    <asp:Label ID="lblTotal" runat="server" Text="" Font-Size="25px"></asp:Label>



</asp:Content>
