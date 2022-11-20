<%@ Page Title="ABMMain" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMain.aspx.cs" Inherits="Ecommerce.ABMMain" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1> Menu de ABMs </h1>

    <br />

     <asp:Button runat="server" class="btn btn-dark"   Text="ABM de Categorias" OnClick="Unnamed_Click" />
    
    <asp:Button runat="server" class="btn btn-dark" Text="ABM de Marcas" ID="btnAbmMarcas" OnClick="btnAbmMarcas_Click" />
    
    <a class="btn btn-dark" href="ABMs/ABMArticulos" > ABM de Articulos</a>

    <a class="btn btn-dark" href="ABMs/ABMUsuarios" > ABM de Usuarios</a>




</asp:Content>
