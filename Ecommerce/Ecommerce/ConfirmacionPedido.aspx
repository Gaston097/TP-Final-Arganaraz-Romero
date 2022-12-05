<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionPedido.aspx.cs" Inherits="Ecommerce.ConfirmacionPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
        <br />
        <h3><u>Por favor, fijese que los datos sean los correctos. Luego presione Confirmar...</u></h3>
        <br /> 
        <h3>Items en Carro: </h3>

        <asp:GridView ID="dgvDetallesOrden" runat="server"  AutoGenerateColumns="false" class="table table-bordered table-condensed " >

            <Columns>
            
                <asp:BoundField DataField="Detalles.Id" HeaderText="ID Producto" />
                <asp:BoundField DataField="Detalles.Nombre" HeaderText="Nombre" >
                        <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Imagen">
                
                <ItemTemplate >
                    <asp:Image ID="Image" runat="server" ImageUrl = '<%# Eval("Detalles.URLImagen") %>' height="120px" CssClass="rounded mx-auto d-block align-content-center" />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="Detalles.Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Detalles.Cantidad" HeaderText="Cantidad" />


            </Columns>
        </asp:GridView>

        <asp:Label ID="lblt" CssClass="label" runat="server" Text=" Precio Total:" Font-Size="22px"></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="" Font-Size="22px"></asp:Label>
        

        <br />
        <br />


        <h3>Datos del usuario:</h3>
        <div>
            <asp:GridView ID="dgvDatosUsuario" runat="server"  AutoGenerateColumns="false"  
                DataKeyNames="Id"  class="table table-bordered table-condensed  "
                AllowPaging="True"  >

                <Columns>
            
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="TipoUsuario.Nombre" HeaderText="Tipo de Usuario" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre de Usuario" />
                    <asp:BoundField DataField="eMail" HeaderText="Correo Electronico" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha de Alta" />
               

                </Columns>

            </asp:GridView>
        </div>

        <div>
            
            <asp:Label ID="lblg" CssClass="label" runat="server" Text=" Metodo de Pago:" Font-Size="25px"></asp:Label>
            <asp:Label ID="lblMetPago" runat="server" Text="" Font-Size="25px"></asp:Label>

        </div>

        <br />
            
        <div>

                <asp:Label CssClass="label" runat="server" Text=" Datos del Domicilio:" Font-Size="25px"></asp:Label>


        <% if (validarDomicilio)
        { %>

            

        
            <asp:GridView ID="dgvDomicilioUsuario" runat="server"
                AutoGenerateColumns="false"   DataKeyNames="Id"  class="table table-bordered table-condensed  "
                >

                        
                    <Columns>
            
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Calle" HeaderText="Calle" />
                        <asp:BoundField DataField="Numero" HeaderText="Altura" />
                        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                        <asp:BoundField DataField="CodPostal" HeaderText="Codigo Postal" />
            
                           
                    </Columns>

                                   

            </asp:GridView>


        <% } 
            else { %>
                
                    <asp:Label CssClass="label" runat="server" Text=" Retira por local" Font-Size="25px"></asp:Label>

        <% } %>

        </div>
        
        <br />
            

  <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Compra" class="btn btn-success" OnClick="btnConfirmar_Click"/>

</asp:Content>
