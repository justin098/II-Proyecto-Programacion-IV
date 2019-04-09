<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPersonas.aspx.cs" Inherits="PL.EditarPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>

    </script>

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container">
            <header class="major">
                <h2>Editar Persona</h2>
            </header>

            <form runat="server">
                <input type="text" id="txtCedula" name="txtCedula" runat="server" placeholder="Cedula" maxlength="15" required="required" />
                <br />
                <input type="text" id="txtNombre" name="txtNombre" runat="server" placeholder="Nombre" maxlength="25" required="required"/>
                <br />
                <input type="text" id="txtPrimerApellido" name="txtPrimerApellido" runat="server" placeholder="Primer Apellido" maxlength="25" required="required"/>
                <br />
                <input type="text" id="txtSegundoApellido" name="txtSegundoApellido" runat="server" placeholder="Segundo Apellido" maxlength="25" required="required"/>
                <br />
                <input type="text" id="txtEmail" name="txtEmail" runat="server" placeholder="Email" maxlength="35" required="required"/>
                <br />
                <input type="text" id="txtTelefono1" name="txtTelefono1" runat="server" placeholder="Teléfono" maxlength="14" required="required"/>
                <br />
                <input type="text" id="txtTelefono2" name="txtTelefono2" runat="server" placeholder="Teléfono 2" maxlength="14"/>
                <br />
                <input type="text" id="txtUsuario" name="txtUsuario" runat="server" placeholder="Usuario" maxlength="15" required="required"/>
                <br />
                <input type="text" id="txtContrasenia" name="txtContrasenia" runat="server" placeholder="Contraseña" maxlength="12" required="required"/>
                <br />
                <div class="align-left">
                    <asp:CheckBox ID="chkSuperUsuario" runat="server" Text="Super Usuario" />
                </div>
                <br />
                <div class="align-left">
                    <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
                </div>
                <br />
                <div class="form-group">
                    <select class="form-control" id="cmbProvincia" name="cmbProvincia" runat="server">
                        <option>San José</option>
                        <option>Alajuela</option>
                        <option>Cartago</option>
                        <option>Heredia</option>
                        <option>Puntarenas</option>
                        <option>Limón</option>
                        <option>Guanacaste</option>
                    </select>
                </div>
                <br />
                <input type="text" id="txtCanton" name="txtCanton" runat="server" placeholder="Cantón" maxlength="10" required="required"/>
                <br />
                <input type="text" id="txtDistrito" name="txtDistrito" runat="server" placeholder="Distrito" maxlength="10" required="required"/>
                <br />
                <input type="text" id="txtDireccionExacta" name="txtDireccionExacta" runat="server" placeholder="Dirección Exacta" maxlength="250" required="required"/>
                <br />
                <div class="form-group">
                    <div class="row">
                        <div class="col-lg-7">
                            <input type="submit" id="btnAceptar" runat="server" value="Aceptar" onserverclick="bntAceptar_Click"/>
                        </div>
                        <div class="col-lg-8">
                            <input type="button" id="btnCancelar" runat="server" value="Cancelar" onserverclick="btnCancelar_Click"/>
                        </div>
                    </div>
                </div>
                <br />
                <asp:Label Text="" ID="lblMensaje" runat="server" Font-Size="XX-Large" />
            </form>
        </div>
    </section>

</asp:Content>
