<%@ Page Title="Orden de Pago" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenPago.aspx.cs" Inherits="Ecommerce.OrdenPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script language="javascript" type="text/javascript">
        function SelectSingleRadiobutton(rdbtnid) {
            var rdBtn = document.getElementById(rdbtnid);
            var rdBtnList = document.getElementsByTagName("input");
            for (i = 0; i < rdBtnList.length; i++) {
                if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                    rdBtnList[i].checked = false;
                }
            }
        }
    </script>



    <br />
    <h1> Finalizar Orden de Pago </h1>

    
    <div> ¿De que manera desea receptar la compra? </div>
    <br />
    <br />
  
    <div class="accordion accordion-flush" id="accordionFlushExample">
        <div class="accordion-item">
            <h2 class="accordion-header" id="flush-headingOne">
                <button class="accordion-button bg-secondary text-white collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne">
                Retirar a traves de envio
                </button>
            </h2>
            <div id="flush-collapseOne" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                <div class="accordion-body">
                    <%--
                        Agregar funcion en HTML para verificar que tenga un domicilio  
                    --%>
                    
                    <%if (validarDireccion)
         
                        {   %>
                                
                       


                            <h2> Por favor seleccione una direccion a la cual se realizara el envio </h2>

                           <div>
                                <asp:GridView ID="dgvDomiciliosUsuario" runat="server"
                                    AutoGenerateColumns="false"   DataKeyNames="Id"  class="table table-secondary table-bordered "
                                    >

                        
                                        <Columns>
            
                                            <asp:BoundField DataField="Id" HeaderText="ID" />
                                            <asp:BoundField DataField="Calle" HeaderText="Calle" />
                                            <asp:BoundField DataField="Numero" HeaderText="Altura" />
                                            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                                            <asp:BoundField DataField="CodPostal" HeaderText="Codigo Postal" />
                             
                                            
                                            <asp:TemplateField HeaderText="Selecccionar">
                                                <ItemTemplate>
                                                    <asp:RadioButton ID="rbtSeleccionar" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)"/></ItemTemplate>
                                            </asp:TemplateField>

                           
                                        </Columns>



                                </asp:GridView>
                            </div>


                             <div class="mb-3">
                                    <label for="ddlMetodoPago" class="form-label">Metodo de Pago</label>
                                    <br />
                                    <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="form-control border btn dropdown-toggle">
                                    </asp:DropDownList>
                             </div>
                    <asp:Button ID="btnConfirmar"  OnClick="btnConfirmar_Click"  runat="server"  CssClass="btn btn-success" Text="Confirmar Pedido" />

                    
                    <% }
                 else
                      { %>
                    
                    Este usuario no tiene ningun domicilio registrado a su nombre. Por favor, ingrese un
                    domicilio previo a registrar una orden de compra
                    <br />
                    <br />
                    <a type="button" class="btn btn-secondary" href="ABMs/ABMDomicilio">Ingresar un domicilio</a>

                <%   }%>

   
            

                   









                </div>
            </div>
        </div>
            <div class="accordion-item">
                <h2 class="accordion-header" id="flush-headingTwo">
                    <button class="accordion-button bg-secondary text-white collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseTwo" aria-expanded="false" aria-controls="flush-collapseTwo">
                    Retirar por local
                    </button>
                </h2>
                <div id="flush-collapseTwo" class="accordion-collapse collapse" aria-labelledby="flush-headingTwo" data-bs-parent="#accordionFlushExample">
                    <div class="accordion-body">
                        
                        <div class="mb-3">
                                    <label for="ddlMetodoPago2" class="form-label">Metodo de Pago</label>
                                    <br />
                                    <asp:DropDownList ID="ddlMetodoPago2" runat="server" CssClass="form-control border btn dropdown-toggle">
                                    </asp:DropDownList>
                        </div>

                        <asp:Button ID="btnConfirmar2" CssClass="btn btn-success" OnClick="btnConfirmar2_Click" runat="server" Text="Confirmar Pedido" />

                    </div>
                </div>
            </div>
            
    </div>
        


</asp:Content>
