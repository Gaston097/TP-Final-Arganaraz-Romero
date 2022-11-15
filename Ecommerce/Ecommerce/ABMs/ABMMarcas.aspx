<%@ Page Title="ABMMarcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMarcas.aspx.cs" Inherits="Ecommerce.ABMs.ABMMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1><%: Title %></h1>

    <asp:GridView ID="dgvMarcas" runat="server" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged"  AutoGenerateColumns="false" DataKeyNames="Id" class="table table-dark table-bordered " >
        <Columns>

            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar"/>
            <asp:CommandField ShowSelectButton="true" SelectText="🛠️" HeaderText="Modificar"/>
        </Columns>
    </asp:GridView>

     <a class="btn btn-dark" href="FormularioMarca" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>



</asp:Content>
