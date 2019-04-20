<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sucursales.aspx.cs" Inherits="PL.Sucursales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>

</script>

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container">
            <header class="major">
                <h2>Sucursales a nivel nacional</h2>
            </header>
        </div>

        <asp:Label ID="lblRtpMensaje" Text="" runat="server" />



        <div class="box alt">
            <div class="row gtr-uniform">
                <asp:Repeater ID="rptSucursales" runat="server">
                    <ItemTemplate>
                        <section class="col-4 col-6-medium col-12-xsmall">
                            <h3>
                                <asp:Label ID="lblNombreSucursal" Text='<%#Eval("Nombre") %>' runat="server" /></h3>

                            <p>
                                Ubicación:
                                    <asp:Label ID="lblProvincia" Text='<%#Eval("Provincia") %>' runat="server" />, 
                                <asp:Label ID="lblCanton" Text='<%#Eval("Canton") %>' runat="server" />,
                                <asp:Label ID="lblDistrito" Text='<%#Eval("Distrito") %>' runat="server" />
                                <br />
                                Dirección Exacta:
                                <asp:Label ID="lblDirExacta" Text='<%#Eval("Direccion_Exacta") %>' runat="server" />
                                <br />
                                Hora apertura:
                                <asp:Label ID="lblApertura" Text='<%#Eval("Hora_Apertura") %>' runat="server" />&nbsp;Hora cierre:
                                <asp:Label ID="lblCierre" Text='<%#Eval("Hora_Cierre") %>' runat="server" /></h3>
                            </p>
                        </section>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>



    </section>

</asp:Content>
