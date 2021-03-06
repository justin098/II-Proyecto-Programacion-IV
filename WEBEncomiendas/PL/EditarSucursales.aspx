﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="EditarSucursales.aspx.cs" Inherits="PL.MantSucursales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container" style="min-height: 600px;">
            <header class="major">
                <h2>Sucursales</h2>
            </header>

            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updpnlBusqueda" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-1">
                                    <input type="text" id="txtBuscar" runat="server" maxlength="25" name="txtBuscar" value="" placeholder="Filtrar por nombre" />
                                </div>
                                <div class="col-lg-7">
                                    <asp:Button ID="bntBuscar" runat="server" Text="Buscar sucursal" class="submit" OnClick="bntBuscar_Click" />
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
                                <asp:GridView ID="gdvSucursal" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                                    AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Id_Sucursal"
                                    OnRowCommand="gdvSucursal_RowCommand" OnPageIndexChanging="gdvSucursales_PageIndexChanging" PageSize="10">
                                    <PagerStyle ForeColor="White" Font-Size="Large" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditar" CommandName="Editar" OnClientClick="return openModal();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <asp:Button ID="btnBorrar" CommandName="Borrar" OnClientClick="return eliminarSucursal();" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" Text="Borrar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id_Sucursal" HeaderText="ID Sucursal" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Dia_Apertura" HeaderText="Día apertura" />
                                        <asp:BoundField DataField="Dia_Cierre" HeaderText="Día cierre" />
                                        <asp:BoundField DataField="Hora_Apertura" HeaderText="Hora apertura" />
                                        <asp:BoundField DataField="Hora_Cierre" HeaderText="Hora cierre" />
                                        <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                                        <asp:BoundField DataField="Canton" HeaderText="Cantón" />
                                        <asp:BoundField DataField="Distrito" HeaderText="Distrito" />
                                        <asp:BoundField DataField="Direccion_Exacta" HeaderText="Dirección Exacta" />
                                        <asp:CheckBoxField DataField="Activo" Text=" " HeaderText="Estado" />
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
                                            <asp:Label Text="ID de sucursal:" ID="lblIdSucursal" runat="server" />

                                            <input type="text" id="txtIdSucursal" style="height: 40px;" readonly="true" runat="server" name="txtIdSucursal" value="" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Nombre de sucursal:" ID="lblNombreSucursal" runat="server" />

                                            <input type="text" id="txtNombreSucursal" style="height: 40px;" maxlength="25" runat="server" name="txtNombreSucursal" value="" placeholder="Nombre sucursal" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Provincia:" ID="lblProvincia" runat="server" />
                                            <asp:DropDownList ID="cmbProvincias" Style="height: 40px;" runat="server" OnSelectedIndexChanged="cmbProvincias_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Cantón" ID="lblCanton" runat="server" />
                                            <asp:DropDownList ID="cmbCantones" runat="server" Style="height: 40px;" OnSelectedIndexChanged="cmbCantones_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Distrito:" ID="lblDistrito" maxlength="20" runat="server" />
                                            <asp:DropDownList ID="cmbDistritos" runat="server" Style="height: 40px;"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Label Text="Dirección exacta:" ID="lblDireccion" runat="server" />

                                            <input type="text" id="txtDireccion" runat="server" maxlength="250" style="height: 40px;" name="txtDireccion" value="" placeholder="Dirección Exacta" />
                                        </div>
                                        <br />
                                        <div class="align-left">
                                            <asp:Label Text="Hora y día apertura:" ID="lblApertura" runat="server" Style="float: left;" />
                                            <input type="time" name="hora" id="tmApertura" runat="server" value="00:00" max="23:59" min="00:00" style="color: black; font-weight: bold; height: 40px;" />
                                            <br />
                                            <asp:DropDownList ID="cmbDiaApertura" runat="server" Style="height: 40px;">
                                                <asp:ListItem Value="1" Text="Lunes" />
                                                <asp:ListItem Value="2" Text="Martes" />
                                                <asp:ListItem Value="3" Text="Miércoles" />
                                                <asp:ListItem Value="4" Text="Jueves" />
                                                <asp:ListItem Value="5" Text="Viernes" />
                                                <asp:ListItem Value="6" Text="Sábado" />
                                                <asp:ListItem Value="7" Text="Domingo" />
                                            </asp:DropDownList>
                                        </div>
                                        <br />
                                        <div class="align-left">
                                            <asp:Label Text="Hora y día cierre:" ID="lblCierre" runat="server" Style="float: left;" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="time" name="hora" id="tmCierre" runat="server" max="23:59" value="00:00" min="00:00" style="color: black; font-weight: bold; height: 40px;" />
                                            <br />
                                            <asp:DropDownList ID="cmbDiaCierre" runat="server" Style="height: 40px;">
                                                <asp:ListItem Value="1" Text="Lunes" />
                                                <asp:ListItem Value="2" Text="Martes" />
                                                <asp:ListItem Value="3" Text="Miércoles" />
                                                <asp:ListItem Value="4" Text="Jueves" />
                                                <asp:ListItem Value="5" Text="Viernes" />
                                                <asp:ListItem Value="6" Text="Sábado" />
                                                <asp:ListItem Value="7" Text="Domingo" />
                                            </asp:DropDownList>
                                        </div>
                                        <div class="align-left">
                                            <br />
                                            <asp:CheckBox ID="chkActivo" runat="server" Style="height: 40px;" Text="Activo" />
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
    <script src="js/Sucursales/SucursalesJS.js"></script>
    <script src="Modal/ModalJS.js"></script>
</asp:Content>
