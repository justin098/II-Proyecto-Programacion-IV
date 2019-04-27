<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cambiar_Estado.aspx.cs" Inherits="PL.Cambiar_Estado" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="four" class="wrapper style1 special fade-up">
        <div class="container">
            <header class="major">
                <h2>Cambiar estado del paquete</h2>
            </header>

            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updpnlBusqueda" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-1">
                                    <input type="text" id="txtBuscar" runat="server" maxlength="25" onkeypress="return ValidarNumero(event)" name="txtBuscar" value="" placeholder="Filtrar por ID paquete" />
                                </div>
                                <div class="col-lg-7">
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar paquete" class="submit" OnClick="btnBuscar_Click" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />

                <asp:UpdatePanel ID="updpnlGrid" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="table-responsive" style="overflow-x: auto;">
                                <asp:GridView ID="gdvEstados" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                                    AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Id_Paquete"
                                    OnRowCommand="gdvEstados_RowCommand" OnPageIndexChanging="gdvEstados_PageIndexChanging" PageSize="10">
                                    <PagerStyle ForeColor="White" Font-Size="Large" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEstado" CommandName="CambiarEstado" OnClientClick="return openModal();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Cambiar estado" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id_Paquete" HeaderText="ID Paquete" />
                                        <asp:BoundField DataField="DetallePaquete" HeaderText="Detalle" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:BoundField DataField="Peso" HeaderText="Peso" />
                                        <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" />
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </div>


                        <asp:Label Text="" ID="lblMensaje" runat="server" Font-Size="XX-Large" />


                    </ContentTemplate>
                </asp:UpdatePanel>

                <div id="my-modal" class="modal">
                    <div class="modal-content">
                        <div class="modal-header">
                            <span class="close">&times;</span>
                            <asp:UpdatePanel ID="updpnlModalHeader" UpdateMode="Always" runat="server">
                                <ContentTemplate>
                                    <h2 id="lblHeader" runat="server">Cambiar estado</h2>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server" ID="updpnlModal" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="table-responsive">
                                        <div class="col-lg-1">
                                            <asp:Label Text="ID Paquete:" ID="lblIdSucursal" runat="server" />

                                            <input type="text" id="txtIdPaquete" style="height: 40px;" readonly="true" runat="server" name="txtIdPaquete" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Estado:" ID="lblEstado" runat="server" />
                                            <asp:DropDownList ID="cmbEstados" Style="height: 40px;" runat="server" AutoPostBack="true" ></asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                            <asp:UpdatePanel runat="server" ID="upodBTN" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:Button ID="btnGuardar" OnClientClick="return GuardarModal();" OnClick="btnGuardar_Click" runat="server" Text="Guardar" Width="150px" class="submit" />
                                    <asp:Button ID="btnCancelar" OnClientClick="return closeModal();" runat="server" Text="Cancelar" Width="150px" class="submit" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </form>
        </div>
        <%--        TRABAJAR ACA DENTRO--%>
    </section>
    <script src="js/Estado/EstadosJS.js"></script>
</asp:Content>
