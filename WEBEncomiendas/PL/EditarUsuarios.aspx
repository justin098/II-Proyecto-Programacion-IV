<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuarios.aspx.cs" Inherits="PL.EditarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container" style="min-height: 600px;">
            <header class="major">
                <h2>Usuarios</h2>
            </header>

            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updpnlBusqueda" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-1">
                                    <input type="text" id="txtBuscar" runat="server" maxlength="25" name="txtBuscar" value="" placeholder="Nombre usuario" />
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
                                <asp:GridView ID="gdvUsuarios" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                                    AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Cedula"
                                    OnRowCommand="gdvUsuarios_RowCommand" OnPageIndexChanging="gdvUsuarios_PageIndexChanging" PageSize="5">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditar" CommandName="Editar" OnClientClick="return openModal();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnBorrar" CommandName="Borrar" OnClientClick="return eliminarUsuario();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Borrar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Primer_Apellido" HeaderText="Primer Apellido" />
                                        <asp:BoundField DataField="Segundo_Apellido" HeaderText="Segundo Apellido" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="Telefono1" HeaderText="Telefono1" />
                                        <asp:BoundField DataField="Telefono2" HeaderText="Telefono2" />
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                        <asp:BoundField DataField="Super_Usuario" HeaderText="Super Usuario" />
                                        <asp:BoundField DataField="Activo" HeaderText="Activo" />
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
                                            <asp:Label Text="Cedula:" ID="lblCedula" runat="server" />

                                            <input type="text" id="txtCedula" name="txtCedula" runat="server" style="height: 40px;" maxlength="15" placeholder="Cedula" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Nombre:" ID="lblNombre" runat="server" />

                                            <input type="text" id="txtNombre" name="txtNombre" runat="server" placeholder="Nombre" style="height: 40px;" maxlength="25" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Primer Apellido:" ID="lblPrimerApellido" runat="server" />

                                            <input type="text" id="txtPrimerApellido" name="txtPrimerApellido" runat="server" placeholder="Primer Apellido" style="height: 40px;" maxlength="25" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Segundo Apellido:" ID="lblSegundoApellido" runat="server" />

                                            <input type="text" id="txtSegundoApellido" name="txtSegundoApellido" runat="server" placeholder="Segundo Apellido" style="height: 40px;" maxlength="25" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Email:" ID="lblEmail" runat="server" />

                                            <input type="text" id="txtEmail" name="txtEmail" runat="server" placeholder="Email" style="height: 40px;" maxlength="35" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Telefono 1:" ID="lblTelefono1" runat="server" />

                                            <input type="text" id="txtTelefono1" name="txtTelefono1" runat="server" placeholder="Teléfono" style="height: 40px;" maxlength="14" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Telefono 2:" ID="lblTelefono2" runat="server" />

                                            <input type="text" id="txtTelefono2" name="txtTelefono2" runat="server" placeholder="Teléfono 2" style="height: 40px;" maxlength="14" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Usuario:" ID="lblUsuario" runat="server" />

                                            <input type="text" id="txtUsuario" name="txtUsuario" runat="server" placeholder="Usuario" maxlength="15" style="height: 40px;" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Contraseña:" ID="lblContrasenia" runat="server" />

                                            <input type="text" id="txtContrasenia" name="txtContrasenia" runat="server" placeholder="Contraseña" style="height: 40px;" maxlength="12" value="" />
                                        </div>
                                        <br />
                                        <div class="align-left">
                                            <asp:CheckBox ID="chkSuperUsuario" runat="server" Text="Super Usuario" />
                                        </div>
                                        <div class="align-left">
                                            <asp:CheckBox ID="chkActivo" runat="server" Style="height: 40px;" Text="Activo" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Provincia:" ID="lblProvincia" runat="server" />
                                            <select class="form-control" id="cmbProvincias" style="height: 40px;" name="cmbProvincia" runat="server">
                                                <option>San José</option>
                                                <option>Alajuela</option>
                                                <option>Cartago</option>
                                                <option>Heredia</option>
                                                <option>Puntarenas</option>
                                                <option>Limón</option>
                                                <option>Guanacaste</option>
                                            </select>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Cantón" ID="lblCanton" runat="server" />

                                            <input type="text" id="txtCanton" runat="server" maxlength="20" style="height: 40px;" name="txtCanton" value="" placeholder="Cantón" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Distrito:" ID="lblDistrito" maxlength="20" runat="server" />

                                            <input type="text" id="txtDistrito" runat="server" maxlength="20" style="height: 40px;" name="txtDistrito" value="" placeholder="Distrito" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Dirección exacta:" ID="lblDireccion" runat="server" />

                                            <input type="text" id="txtDireccion" runat="server" maxlength="250" style="height: 40px;" name="txtDireccion" value="" placeholder="Dirección Exacta"/>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnGuardar" OnClientClick="return closeModal();" OnClick="btnGuardar_Click" runat="server" Text="Guardar" Width="150px" class="submit" />
                            <asp:Button ID="btnCancelar" OnClientClick="return closeModal();" runat="server" Text="Cancelar" Width="150px" class="submit" />
                        </div>
                    </div>
                </div>

            </form>
        </div>


    </section>
    <script src="Modal/ModalJS.js"></script>
</asp:Content>
