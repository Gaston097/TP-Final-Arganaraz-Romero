<%@ Page Title="Detalle de la Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleFactura.aspx.cs" Inherits="Ecommerce.Compras.DetalleFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h2>Detalles de Orden de Compra N° <%= id %></h2>
    <br />
    <div>
       <asp:GridView ID="dgvDetalle" runat="server" class="table table table-secondary table-bordered" AllowPaging="true"
           AutoGenerateColumns="false" PageSize="8">
           
            <Columns>
            
                <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="IdOrden" HeaderText="IdOrden" Visible="false" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Articulo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion Articulo" />
                <asp:TemplateField HeaderText="Imagen">
                    <ItemTemplate>
                        <asp:Image ID="Image" runat="server" ImageUrl ='<%# Eval("Imagen") %>' height="120px" CssClass="rounded mx-auto d-block align-content-center" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Precio" HeaderText="Precio por unidad" />
               
     
            </Columns>

       </asp:GridView>
    </div>
    
    <a class="btn btn-dark" href="../Compras/GestorCompras.aspx" > Volver a Gestion de Ordenes de Compras </a>
     

</asp:Content>
