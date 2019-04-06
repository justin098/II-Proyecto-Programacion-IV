<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="PL.Ingresar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href='https://fonts.googleapis.com/css?family=PT+Sans:400,700' rel='stylesheet' type='text/css'/>
    <link rel="stylesheet" href="css/reset.css"/> <!-- CSS reset -->
    <link rel="stylesheet" href="css/style.css"/> <!-- Resource style -->
    <link rel="stylesheet" href="css/demo.css"/> <!-- Demo style -->

    <title>Registro</title>
</head>
<body>
    <header class="cd-main-header">
        <div class="cd-main-header__logo">
          
        </div>
        <nav class="cd-main-nav js-main-nav">
            <ul class="cd-main-nav__list js-signin-modal-trigger">
                <!-- inser more links here -->
                <li><a class="cd-main-nav__item cd-main-nav__item--signin" href="#0" data-signin="login">Ingresar</a></li>
                <li><a class="cd-main-nav__item cd-main-nav__item--signup" href="#0" data-signin="signup">Registrarse</a></li>
            </ul>
        </nav>

    </header>
    <div class="cd-intro">
        <img src="images/LogoSample_ByTailorBrands (8).jpg" />
        <div class="cd-nugget-info">
            <a href="Inicio.aspx">
                <p>Página de inicio</p>
            </a>
        </div> <!-- cd-nugget-info -->
    </div>
    <div class="cd-signin-modal js-signin-modal">
        <!-- this is the entire modal form, including the background -->
        <div class="cd-signin-modal__container">
            <!-- this is the container wrapper -->
            <ul class="cd-signin-modal__switcher js-signin-modal-switcher js-signin-modal-trigger">
                <li><a href="#0" data-signin="login" data-type="login">Ingresar</a></li>
                <li><a href="#0" data-signin="signup" data-type="signup">Cuenta nueva</a></li>
            </ul>
            <div class="cd-signin-modal__block js-signin-modal-block" data-type="login">
                <!-- log in form -->
                <form class="cd-signin-modal__form">
                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--email cd-signin-modal__label--image-replace" for="signin-email">Correo</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="signin-email" type="email" placeholder="Correo"/>
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--password cd-signin-modal__label--image-replace" for="signin-password">Contraseña</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="signin-password" type="text" placeholder="Contraseña"/>
                        <a href="#0" class="cd-signin-modal__hide-password js-hide-password">Hide</a>
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <input type="checkbox" id="remember-me" checked class="cd-signin-modal__input "/>
                        <label for="remember-me">Recuérdame</label>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width" type="submit" value="Ingresar"/>
                    </p>
                </form>

                <p class="cd-signin-modal__bottom-message js-signin-modal-trigger"><a href="#0" data-signin="reset">¿Olvidaste tu contraseña?</a></p>
            </div> <!-- cd-signin-modal__block -->
            <div class="cd-signin-modal__block js-signin-modal-block" data-type="signup">
                <!-- sign up form -->
                <form class="cd-signin-modal__form">
                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--username cd-signin-modal__label--image-replace" for="signup-username">Nombre</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="signup-username" type="text" placeholder="Nombre"/>
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--username cd-signin-modal__label--image-replace" for="signup-firstlastname">Primer apellido</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="signup-firstlastname" type="text" placeholder="Primer apellido"/>
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--username cd-signin-modal__label--image-replace" for="signup-Secondsurname">Segundo apellido</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="signup-Secondsurname" type="text" placeholder="Segundo apellido"/>
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>

                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--email cd-signin-modal__label--image-replace" for="signup-email">Correo</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="signup-email" type="email" placeholder="Correo"/>
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--cellphone cd-signin-modal__label--image-replace" for="signup-cellphone">Teléfono</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="signup-cellphone" type="text" placeholder="Teléfono"/>
                        <!--<a href="#0" class="cd-signin-modal__hide-password js-hide-password">Hide</a>-->
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--number cd-signin-modal__label--image-replace" for="signup-number">Número de tarjeta</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="signup-number" type="text" placeholder="Número de tarjeta"/>
                        <!--<a href="#0" class="cd-signin-modal__hide-password js-hide-password">Hide</a>-->
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>


                    <p class="cd-signin-modal__fieldset">
                        <input type="checkbox" id="accept-terms" class="cd-signin-modal__input ">
                        <label for="accept-terms">Estoy de acuerdo con los <a href="#0">términos</a></label>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding" type="submit" value="Crear cuenta"/>
                    </p>
                </form>
            </div> <!-- cd-signin-modal__block -->
            <div class="cd-signin-modal__block js-signin-modal-block" data-type="reset">
                <!-- reset password form -->
                <p class="cd-signin-modal__message">¿Perdiste tu contraseña? Por favor, introduzca su dirección de correo electrónico. Recibirá un enlace para crear una nueva contraseña.</p>
                <form class="cd-signin-modal__form">
                    <p class="cd-signin-modal__fieldset">
                        <label class="cd-signin-modal__label cd-signin-modal__label--email cd-signin-modal__label--image-replace" for="reset-email">Correo</label>
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding cd-signin-modal__input--has-border" id="reset-email" type="email" placeholder="Correo"/>
                        <span class="cd-signin-modal__error">Error!</span>
                    </p>
                    <p class="cd-signin-modal__fieldset">
                        <input class="cd-signin-modal__input cd-signin-modal__input--full-width cd-signin-modal__input--has-padding" type="submit" value="Restablecer la contraseña"/>
                    </p>
                </form>
                <p class="cd-signin-modal__bottom-message js-signin-modal-trigger"><a href="#0" data-signin="login">Atrás para iniciar sesión</a></p>
            </div> <!-- cd-signin-modal__block -->
            <a href="#0" class="cd-signin-modal__close js-close">Close</a>
        </div> <!-- cd-signin-modal__container -->
    </div> <!-- cd-signin-modal -->
    <script src="js/placeholders.min.js"></script> <!-- polyfill for the HTML5 placeholder attribute -->
    <script src="js/main.js"></script> <!-- Resource JavaScript -->
</body>

</html>