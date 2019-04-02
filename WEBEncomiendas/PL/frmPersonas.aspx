<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPersonas.aspx.cs" Inherits="PL.frmPersonas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Personas</title>

    <!-- Font Icon -->
    <link rel="stylesheet" href="Estilos/Sucursales/fonts/material-icon/css/material-design-iconic-font.min.css" />
    <link rel="stylesheet" href="Estilos/Sucursales/vendor/jquery-ui/jquery-ui.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- Main css -->
    <link rel="stylesheet" href="Estilos/Sucursales/css/style.css" />
</head>
<body>
    <div class="main">

        <div class="header">
        </div>
        <div class="container">
            <form id="form1" runat="server" class="booking-form">
                <div class="form-group">
                    <div class="form-destination">
                        <label for="destination">Personas</label>
                        <input type="text" id="txtBuscar" runat="server" maxlength="25" name="txtBuscar" placeholder="Nombre persona" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="bntBuscar" runat="server" Text="Buscar" Width="150px" class="submit" OnClick="bntBuscar_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="table-responsive">
                        <asp:GridView ID="gdvPersonas" Width="750px" CssClass="mGridPane" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                            RowStyle-Width="30px" AllowPaging="true" OnPageIndexChanging="gdvPersonas_PageIndexChanging" PageSize="5" RowStyle-Height="40px">
                            <FooterStyle ForeColor="Gray" BackColor="Gray" />
                            <AlternatingRowStyle CssClass="mAltRowPane" />
                            <RowStyle CssClass="mRowPane" />

                            <Columns>
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
                <asp:Label Text="" ID="lblMensaje" runat="server" />
            </form>
        </div>

    </div>
    <script src="Estilos/Sucursales/vendor/jquery/jquery.min.js"></script>
    <script src="Estilos/Sucursales/vendor/jquery-ui/jquery-ui.min.js"></script>
    <script src="Estilos/Sucursales/js/main.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</body>
</html>
