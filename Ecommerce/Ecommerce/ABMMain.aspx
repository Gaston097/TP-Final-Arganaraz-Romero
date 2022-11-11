<%@ Page Title="ABMMain" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMain.aspx.cs" Inherits="Ecommerce.ABMMain" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1><%: Title %></h1>

    <a href="ABMs/ABMCategorias.aspx">ABM de Categorias</a> 
    <br />
    <a href="ABMs/ABMMarcas.aspx">ABM de Marcas</a>

</asp:Content>
