<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        
    
    <br />
    <h1 class="title"> Catalogo de Articulos</h1>
    <hr />
      <div class="row row-cols-1 row-cols-md-4 g-4">
        <asp:Repeater ID="Repeter" runat="server">
            <ItemTemplate>
                <div class="col p-3">
                        <div class="card pb-1" style="height:100%;" > 
                            <img src="<%#Eval("Imagen")%>" alt="Articulo" class="card-img-top p-3" style="object-fit:contain; max-height:250px; max-width:250px; " />
                            <div class="card-body">
                                <h4 class="card-title"><%#Eval("Nombre")%></h4>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <p class="card-text"> $<%#Eval("Precio")%></p>
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modal<%#Eval("Id")%>">
                                  Agregar a Carrito
                                </button>                                         
                            </div>                                                         
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>

        </div>

</asp:Content>
