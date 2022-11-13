<%@ Page Title="ABMMain" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMain.aspx.cs" Inherits="Ecommerce.ABMMain" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1><%: Title %></h1>

     <asp:Button runat="server" class="btn btn-primary"  BorderStyle="Outset" Text="ABM de Categorias" OnClick="Unnamed_Click" />
    <br />
    <br />

    <asp:Button runat="server" class="btn btn-primary" Text="ABM de Marcas" ID="btnAbmMarcas" OnClick="btnAbmMarcas_Click" />
    


</asp:Content>
