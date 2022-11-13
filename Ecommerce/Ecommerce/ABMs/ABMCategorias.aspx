<%@ Page Title="ABMCategorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCategorias.aspx.cs" Inherits="Ecommerce.ABMs.ABMCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1><%: Title %></h1>

    <asp:GridView ID="dgvCategorias" runat="server"  OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged"  AutoGenerateColumns="false" class="table table-dark table-bordered " >

        <Columns>
            
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderText="Acción" />
             

              
        </Columns>
    </asp:GridView>






</asp:Content>
