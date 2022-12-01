<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionPedido.aspx.cs" Inherits="Ecommerce.ConfirmacionPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1> Aca va los datos ya pre cargados del User/Carrito (Se podria hacer un dgv)</h1>

    <h3>☼Por favor fijese que los datos sean los correctos. Luego presione Confirmar...</h3>

     <div class="row">
        <div class="col-6">
      <div class="mb-3">
         <label for="txtDesc" class="form-label">Datos de usuario</label>
          <asp:GridView ID="dgvDatosUser" class="table table-dark table-bordered " runat="server"></asp:GridView>

      </div>
            </div>
         </div>

</asp:Content>
