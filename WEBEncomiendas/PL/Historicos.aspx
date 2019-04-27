<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historicos.aspx.cs" Inherits="PL.Historicos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="four" class="wrapper style1 special fade-up">
        <div class="container" style="min-height: 600px;">
            <header class="major">
                <h2>Históricos de paqueteria</h2>
            </header>

            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updpnlBusqueda" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-1">
                                    <input type="text" id="txtBuscar" runat="server" maxlength="25" name="txtBuscar" value="" placeholder="Filtrar por detalle" />
                                </div>
                                <div class="col-lg-7">
                                    <asp:Button ID="bntBuscar" runat="server" Text="Buscar paquete" class="submit" OnClick="bntBuscar_Click" />
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
                                <asp:GridView ID="gdvPaquetes" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                                    AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Id_Paquete"
                                    OnPageIndexChanging="gdvPaquetes_PageIndexChanging" PageSize="10">
                                    <PagerStyle ForeColor="White" Font-Size="Large" />
                                    <Columns>
                                        <asp:BoundField DataField="Id_Paquete" HeaderText="ID Paquete" />
                                        <asp:BoundField DataField="DetallePaquete" HeaderText="Detalle" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:BoundField DataField="Id_Recibo" HeaderText="# Recibo" />
                                        <asp:BoundField DataField="Sub_Total" HeaderText="SubTotal" />
                                        <asp:BoundField DataField="Total" HeaderText="Total" />
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </div>


                        <asp:Label Text="" ID="lblMensaje" runat="server" Font-Size="XX-Large" />


                    </ContentTemplate>
                </asp:UpdatePanel>

            </form>


        </div>


    </section>

</asp:Content>
