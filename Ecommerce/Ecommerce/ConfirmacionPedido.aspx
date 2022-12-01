<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionPedido.aspx.cs" Inherits="Ecommerce.ConfirmacionPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
        <br />
        <h3><u>Por favor, fijese que los datos sean los correctos. Luego presione Confirmar...</u></h3>
        <br /> 
        <h3>Items en Carro</h3>

        <asp:GridView ID="dgvCarrito" runat="server"  AutoGenerateColumns="false" class="table table-bordered table-condensed table-hover " >

            <Columns>
            
                <asp:BoundField DataField="Id" HeaderText="ID Producto" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                        <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                <asp:ImageField   ControlStyle-Width="50" ControlStyle-Height="50" ControlStyle-CssClass="rounded mx-auto d-block" DataImageUrlField="URLImagen" HeaderText="Imagen">
                </asp:ImageField> 
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />


            </Columns>
        </asp:GridView>

        <asp:Label ID="lblt" CssClass="label" runat="server" Text=" Precio Total:" Font-Size="22px"></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="" Font-Size="22px"></asp:Label>
        

        <br />
        <br />


        <h3>Datos del usuario</h3>
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
        
        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Compra" class="btn btn-success" OnClick="btnConfirmar_Click"/>

</asp:Content>
