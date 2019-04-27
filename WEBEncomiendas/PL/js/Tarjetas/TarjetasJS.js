function eliminarTarjeta() {
    var mensaje;
    var opcion = confirm("¿Deseas realmente eliminar la tarjeta?");
    if (opcion == true) {
        return true;
    } else {
        return false;
    }
}

function GuardarModal() {
    var modal = document.querySelector('#my-modal');

    var vldNumeroTarjeta = document.getElementById("MainContent_txtNumeroTarjeta").value;
    vldNumeroTarjeta = vldNumeroTarjeta.replace(/\s/g, "");

    var vldFechaVencimiento = document.getElementById("MainContent_dttFechaVencimiento").value;
    vldFechaVencimiento = vldFechaVencimiento.replace(/\s/g, "");

    var vldCodigoSeguridad = document.getElementById("MainContent_txtCodigoSeguridad").value;
    vldCodigoSeguridad = vldCodigoSeguridad.replace(/\s/g, "");

    if (vldNumeroTarjeta == "" || vldFechaVencimiento == "" || vldCodigoSeguridad == "") {
        alert("Debe llenar todos los campos obligatorios");
        return false;
    } else {
        modal.style.display = 'none';
        return true;
    }

}