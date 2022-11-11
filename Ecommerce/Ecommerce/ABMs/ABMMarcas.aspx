<%@ Page Title="ABMMarcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMarcas.aspx.cs" Inherits="Ecommerce.ABMs.ABMMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1><%: Title %></h1>

        <asp:GridView ID="dgvMarcas" runat="server"  OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged"  AutoGenerateColumns="false" class="table table-bordered table-condensed table-hover " >

        <Columns>
            
            <asp:BoundField DataField="Id" HeaderText="ID Producto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderText="Acción" />
             

              
        </Columns>
    </asp:GridView>



</asp:Content>
