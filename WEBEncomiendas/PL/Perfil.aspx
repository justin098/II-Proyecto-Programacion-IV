<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="PL.Perfil" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


     <script>

    </script>

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container">
            <header class="major">
                <h2>Mi perfil</h2>
            </header>
             
      <form runat="server">

                <input type="text" id="txtnombre" name="txtnombre" runat="server" placeholder="Nombre" maxlength="25" required="required" />
                <br />
                <input type="text" id="txtprimerapellido" name="txtprimerapellido" runat="server" placeholder="Primer Apellido" maxlength="25" required="required" />
                <br />
                <input type="text" id="txtsegundoapellido" name="txtsegundoapellido" runat="server" placeholder="Segundo Apellido" maxlength="25" required="required" />
                <br />
                <input type="text" id="txtcorreo" name="Txtcorreo" runat="server" placeholder="Correo" maxlength="35" required="required" />
                <br />
                <input type="text" id="txttelefono" name="txttelefono" runat="server" placeholder="Teléfono" maxlength="14" required="required"  />
                <br />
                <input type="text" id="txtusuario" name="Txtusuario" runat="server" placeholder="Usuario" maxlength="15" required="required" />
                <br />
                <input type="text" id="txtcontraseña" name="txtcontraseña" runat="server" placeholder="Contraseña" maxlength="15" required="required" />
                <br />
               <%-- <input type="text" id="txttarjeta" name="txttarjeta"" runat="server" placeholder="Tarjeta" maxlength="15" required="required"/> --%>
               
      
          
          <div class="row">
                        <div class="col-lg-7">
                            <input type="submit" id="btnAceptar" runat="server" value="Aceptar"/>
                        </div>
                        <div class="col-lg-8">
                            <input type="button" id="btnCancelar" onclick="location.href = 'Inicio.aspx' " runat="server" value="Cancelar" />
                        </div>
                   
                    </div>
  </form>

            </div>
        </section>

</asp:Content>

