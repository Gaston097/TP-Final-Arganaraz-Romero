<%@ Page Title="ABMMarcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMarcas.aspx.cs" Inherits="Ecommerce.ABMs.ABMMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
       <% if ((((dominio.Usuario)Session["user"]) == null) || (((dominio.Usuario)Session["user"]).TipoUsuario.ID != 4) )
               {
        %>

        <div style="color:red">No tiene permisos para acceder aqui</div>
        <br />
        <a class="btn btn-primary" href="Login" > Iniciar Sesion </a>
        <%
            }
            else
            {
        %>  
     <div class="row">      
            <div class="col-6">
                <div class="mb-3">
                <asp:Label Text="Filtrar:" runat="server" />
                <asp:TextBox runat="server" ID="txtfiltro" AutoPostBack="true" OnTextChanged="txtfiltro_TextChanged"
                    CssClass="form-control"/>
                </div>
            </div>
     </div>   

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <asp:GridView ID="dgvMarcas" runat="server" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" 
        AutoGenerateColumns="false" DataKeyNames="Id" class="table table-dark table-bordered " 
        AllowPaging="True" PageSize="10" OnPageIndexChanging="dgvMarcas_PageIndexChanging"
        >
        <Columns>

            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar"/>           
            <asp:CommandField ShowSelectButton="true" SelectText="🛠️" HeaderText="Modificar"/>
        </Columns>
    </asp:GridView>

    </ContentTemplate>
    </asp:UpdatePanel>

     <a class="btn btn-dark" href="FormularioMarca" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>

      <%
          }
  %>  

</asp:Content>
