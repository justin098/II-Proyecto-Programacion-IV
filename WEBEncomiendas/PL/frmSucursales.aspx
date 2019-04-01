<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSucursales.aspx.cs" Inherits="PL.frmSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sucursales</title>

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
                        <label for="destination">Sucursales</label>
                        <input type="text" id="txtBuscar" runat="server" maxlength="25" name="txtBuscar" placeholder="Nombre sucursal" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="bntBuscar" runat="server" Text="Buscar" Width="150px" class="submit" OnClick="bntBuscar_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="table-responsive">
                        <asp:GridView ID="gdvSucursales" Width="750px" CssClass="mGridPane" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                            RowStyle-Width="30px" AllowPaging="true" OnPageIndexChanging="gdvSucursales_PageIndexChanging" PageSize="5" RowStyle-Height="40px">
                            <FooterStyle ForeColor="Gray" BackColor="Gray" />
                            <AlternatingRowStyle CssClass="mAltRowPane" />
                            <RowStyle CssClass="mRowPane" />

                            <Columns>
                                <asp:BoundField DataField="Id_Sucursal" HeaderText="ID Sucursal" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                                <asp:BoundField DataField="Canton" HeaderText="Cantón" />
                                <asp:BoundField DataField="Distrito" HeaderText="Distrito" />
                                <asp:BoundField DataField="Direccion_Exacta" HeaderText="Dirección Exacta" />
                            </Columns>

                        </asp:GridView>
                    </div>

                </div>
                <asp:Label Text="text" ID="lblPureb" runat="server" />
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
