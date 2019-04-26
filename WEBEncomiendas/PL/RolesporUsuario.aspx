<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolesporUsuario.aspx.cs" Inherits="PL.RolesporUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container" style="min-height: 600px;">
            <header class="major">
                <h2>Roles por Usuario</h2>
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
                                                <asp:Button ID="btnRoles" CommandName="Roles" OnClientClick="return openModal();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Roles" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
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

                                            <input type="text" id="txtCedula" name="txtCedula" runat="server" style="height: 40px;" maxlength="15" placeholder="Cedula" readonly="true" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Usuario:" ID="lblUsuario" runat="server" />

                                            <input type="text" id="txtUsuario" name="txtUsuario" runat="server" placeholder="Usuario" maxlength="15" style="height: 40px;" value="" readonly="true" />
                                        </div>
                                        
                                        <br>

                                        <div class="col-lg-1">
                                            <asp:Label Text="Roles" ID="lblRoles" runat="server" />

                                            <br>

                                            <div class="form-group">
                                                <div class="table-responsive" style="overflow-x: auto;">
                                                    <asp:GridView ID="gdvRoles" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                                                        AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Id_Rol_Persona"
                                                        OnRowCommand="gdvRoles_RowCommand" OnPageIndexChanging="gdvRoles_PageIndexChanging" PageSize="3">
                                                        <PagerStyle ForeColor="White" Font-Size="Large" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-ForeColor="Black">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnBorrarRol" CommandName="Borrar" OnClientClick="return eliminarRol();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Borrar" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id_Rol_Persona" HeaderText="Identificador" />
                                                            <asp:BoundField DataField="Rol" HeaderText="Rol" />
                                                        </Columns>

                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-1">
                                            <asp:DropDownList ID="cmbRoles" runat="server"></asp:DropDownList>
                                            <br>
                                            <asp:Button ID="btnAgregarRol" runat="server" Text="Agregar Rol" OnClick="btnAgregarRol_Click" class="submit" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAceptar" OnClientClick="return closeModal();" runat="server" Text="Aceptar" Width="150px" class="submit" />
                        </div>
                    </div>
                </div>

            </form>
        </div>


    </section>
    <script src="js/Roles/RolesJS.js"></script>
    <script src="Modal/ModalJS.js"></script>
</asp:Content>
