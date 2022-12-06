<%@ Page Title="Detalle de la Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleFactura.aspx.cs" Inherits="Ecommerce.Compras.DetalleFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />


    <div>
       <asp:GridView ID="dgvDetalle" runat="server" class="table table table-dark table-bordered" AllowPaging="true"
           AutoGenerateColumns="false" PageSize="8">
           
            <Columns>
            
                <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="IdOrden" HeaderText="IdOrden" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Articulo" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Precio" HeaderText="Precio por unidad" />
               
     
            </Columns>

       </asp:GridView>
    </div>
    
</asp:Content>
