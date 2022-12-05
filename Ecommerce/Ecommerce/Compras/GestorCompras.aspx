<%@ Page Title="Gestor de Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestorCompras.aspx.cs" Inherits="Ecommerce.Compras.GestorCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1>Gestor de Compras</h1>
    <br />

    <asp:GridView ID="dgvOrdenes" runat="server"  OnSelectedIndexChanged="dgvOrdenes_SelectedIndexChanged" 
        AutoGenerateColumns="false"   DataKeyNames="ID"  class="table table-dark table-bordered "
        OnPageIndexChanging="dgvOrdenes_PageIndexChanging"
        AllowPaging="True" PageSize="8"
        >

        <Columns>
            
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="User.Nombre" HeaderText="Nombre de Usuario del Cliente" />
            <asp:BoundField DataField="MetPago.Nombre" HeaderText="Metodo de Pago Elegido" />
            <asp:BoundField DataField="Domicilio.Ciudad" NullDisplayText="―" HeaderText="Ciudad de Residencia" />
            <asp:BoundField DataField="Domicilio.Calle"  NullDisplayText="―" HeaderText="Calle" />
            <asp:BoundField DataField="Domicilio.Numero" NullDisplayText="―" HeaderText="Altura" />
            <asp:BoundField DataField="Domicilio.CodPostal"  NullDisplayText="―" HeaderText="Codigo Postal" />
            <asp:BoundField DataField="Envio" HeaderText="Envio" />
            <asp:BoundField DataField="Enviado" NullDisplayText="―" HeaderText="Enviado?" />
            <asp:BoundField DataField="Recibido" HeaderText="Recibido?" />
            <asp:BoundField DataField="Pagado" HeaderText="Pagado?" />
            <asp:BoundField DataField="Total" HeaderText="Pago Total" />

            <asp:CommandField ShowSelectButton="true" SelectText="🔎" HeaderText="Ver Detalles"/>

            
        </Columns>
    </asp:GridView>



</asp:Content>
