<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarRoles.aspx.cs" Inherits="PL.EditarRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container" style="min-height: 600px;">
            <header class="major">
                <h2>Roles</h2>
            </header>

            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updpnlBusqueda" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-1">
                                    <input type="text" id="txtBuscar" runat="server" maxlength="25" name="txtBuscar" value="" placeholder="Filtrar por rol" />
                                </div>
                                <div class="col-lg-7">
                                    <asp:Button ID="bntBuscar" runat="server" Text="Buscar rol" class="submit" OnClick="bntBuscar_Click" />
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
                                <asp:GridView ID="gdvRoles" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                                    AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Id_Rol"
                                    OnRowCommand="gdvRoles_RowCommand" OnPageIndexChanging="gdvRoles_PageIndexChanging" PageSize="5">
                                    <PagerStyle ForeColor="White" Font-Size="Large" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditar" CommandName="Editar" OnClientClick="return openModal();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnBorrar" CommandName="Borrar" OnClientClick="return eliminarRol();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Borrar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id_Rol" HeaderText="Id Rol" />
                                        <asp:BoundField DataField="Rol" HeaderText="Rol" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
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
                                            <asp:Label Text="ID de rol:" ID="lblIdRol" runat="server" />

                                            <input type="text" id="txtIdRol" style="height: 40px;" readonly="true" runat="server" name="txtIdRol" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Rol:" ID="lblRol" runat="server" />

                                            <input type="text" id="txtRol" style="height: 40px;" maxlength="20" runat="server" name="txtRol" value="" placeholder="Rol" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Descripción:" ID="lbldescripcion" runat="server" />

                                            <input type="text" id="txtDescripcion" runat="server" maxlength="50" style="height: 40px;" name="txtDescripcion" value="" placeholder="Descripción" />
                                        </div>

                                        <br>

                                        <div class="col-lg-1">
                                            <asp:Label Text="Privilegios" ID="lblPrivilegios" runat="server" />

                                            <br>

                                            <div class="form-group">
                                                <div class="table-responsive" style="overflow-x: auto;">
                                                    <asp:GridView ID="gdvPrivilegios" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                                                        AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Id_Privilegio_Rol"
                                                        OnRowCommand="gdvPrivilegios_RowCommand" OnPageIndexChanging="gdvPrivilegios_PageIndexChanging" PageSize="3">
                                                        <PagerStyle ForeColor="White" Font-Size="Large" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-ForeColor="Black">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnBorrarPrivilegio" CommandName="Borrar" OnClientClick="return eliminarPrivilegio();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Borrar" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id_Privilegio_Rol" HeaderText="Identificador" />
                                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                                        </Columns>

                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-1">
                                            <asp:DropDownList ID="cmbPrivilegios" runat="server"></asp:DropDownList>
                                            <br>
                                            <asp:Button ID="btnAgregarPrivilegio" runat="server" Text="Agregar Privilegio" OnClick="btnAgregarPrivilegio_Click" class="submit" />
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


    </section>
    <script src="js/Roles/RolesJS.js"></script>
    <script src="Modal/ModalJS.js"></script>
</asp:Content>
