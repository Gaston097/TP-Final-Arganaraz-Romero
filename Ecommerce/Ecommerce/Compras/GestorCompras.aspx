<%@ Page Title="Gestor de Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestorCompras.aspx.cs" Inherits="Ecommerce.Compras.GestorCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <h1>Gestion de Ordenes de Compra</h1>
    <br />

     <%if ((((dominio.Usuario)Session["user"]) != null ) && (((dominio.Usuario)Session["user"]).TipoUsuario.ID == 2 ))
         {
            %>
            <asp:GridView ID="dgvOrdenesCliente" runat="server"  OnSelectedIndexChanged="dgvOrdenesCliente_SelectedIndexChanged" 
        AutoGenerateColumns="false"   DataKeyNames="ID"  class="table table-secondary table-bordered "
        OnPageIndexChanging="dgvOrdenesCliente_PageIndexChanging"
        AllowPaging="True" PageSize="8"
        >

        <Columns>
            
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="User.Nombre" HeaderText="Nombre de Usuario del Cliente" />
            <asp:BoundField DataField="MetPago.Nombre" HeaderText="Metodo de Pago Elegido" />
            <asp:BoundField DataField="Domicilio.Ciudad" NullDisplayText="―"  HeaderText="Ciudad de Residencia" />
            <asp:BoundField DataField="Domicilio.Calle"  NullDisplayText="―" HeaderText="Calle" />
            <asp:BoundField DataField="Domicilio.Numero" NullDisplayText="―" HeaderText="Altura" />
            <asp:BoundField DataField="Domicilio.CodPostal"  NullDisplayText="―" HeaderText="Codigo Postal" />
            
            <asp:TemplateField HeaderText = "Envio">
                <ItemTemplate>
                    <asp:CheckBox ID="chbEnvio" runat="server" OnClick="return false;" Checked='<%# Convert.ToBoolean(Eval("Envio")) %>'  />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText = "Enviado?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbEnviado" runat="server"  OnClick="return false;" Checked='<%# Convert.ToBoolean(Eval("Enviado")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText = "Recibido?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbRecibido" runat="server" OnClick="return false;"  Checked='<%# Convert.ToBoolean(Eval("Recibido")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText = "Pagado?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbPagado" runat="server" OnClick="return false;" checked='<%# Convert.ToBoolean(Eval("Pagado"))  %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
          
            <asp:BoundField DataField="Total" HeaderText="Pago Total" />

            <asp:CommandField ShowSelectButton="true" SelectText="🔎" HeaderText="Ver Detalles"/>

            
        </Columns>
    </asp:GridView>

    <a class="btn btn-dark" href="../Default" > Volver al Catalogo </a>
             <%

                 } else if((((dominio.Usuario)Session["user"]) != null ) && (((dominio.Usuario)Session["user"]).TipoUsuario.ID == 4))
                 {

                     if (edicion == false)


                     {



%>



 
       <asp:Button ID="btnEdicion" runat="server" Text="Administrar ordenes" OnClick="btnEdicion_Click" />
      
       <asp:Button ID="btnListar" runat="server"  OnClick="btnListar_Click" />
            
   
        <br />
        <br />
    

       <asp:GridView ID="dgvOrdenes" runat="server"  OnSelectedIndexChanged="dgvOrdenes_SelectedIndexChanged" 
        AutoGenerateColumns="false"   DataKeyNames="ID"  class="table table-secondary table-bordered "
        OnPageIndexChanging="dgvOrdenes_PageIndexChanging"
        AllowPaging="True" PageSize="8"
        >

        <Columns>
            
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="User.Nombre" HeaderText="Nombre de Usuario del Cliente" />
            <asp:BoundField DataField="MetPago.Nombre" HeaderText="Metodo de Pago Elegido" />
            <asp:BoundField DataField="Domicilio.Ciudad" NullDisplayText="―"  HeaderText="Ciudad de Residencia" />
            <asp:BoundField DataField="Domicilio.Calle"  NullDisplayText="―" HeaderText="Calle" />
            <asp:BoundField DataField="Domicilio.Numero" NullDisplayText="―" HeaderText="Altura" />
            <asp:BoundField DataField="Domicilio.CodPostal"  NullDisplayText="―" HeaderText="Codigo Postal" />
            
            <asp:TemplateField HeaderText = "Envio">
                <ItemTemplate>
                    <asp:CheckBox ID="chbEnvio" runat="server" OnClick="return false;" Checked='<%# Convert.ToBoolean(Eval("Envio")) %>'  />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText = "Enviado?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbEnviado" runat="server"  OnClick="return false;" Checked='<%# Convert.ToBoolean(Eval("Enviado")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText = "Recibido?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbRecibido" runat="server" OnClick="return false;"  Checked='<%# Convert.ToBoolean(Eval("Recibido")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText = "Pagado?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbPagado" runat="server" OnClick="return false;" checked='<%# Convert.ToBoolean(Eval("Pagado"))  %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
          
            <asp:BoundField DataField="Total" HeaderText="Pago Total" />

            <asp:CommandField ShowSelectButton="true" SelectText="🔎" HeaderText="Ver Detalles"/>

            
        </Columns>
    </asp:GridView>

    <a class="btn btn-dark" href="../Default" > Volver al Inicio de Pagina </a>



        <%  }
            else
            {%>

     <asp:GridView ID="dgvOrdenes2" runat="server"  OnSelectedIndexChanged="dgvOrdenes2_SelectedIndexChanged" 
        AutoGenerateColumns="false"   DataKeyNames="ID"  class="table table-secondary table-bordered "
        OnPageIndexChanging="dgvOrdenes2_PageIndexChanging"
        AllowPaging="True" PageSize="8"
        >

        <Columns>
            
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="User.Nombre" HeaderText="Nombre de Usuario del Cliente" />
            <asp:BoundField DataField="MetPago.Nombre" HeaderText="Metodo de Pago Elegido" />
            <asp:BoundField DataField="Domicilio.Ciudad" NullDisplayText="―"  HeaderText="Ciudad de Residencia" />
            <asp:BoundField DataField="Domicilio.Calle"  NullDisplayText="―" HeaderText="Calle" />
            <asp:BoundField DataField="Domicilio.Numero" NullDisplayText="―" HeaderText="Altura" />
            <asp:BoundField DataField="Domicilio.CodPostal"  NullDisplayText="―" HeaderText="Codigo Postal" />
            
            <asp:TemplateField HeaderText = "Envio">
                <ItemTemplate>
                    <asp:CheckBox ID="chbEnvio" runat="server" OnClick="return false;" Checked='<%# Convert.ToBoolean(Eval("Envio")) %>'  />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField  HeaderText = "Enviado?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbEnviado" runat="server" Checked='<%# Convert.ToBoolean(Eval("Enviado")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField  HeaderText = "Recibido?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbRecibido" runat="server" Checked='<%# Convert.ToBoolean(Eval("Recibido")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText = "Pagado?">
                <ItemTemplate>
                    <asp:CheckBox ID="chbPagado" runat="server" checked='<%# Convert.ToBoolean(Eval("Pagado"))  %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
          
            <asp:BoundField DataField="Total" HeaderText="Pago Total" />

            <asp:CommandField ShowSelectButton="true" SelectText="🔎" HeaderText="Ver Detalles"/>

            <asp:TemplateField HeaderText = "Estado Activo">
                <ItemTemplate>
                    <asp:CheckBox ID="chbEstado" runat="server" checked='<%# Convert.ToBoolean(Eval("EstadoActivo"))  %>'/>
                </ItemTemplate>
            </asp:TemplateField>

            
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnCambios" OnClick="btnCambios_Click" runat="server" Text="Guardar cambios"  />
    <br />
    





        <%       }
            }%>

    
     

</asp:Content>
