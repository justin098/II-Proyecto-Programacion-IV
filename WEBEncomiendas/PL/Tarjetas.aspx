<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tarjetas.aspx.cs" Inherits="PL.Tarjetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container" style="min-height: 600px;">
            <header class="major">
                <h2>Tarjetas</h2>
            </header>

            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updpnlBusqueda" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-1">
                                    <input type="text" id="txtBuscar" runat="server" maxlength="25" name="txtBuscar" value="" placeholder="Tarjeta" />
                                </div>
                                <div class="col-lg-7">
                                    <asp:Button ID="bntBuscar" runat="server" Text="Buscar" Width="150px" class="submit" OnClick="bntBuscar_Click" />
                                </div>
                                <div class="col-lg-8">
                                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="150px" class="submit" OnClientClick="return openModal();" OnClick="btnAgregar_Click" />
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
                                <asp:GridView ID="gdvTarjetas" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                                    AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Numero_tarjeta"
                                    OnRowCommand="gdvTarjetas_RowCommand" OnPageIndexChanging="gdvTarjetas_PageIndexChanging" PageSize="5">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditar" CommandName="Editar" OnClientClick="return openModal();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnBorrar" CommandName="Borrar" OnClientClick="return eliminarTarjeta();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Borrar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Numero_tarjeta" HeaderText="Número de Tarjeta" />
                                        <asp:BoundField DataField="Fecha_Vencimiento" HeaderText="Fecha de Vencimiento" dataformatstring="{0:yyyy-MM-dd}"/>
                                        <asp:BoundField DataField="Codigo_Seguridad" HeaderText="Código de Seguridad" />
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
                            <asp:UpdatePanel ID="updpnlModalHeader" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <h2 id="lblHeader" runat="server"></h2>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server" ID="updpnlModal" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="table-responsive">
                                        <div class="col-lg-1">
                                            <asp:Label Text="* Número de tarjeta:" ID="lblNumeroTarjeta" runat="server" />

                                            <input type="text" id="txtNumeroTarjeta" name="txtNumeroTarjeta" runat="server" style="height: 40px;" maxlength="16" placeholder="Número de tarjeta" />
                                        </div>
                                        <br />
                                        <div class="col-lg-1">
                                            <asp:Label Text="* Fecha de vencimiento:" ID="lblFechaVencimiento" runat="server" Style="float: left;" />

                                            <input type="date" name="dttFechaVencimiento" id="dttFechaVencimiento" runat="server" style="color: black; font-weight: bold; height: 40px;" />
                                        </div>
                                        <br />
                                        <div class="col-lg-1">
                                            <asp:Label Text="* Codigo de seguridad:" ID="lblCodigoSeguridad" runat="server" />

                                            <input type="text" id="txtCodigoSeguridad" name="txtCodigoSeguridad" runat="server" placeholder="Codigo de seguridad" style="height: 40px;" maxlength="3" value="" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnGuardar" OnClientClick="return GuardarModal();" OnClick="btnGuardar_Click" runat="server" Text="Guardar" Width="150px" class="submit" />
                            <asp:Button ID="btnCancelar" OnClientClick="return closeModal();" runat="server" Text="Cancelar" Width="150px" class="submit" />
                        </div>
                    </div>
                </div>

            </form>
        </div>


    </section>
    <script src="js/Tarjetas/TarjetasJS.js"></script>
    <script src="Modal/ModalJS.js"></script>
</asp:Content>
