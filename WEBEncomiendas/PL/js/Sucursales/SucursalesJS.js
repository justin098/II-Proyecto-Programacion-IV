

function GuardarModal() {
    var modal = document.querySelector('#my-modal');
    var tmApertura = document.getElementById("MainContent_tmApertura").value;
    var tmCierre = document.getElementById("MainContent_tmCierre").value;
    var vldNombre = document.getElementById("MainContent_txtNombreSucursal").value;

    var valApertura = document.getElementById("MainContent_cmbDiaApertura").value;
    var valCierre = document.getElementById("MainContent_cmbDiaCierre").value;

    vldNombre = vldNombre.replace(/\s/g, "");

    var vldDireccion = document.getElementById("MainContent_txtDireccion").value;
    vldDireccion = vldDireccion.replace(/\s/g, "");
    if (vldNombre == "" || vldDireccion == "" || tmApertura == "" || tmCierre == "") {
        alert("No se pueden dejar los campos vacíoss");
        return false;
    } else if (tmApertura >= tmCierre) {
        alert("La hora de apertura no puede ser mayor o igual a la de cierre");
        return false;
    } else if (valApertura > valCierre) {
        alert("El día de apertura no puede ser después del día de cierre");
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