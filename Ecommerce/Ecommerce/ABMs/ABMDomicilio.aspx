<%@ Page Title="Domicilio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMDomicilio.aspx.cs" Inherits="Ecommerce.ABMs.ABMDomicilio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <br />
    <h1><%: Title %> </h1>


    <div class="row">
        <div class="col-6">
            <div class="mb-3">
              <label for="txtCalle" class="form-label">Calle:</label>
              <asp:TextBox ID="txtCalle" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
              <label for="txtNumero" class="form-label">Número:</label>
              <asp:TextBox ID="txtNumero" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
              <label for="txtCiudad" class="form-label">Ciudad:</label>
              <asp:TextBox ID="txtCiudad" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
             <div class="mb-3">
              <label for="txtCodpos" class="form-label">Código Postal:</label>
              <asp:TextBox ID="txtCodpos" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:CheckBox ID="chkAceptar" runat="server" text="Corroboré mis datos"/>
    <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" Text="Aceptar" />
   

</asp:Content>
