function eliminarUsuario() {
    var mensaje;
    var opcion = confirm("¿Deseas realmente eliminar el usuario?");
    if (opcion == true) {
        return true;
    } else {
        return false;
    }
}

function GuardarModal() {
    var modal = document.querySelector('#my-modal');

    var vldCedula = document.getElementById("MainContent_txtCedula").value;
    vldCedula = vldCedula.replace(/\s/g, "");

    var vldNombre = document.getElementById("MainContent_txtNombre").value;
    vldNombre = vldNombre.replace(/\s/g, "");

    var vldPrimerApellido = document.getElementById("MainContent_txtPrimerApellido").value;
    vldPrimerApellido = vldPrimerApellido.replace(/\s/g, "");

    var vldSegundoApellido = document.getElementById("MainContent_txtSegundoApellido").value;
    vldSegundoApellido = vldSegundoApellido.replace(/\s/g, "");

    var vldEmail = document.getElementById("MainContent_txtEmail").value;
    vldEmail = vldEmail.replace(/\s/g, "");

    var vldTelefono1 = document.getElementById("MainContent_txtTelefono1").value;
    vldTelefono1 = vldTelefono1.replace(/\s/g, "");

    var vldUsuario = document.getElementById("MainContent_txtUsuario").value;
    vldUsuario = vldUsuario.replace(/\s/g, "");

    var vldContrasenia = document.getElementById("MainContent_txtContrasenia").value;
    vldContrasenia = vldContrasenia.replace(/\s/g, "");

    var vldcmbProvincias = document.getElementById("MainContent_cmbProvincias").value;
    vldcmbProvincias = vldcmbProvincias.replace(/\s/g, "");

    var vldcmbCantones = document.getElementById("MainContent_cmbCantones").value;
    vldcmbCantones = vldcmbCantones.replace(/\s/g, "");

    var vldcmbDistritos = document.getElementById("MainContent_cmbDistritos").value;
    vldcmbDistritos = vldcmbDistritos.replace(/\s/g, "");

    var vldDireccion = document.getElementById("MainContent_txtDireccion").value;
    vldDireccion = vldDireccion.replace(/\s/g, "");

    if (vldCedula == "" || vldNombre == "" || vldPrimerApellido == "" || vldSegundoApellido == "" || vldEmail == "" || vldTelefono1 == ""
        || vldUsuario == "" || vldContrasenia == "" || vldcmbProvincias == "" || vldcmbCantones == "" || vldcmbDistritos == "" || vldDireccion == "") {
        alert("Debe llenar todos los campos");
        return false;
    } else {
        modal.style.display = 'none';
        return true;
    }

}