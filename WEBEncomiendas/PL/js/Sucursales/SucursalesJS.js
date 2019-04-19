

function GuardarModal() {
    var modal = document.querySelector('#my-modal');
    var vldNombre = document.getElementById("MainContent_txtNombreSucursal").value;
    vldNombre = vldNombre.replace(/\s/g, "");
    var vldDireccion = document.getElementById("MainContent_txtDireccion").value;
    vldDireccion = vldDireccion.replace(/\s/g, "");
    if (vldNombre == "" || vldDireccion == "") {
        alert("No se pueden dejar los campos vacíos");
        return false;
    } else {
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