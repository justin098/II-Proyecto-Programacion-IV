function eliminarRol() {
    var mensaje;
    var opcion = confirm("¿Deseas realmente eliminar el Rol?");
    if (opcion == true) {
        return true;
    } else {
        return false;
    }
}

function GuardarModal() {
    var modal = document.querySelector('#my-modal');

    var vldRol = document.getElementById("MainContent_txtRol").value;
    vldRol = vldRol.replace(/\s/g, "");

    var vldDescripcion = document.getElementById("MainContent_txtDescripcion").value;
    vldDescripcion = vldDescripcion.replace(/\s/g, "");

    if (vldRol == "" || vldDescripcion == "") {
        alert("Debe llenar todos los campos");
        return false;
    } else {
        modal.style.display = 'none';
        return true;
    }

}

function eliminarPrivilegio() {
    var mensaje;
    var opcion = confirm("¿Deseas realmente eliminar el Privilegio?");
    if (opcion == true) {
        return true;
    } else {
        return false;
    }
}