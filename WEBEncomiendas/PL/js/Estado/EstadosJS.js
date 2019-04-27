

function GuardarModal() {
    var modal = document.querySelector('#my-modal');

    var valCierre = document.getElementById("MainContent_cmbEstados").value;

    var vldPaquete = document.getElementById("MainContent_txtIdPaquete").value;
    vldPaquete = vldPaquete.replace(/\s/g, "");

    if (vldPaquete == "") {
        alert("No se pueden dejar los campos vacíoss");
        return false;
    } else if (valCierre == 1) {
        alert("Ya se encuentra con estado recibido");
        return false;
    }
    else {
        modal.style.display = 'none';
        return true;
    }

}

function Editado() {
    alert("Registro editado correctamente");
}

function Guardado() {
    alert("Registro guardado correctamente");
}

function Eliminado() {
    alert("Registro eliminado correctamente");
}


// Get DOM Elements
const modal = document.querySelector('#my-modal');
//const modalBtn = document.querySelector('#modal-btn');
//const modalBtn = document.getElementById('btnEditar');
const closeBtn = document.querySelector('.close');

// Events
//modalBtn.addEventListener('click', openModal);
closeBtn.addEventListener('click', closeModal);
window.addEventListener('click', outsideClick);

// Open
function openModal() {
    modal.style.display = 'block';

}
// Close
function closeModal() {
    modal.style.display = 'none';
}

// Close If Outside Click
function outsideClick(e) {
    if (e.target == modal) {
        modal.style.display = 'none';
    }
}


function ValidarNumero(e) {
    key = e.keyCode || e.which;

    teclado = String.fromCharCode(key).toLowerCase();

    letras = "1234567890";

    especiales = "8-37-38-46";

    teclado_especiales = false;


    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especiales = true;
            break;
        }

        if ((letras.indexOf(teclado) == -1) && (!teclado_especiales)) {
            alert("No se pueden ingresar letras");
            return false;
        }
        else {
            return true;
        }
    }

}