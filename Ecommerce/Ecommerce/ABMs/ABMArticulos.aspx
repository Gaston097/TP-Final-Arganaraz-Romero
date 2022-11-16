<%@ Page Title="ABMArticulos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMArticulos.aspx.cs" Inherits="Ecommerce.ABMs.ABMArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <br />
    <h1><%: Title %> </h1>


    <asp:GridView ID="dgvArticulos" runat="server"  OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"  AutoGenerateColumns="false" DataKeyNames="Id"  class="table table-dark table-bordered " >

        <Columns>
            


            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="Imagen" HeaderText="Imagen" />
            <asp:BoundField DataField="EstadoComer" HeaderText="EstadoComercial" />
            <asp:BoundField DataField="Descuento" HeaderText="Descuento" />

            <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar"/>
            <asp:CommandField ShowSelectButton="true" SelectText="🛠️" HeaderText="Modificar"/>
             

              
        </Columns>


    </asp:GridView>

    
     <a class="btn btn-dark" href="FormularioArticulo" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>
     




</asp:Content>
