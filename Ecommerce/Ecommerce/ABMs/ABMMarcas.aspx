<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMarcas.aspx.cs" Inherits="Ecommerce.ABMs.ABMMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h1><%: Title %> </h1>
    <br />
       <% if ((((dominio.Usuario)Session["user"]) == null) || (((dominio.Usuario)Session["user"]).TipoUsuario.ID != 4) )
               {
        %>

        <div style="color:red">No tiene permisos para acceder aqui</div>
        <br />
        <a class="btn btn-primary" href="../Login.aspx" > Iniciar Sesion </a>
        <%
            }
            else
            {
        %>  
    <table style="width: 100%" class="table table-primary";>
        <tbody>
            <tr>
                <td style="width: 100%">
                    <div class="form-group">
                        <label style="font-size: 15px;" class="col-md-6"> Filtrar:</label>
                      <div class="col-md-6">
                            <asp:TextBox runat="server" ID="txtfiltro" AutoPostBack="true" MaxLength="40" style="min-width: 600px; height: 25px" OnTextChanged="txtfiltro_TextChanged"
                    CssClass="form-control"/>
                     </div>
                </div>              
            </tr>
        </tbody>
    </table>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <asp:GridView ID="dgvMarcas" runat="server" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" 
        AutoGenerateColumns="false" DataKeyNames="Id" class="table table-dark table-bordered table-striped" 
        AllowPaging="True" PageSize="10" OnPageIndexChanging="dgvMarcas_PageIndexChanging"
        >
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />           
            <asp:TemplateField HeaderText="Accion" ItemStyle-Width="100" HeaderStyle-Width="100" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnModificar" OnClick="btnModificar_Click" runat="server" CssClass="btn btn-info" data-toggle="tooltip" ToolTip="Modificar">
                            <i class="fa-solid fa-pencil"></i>
                            </asp:LinkButton>            
                 </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>

    </ContentTemplate>
    </asp:UpdatePanel>

     <a class="btn btn-success" href="FormularioMarca" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>

      <%
          }
  %>  

</asp:Content>
