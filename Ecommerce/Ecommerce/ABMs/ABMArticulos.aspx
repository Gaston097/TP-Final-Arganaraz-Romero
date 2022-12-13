<%@ Page Title="ABMArticulos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMArticulos.aspx.cs" Inherits="Ecommerce.ABMs.ABMArticulos" %>
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
                            <asp:TextBox runat="server" ID="txtfiltro" AutoPostBack="true" MaxLength="40" style="min-width: 600px; height: 25px" OnTextChanged="txtfiltro_TextChanged"
                    CssClass="form-control"/>
                     </div>
                </div>              
            </tr>
        </tbody>
    </table>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <div>
        <asp:GridView ID="dgvArticulos" runat="server"  OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" 
            AutoGenerateColumns="false"   DataKeyNames="Id"  class="table table-dark table-bordered table-striped"
            OnPageIndexChanging="dgvArticulos_PageIndexChanging"
            AllowPaging="True" PageSize="4"
            >

            <Columns>
            
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:TemplateField HeaderText="Imagen">
                
                <ItemTemplate >
                    <asp:Image ID="Image" runat="server" ImageUrl ='<%# Eval("Imagen") %>' height="120px" CssClass="rounded mx-auto d-block align-content-center" />
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:BoundField DataField="EstadoComer" HeaderText="EstadoComercial" />
                <asp:BoundField DataField="Descuento" HeaderText="Descuento" />   
                <asp:TemplateField HeaderText="Accion" ItemStyle-Width="100" HeaderStyle-Width="100" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnModificar" OnClick="btnModificar_Click" runat="server" CssClass="btn btn-info" data-toggle="tooltip" ToolTip="Modificar">
                            <i class="fa-solid fa-pencil"></i>
                            </asp:LinkButton>            
                 </ItemTemplate>
                </asp:TemplateField>
                           
            </Columns>
        </asp:GridView>
    </div>
        
    </ContentTemplate>
    </asp:UpdatePanel>

    
     <a class="btn btn-success" href="FormularioArticulo" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>
     

      <%
          }
  %>  


</asp:Content>
