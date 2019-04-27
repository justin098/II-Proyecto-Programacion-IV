<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="PL.Ingreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>

    </script>

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container">
            <header class="major">
                <h2>Ingresar</h2>
            </header>

            <form runat="server">

                <div class="Contenido1">
                <input type="text" id="txtusuario" name="txtusuario" runat="server" placeholder="Usuario" maxlength="15" required="required" />
                <br />
                <input type="password" id="txtcontrasenia" name="txtcontrasenia" runat="server" placeholder="Contraseña" maxlength="15" required="required" />
                <br />
                    </div>

                <div class="row">
                    <div class="col-lg-7">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Width="150px" class="submit" OnClick="btnAceptar_Click" />
                    </div>
                    <div class="col-lg-8">
                        <input type="button" id="btnCancelar" onclick="location.href = 'Inicio.aspx' " runat="server" value="Cancelar" />
                    </div>
                    <div class="col-lg-8">
                        <asp:Button ID="btnRecuperarContrasenia" runat="server" Text="Recuperar Contraseña" Width="250px" class="submit" OnClick="btnRecuperarContrasenia_Click" />
                    </div>
                </div>

                <asp:Label Text="" ID="lblMensaje" runat="server" Font-Size="XX-Large" />
            </form>

        </div>
    </section>
</asp:Content>
