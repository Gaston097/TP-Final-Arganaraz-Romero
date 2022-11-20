<%@ Page Title="ABMArticulos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMArticulos.aspx.cs" Inherits="Ecommerce.ABMs.ABMArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <br />
    <h1><%: Title %> </h1>


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

    <div style="width:50%">
        <asp:GridView ID="dgvArticulos" runat="server"  OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" 
            AutoGenerateColumns="false"   DataKeyNames="Id"  class="table table-dark table-bordered "
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

                <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar"/>
                <asp:CommandField ShowSelectButton="true" SelectText="🛠️" HeaderText="Modificar"/>
                           
            </Columns>
        </asp:GridView>
    </div>
        
    </ContentTemplate>
    </asp:UpdatePanel>

    
     <a class="btn btn-dark" href="FormularioArticulo" > Agregar </a>
     <a class="btn btn-dark" href="../ABMMain" > Volver al Menu de ABMs </a>
     




</asp:Content>
