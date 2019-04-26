
function ValidarNumero(e) {
    key = e.keyCode || e.which;

    teclado = String.fromCharCode(key).toLowerCase();

    letras = "1234567890.";

    especiales = "8-37-38-46";

    teclado_especiales = false;

    var peso = document.getElementById("MainContent_txtPeso").value;

    for (var i in especiales) {

        if (key == especiales[i]) {
            teclado_especiales = true;
            alert(especiales[i]);
            break;
        }

        if ((letras.indexOf(teclado) == -1) && (!teclado_especiales)) {
            alert("No se pueden ingresar letras");
            return false;
        }
        else {
            if (peso.length >= 7) {
                break;
                return false;
            }
            if (teclado == '.') {
                if (peso.indexOf('.') != -1)
                    return false;
                else {
                    calculoCostos(peso + ".0");
                    return true;
                }
            } else {
                if (peso.length == 0) {
                    calculoCostos(teclado + peso);
                } else {
                    calculoCostos(peso + teclado);
                }

                return true;


            }
        }
    }

}

function EntregaDomicilio() {
    var checkbox = document.getElementById('MainContent_chkEntrega');
    var checked = checkbox.checked;
    var entrega = document.getElementById('MainContent_divEntrega');
    var sucursal = document.getElementById('MainContent_divSucursal');
    if (checked) {
        //se define la variable "el" igual a nuestro div
        entrega.style.display = 'block'; //damos un atributo display:none que oculta el div
        sucursal.style.display = 'none';

    } else {
        entrega.style.display = 'none';
        sucursal.style.display = 'block';

    }

}



window.onload = function () {
    var entrega = document.getElementById('MainContent_divEntrega');
    var sucursal = document.getElementById('MainContent_divSucursal');
    entrega.style.display = 'none';
    sucursal.style.display = 'block';
    document.getElementById("MainContent_txtCalculo").value = "0";
    document.getElementById("MainContent_txtEnvio").value = "0";
    document.getElementById("MainContent_txtSubtotal").value = "0";
    document.getElementById("MainContent_txtTotal").value = "0";
    var LimpiarBtn = document.getElementById('MainContent_btnLimpiar');
    LimpiarBtn.style.display = 'none';
    var tarjetas = document.getElementById('MainContent_divTarjetas');
    tarjetas.style.display = 'none';
    var RegistrarBtn = document.getElementById('MainContent_btnRegistrar');
    RegistrarBtn.style.display = 'none';
}


function calculoCostos(pesoIngresado) {
    var pesoDecimal = parseFloat(pesoIngresado);
    var calculoPeso;
    if (pesoDecimal <= 0.5) {
        calculoPeso = pesoDecimal * 3700;
    } else if (pesoDecimal >= 0.5 && pesoDecimal <= 2.5) {
        calculoPeso = pesoDecimal * 6240;
    } else if (pesoDecimal >= 2.51 && pesoDecimal <= 5) {
        calculoPeso = pesoDecimal * 5940;
    }
    else if (pesoDecimal >= 5.01 && pesoDecimal <= 7.5) {
        calculoPeso = pesoDecimal * 5940;
    } else if (pesoDecimal >= 7.51 && pesoDecimal <= 10) {
        calculoPeso = pesoDecimal * 5280;
    }
    else if (pesoDecimal >= 10.01 && pesoDecimal <= 12.5) {
        calculoPeso = pesoDecimal * 4920;
    }
    else if (pesoDecimal >= 12.51 && pesoDecimal <= 15) {
        calculoPeso = pesoDecimal * 4560;
    }
    else if (pesoDecimal >= 15.01 && pesoDecimal <= 17.5) {
        calculoPeso = pesoDecimal * 4200;
    }
    else if (pesoDecimal >= 17.51 && pesoDecimal <= 20) {
        calculoPeso = pesoDecimal * 3840;
    }
    else if (pesoDecimal >= 20.01 && pesoDecimal < 30) {
        calculoPeso = pesoDecimal * 3480;
    } else if (pesoDecimal >= 30) {
        calculoPeso = pesoDecimal * 3120;
    }
    document.getElementById("MainContent_txtCalculo").value = calculoPeso;
    costoServicio();

}


function costoServicio() {

    var tipoEntrega = document.getElementById("MainContent_ddlServicios").selectedIndex;
    if (tipoEntrega == 0) {
        document.getElementById("MainContent_txtEnvio").value = 3500;
    } else if (tipoEntrega == 1) {
        document.getElementById("MainContent_txtEnvio").value = 5000;
    } else {
        document.getElementById("MainContent_txtEnvio").value = 6500;
    }
    costoSolicitud();
}

function costoSolicitud() {
    var subtotal = parseFloat(document.getElementById("MainContent_txtEnvio").value) + parseFloat(document.getElementById("MainContent_txtCalculo").value);

    document.getElementById("MainContent_txtSubtotal").value = subtotal;

    var impuesto = subtotal * 0.13;

    document.getElementById("MainContent_txtTotal").value = subtotal + impuesto;

}

function validacionGuardar() {
    var descripcion, articulo, servicio, sucursalretiro, entrega, peso, tarjetapago, cedula, nombre;

    descripcion = document.getElementById("MainContent_txtDescripcion").value;

    var comboArticulo = document.getElementById("MainContent_ddlCategoria");
    articulo = comboArticulo.options[comboArticulo.selectedIndex].text;

    var comboServicio = document.getElementById("MainContent_ddlServicios");
    servicio = comboServicio.options[comboServicio.selectedIndex].text;

    var comboSucursal = document.getElementById("MainContent_ddlSucursales");
    sucursalretiro = comboSucursal.options[comboSucursal.selectedIndex].text;

    var checkbox = document.getElementById('MainContent_chkEntrega');
    var checked = checkbox.checked;

    peso = document.getElementById("MainContent_txtPeso").value;

    var tarjeta = document.getElementById("MainContent_ddlTarjetas");
    tarjetapago = tarjeta.options[tarjeta.selectedIndex].text;

    cedula = document.getElementById("MainContent_txtCedula").value;

    nombre = document.getElementById("MainContent_txtNombreCliente").value;

    var validacionCero = parseFloat(peso.replace(".", ""));
    calculoCostos(peso);

    if (descripcion == "" || articulo == "" || servicio == "" || peso == "" || tarjetapago == "" || cedula == "" || nombre == "") {
        alert("No dejar campos vacíos");
        return false;
    } else if (validacionCero == 0) {
        alert("No se puede dejar el peso en 0");
        return false;
    } else if (checked == true) {
        entrega = document.getElementById("MainContent_txtDireccion").value;
        if (entrega == "") {
            alert("No dejar campo de entrega vacío");
            return false;
        } else {
            return true;
        }
    } else if (checked == false) {
        if (sucursalretiro == "") {
            alert("No dejar campo de retiro vacío");
            return false;
        } else {
            return true;
        }
    } else {
        return true;
    }

}

