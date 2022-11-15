<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCategoria.aspx.cs" Inherits="Ecommerce.ABMs.AltaCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <h3>Alta item Categoria</h3>
    <div class="row">
        <div class="col-6">
      <div class="mb-3">
         <label for="txtDesc" class="form-label">Nombre del nuevo item</label>
          <asp:TextBox ID="txtDesc" CssClass="form-control" runat="server"></asp:TextBox>
      </div>
         <div class="mb-3">
             <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Aceptar"/>
             <asp:Button ID="btnVolver" OnClick="btnVolver_Click" runat="server" Text="Volver" />
          </div>
      </div>
    </div>




</asp:Content>
