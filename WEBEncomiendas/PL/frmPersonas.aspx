<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPersonas.aspx.cs" Inherits="PL.frmPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
    </script>


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

</asp:Content>
