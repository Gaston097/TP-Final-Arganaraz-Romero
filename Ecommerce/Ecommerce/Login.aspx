<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecommerce.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1> Bienvenido, ingrese su usuario </h1>

    <div class="mb-3">
            <label for="txtUsuario" class="form-label">Nombre de Usuario</label>
            <asp:TextBox  ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
            <label for="txtContraseña" class="form-label">Contraseña</label>
            <asp:TextBox TextMode="Password" ID="txtContraseña" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button CssClass="btn btn-dark" ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="Aceptar"/>


</asp:Content>
