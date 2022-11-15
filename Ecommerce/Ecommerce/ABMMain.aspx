<%@ Page Title="ABMMain" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMain.aspx.cs" Inherits="Ecommerce.ABMMain" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1> Menu de ABMs </h1>

    <br />

     <asp:Button runat="server" class="btn btn-primary"   Text="ABM de Categorias" OnClick="Unnamed_Click" />
    
    <asp:Button runat="server" class="btn btn-primary" Text="ABM de Marcas" ID="btnAbmMarcas" OnClick="btnAbmMarcas_Click" />
    


</asp:Content>
