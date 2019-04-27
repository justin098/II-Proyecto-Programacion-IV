<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Solicitud_Paquete.aspx.cs" Inherits="PL.Solicitud_Paquete" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">


    <link rel="stylesheet" href="Modal/Modal.css" />



</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container" style="min-height: 600px;">
            <header class="major">
                <h2>Crear solicitud de paquete
                </h2>
            </header>

            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updIngreso" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="rechnungsdaten">
                            <div class="form__group">
                                <label for="">Descripción paquete:</label>
                                <input type="text" id="txtDescripcion" maxlength="25" runat="server" />
                            </div>

                            <div class="form__group">
                                <label for="">Tipo Artículo:</label>
                                <asp:DropDownList ID="ddlCategoria" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>



                        <div class="rechnungsdaten">

                            <div class="form__group ort">
                                <asp:CheckBox Text="Recoger a domicilio" ID="chkRecoger" runat="server" Width="250px" />
                                <br />
                                <asp:CheckBox Text="Entrega a domicilio" ID="chkEntrega" OnClick="EntregaDomicilio();" runat="server" Width="245px" />
                            </div>

                            <div class="form__group ort">
                                <label for="">Tipo servicio:</label>
                                <asp:DropDownList ID="ddlServicios" onchange="costoServicio()" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="form__group ort" runat="server" id="divSucursal">
                                <label for="">Sucursal a retirar:</label>
                                <asp:DropDownList ID="ddlSucursales" runat="server">
                                </asp:DropDownList>
                            </div>


                            <div class="form__group ort" runat="server" id="divEntrega">
                                <label for="">Dirección Entrega:</label>
                                <input type="text" runat="server" maxlength="250" id="txtDireccion" />
                            </div>

                        </div>

                        <div>

                            <div>

                                <div class="form__group">
                                    <label for="">Peso aproximado:</label>
                                    <input type="text" id="txtPeso" runat="server" maxlength="7" onkeypress="return ValidarNumero(event)" />
                                </div>

                                <div class="form__group">
                                    <h4>Costo de la solicitud:</h4>
                                    Costo por peso:
                        <input type="text" id="txtCalculo" runat="server" style="height: 35px; border: 0; text-align: center;" readonly="true" />
                                    Costo de envio:
                        <input type="text" id="txtEnvio" runat="server" style="height: 35px; border: 0; text-align: center;" readonly="true" />
                                    Subtotal:
                        <input type="text" id="txtSubtotal" style="height: 35px; border: 0; text-align: center;" runat="server" readonly="true" />
                                    Valor total aproximado:
                        <input type="text" id="txtTotal" runat="server" style="height: 35px; border: 0; text-align: center;" readonly="true" />
                                </div>
                            </div>

                            <div class="rechnungsdaten">
                                <div class="form__group">
                                    <label for="">Cedula cliente:</label>
                                    <input type="text" id="txtCedula" runat="server" />
                                </div>
                                <div class="form__group">
                                    <label for="">Nombre cliente:</label>
                                    <input type="text" id="txtNombreCliente" runat="server" readonly="true" />
                                </div>
                                <div class="form__group">
                                    <asp:Button Text="Buscar cliente" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
                                    <asp:Button Text="Borrar busqueda" ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" />
                                    <input type="text" id="txtCliente" runat="server" style="height: 35px; border: 0; text-align: center;" readonly="true" />
                                </div>
                            </div>

                            <div class="rechnungsdaten" id="divTarjetas" runat="server">
                                <div class="form__group">
                                    <label for="">Tarjeta de pago:</label>
                                    <asp:DropDownList ID="ddlTarjetas" runat="server">
                                    </asp:DropDownList>
                                    <label id="lblTarjetas" runat="server"></label>
                                </div>
                            </div>


                            <asp:UpdatePanel ID="updpnlBusqueda" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <asp:Button Text="Registrar paquete" OnClick="btnRegistrar_Click" ID="btnRegistrar" runat="server" />
                                    <input type="text" id="txtMensaje" runat="server" style="height: 35px; border: 0; text-align: center;" readonly="true" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:UpdatePanel>


            </form>


        </div>


    </section>
    <script src="Modal/ModalJS.js"></script>
    <script src="js/Pedidos/PedidosEmpleadoJS.js"></script>
</asp:Content>
