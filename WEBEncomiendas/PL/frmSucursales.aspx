<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSucursales.aspx.cs" Inherits="PL.frmSucursales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
    </script>



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
    <asp:Label Text="" ID="lblMensaje" runat="server" />


</asp:Content>
