<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMUsuarios.aspx.cs" Inherits="Ecommerce.ABMs.ABMUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <asp:GridView ID="dgvUsuarios" runat="server" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" AutoGenerateColumns="false" DataKeyNames="Id" class="table table-dark table-bordered " AllowPaging="True" PageSize="10" OnPageIndexChanging="dgvMarcas_PageIndexChanging">
        <Columns>

            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Tipo de Usuario" HeaderText="Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar"/>           
            <asp:CommandField ShowSelectButton="true" SelectText="🛠️" HeaderText="Modificar"/>
        </Columns>
    </asp:GridView>

     <a class="btn btn-dark" href="FormularioMarca" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>








</asp:Content>
