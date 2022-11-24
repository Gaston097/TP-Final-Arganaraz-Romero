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
                                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modal<%#Eval("Id")%>">
                                    Agregar a Carrito
                                    <i class="fa trash-can" aria-hidden="true"></i>
                                </button>   
                                
                                <% if (((dominio.Usuario)Session["user"]) == null) {
                                %>
                                <div class="modal fade"  id="modal<%#Eval("Id")%>" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                    
                                            <div class="modal-body" style="color:red">
                                                Debe ingresar al sistema para poder agregar items a su carrito
                                                <i class="fa fa-check-cross" aria-hidden="true"></i>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%
                                }
                                else
                                {
                                %>  
                                <div class="modal fade" data-keyboard="false" id="modal<%#Eval("Id")%>" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                    
                                            <div class="modal-body" style="color:green">
                                                Articulo agregado con exito
                                                <i class="fa fa-check-circle" aria-hidden="true"></i>
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Continuar aqui" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnAgregarCarrito_Click"/>
                                                <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Ir a Carrito" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnAgregarCarritoRedirect_Click"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                        <%
                                            }
                                        %>




                        
                                        
                            </div>                                                         
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>

        </div>

</asp:Content>
