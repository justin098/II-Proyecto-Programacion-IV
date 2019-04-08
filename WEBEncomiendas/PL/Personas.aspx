<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="PL.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>

    </script>

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container">
            <header class="major">
                <h2>Personas</h2>
            </header>

            <form runat="server">

                <div class="form-group">
                    <div class="row">
                        <div class="col-lg-1">
                            <input type="text" id="txtBuscar" runat="server" name="txtBuscar" placeholder="Nombre persona" />
                        </div>
                        <div class="col-lg-7">
                            <asp:Button ID="bntBuscar" runat="server" Text="Buscar" Width="150px" class="submit" OnClick="bntBuscar_Click" />
                        </div>
                        <div class="col-lg-8">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="150px" class="submit" OnClick="btnAgregar_Click"/>
                        </div>
                    </div>
                </div>

                <br />

                <div class="form-group">
                    <div class="table-responsive">
                        <asp:GridView ID="gdvPersonas" HorizontalAlign="Center" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                            AllowPaging="true" Height="100%" Width="100%" DataKeyNames="Cedula" OnRowDeleting="gdvPersonas_RowDeleting"
                            OnRowEditing="gdvPersonas_RowEditing" OnPageIndexChanging="gdvPersonas_PageIndexChanging" PageSize="5" >
                            <Columns>
                                <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True" ControlStyle-ForeColor="0xE04343" />
                                <asp:CommandField EditText ="Editar" ShowEditButton="True" ControlStyle-ForeColor="0x6ED11C" />
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
            </form>


        </div>

    </section>

</asp:Content>
