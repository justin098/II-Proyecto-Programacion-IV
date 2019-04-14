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
                <input type="text" id="txtusuario" name="txtusuario" runat="server" placeholder="Usuario" maxlength="15" required="required" />
                <br />
                <input type="text" id="txtcontraseña" name="txtcontraseña" runat="server" placeholder="Contraseña" maxlength="15" required="required"/>
                <br />
               
           <div class="row">
                        <div class="col-lg-7">
                            <input type="submit" id="btnAceptar" runat="server" value="Aceptar"/>
                        </div>
                        <div class="col-lg-8">
                            <input type="button" id="btnCancelar" runat="server" value="Cancelar" />
                        </div>
                         <div class="col-lg-8">
                            <input type="button" id="btnregresar" runat="server" value="Regresar" />
                        </div>
                    </div>

          </form>

            </div>
        </section>
</asp:Content>
