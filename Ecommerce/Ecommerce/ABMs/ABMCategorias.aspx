<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCategorias.aspx.cs" Inherits="Ecommerce.ABMs.ABMCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1><%: Title %> </h1>
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

      <table style="width: 100%" class="table table-primary">
        <tbody>
            <tr>
                <td style="width: 100%">
                    <div class="form-group">
                        <label style="font-size: 15px;" class="col-md-6"> Filtrar:</label>
                      <div class="col-md-6">
                            <asp:TextBox runat="server" ID="txtfiltro" AutoPostBack="true" MaxLength="40" style="min-width: 600px; height: 25px" OnTextChanged="filtro_TextChanged"
                    CssClass="form-control"/>
                     </div>
                </div>              
            </tr>
        </tbody>
    </table> 
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <asp:GridView ID="dgvCategorias" runat="server"  
        OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged"  
        AutoGenerateColumns="false" DataKeyNames="Id"  class="table table-dark table-bordered table-striped"
        OnPageIndexChanging="dgvCategorias_PageIndexChanging"
        AllowPaging="True" PageSize="10" >
   

        <Columns>
            
            <asp:BoundField DataField="Id" HeaderText="ID" />
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

     <a class="btn btn-success" href="FormularioCategoria.aspx" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>
     
      <%
          }
  %>  


</asp:Content>
