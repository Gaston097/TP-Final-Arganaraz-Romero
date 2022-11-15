<%@ Page Title="ABMCategorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCategorias.aspx.cs" Inherits="Ecommerce.ABMs.ABMCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1><%: Title %> </h1>


    <asp:GridView ID="dgvCategorias" runat="server"  OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged"  AutoGenerateColumns="false" DataKeyNames="Id"  class="table table-dark table-bordered " >

        <Columns>
            
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar"/>
            <asp:CommandField ShowSelectButton="true" SelectText="🛠️" HeaderText="Modificar"/>
             

              
        </Columns>


    </asp:GridView>

    
     <a class="btn btn-dark" href="FormularioCategoria.aspx" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>
     



</asp:Content>
