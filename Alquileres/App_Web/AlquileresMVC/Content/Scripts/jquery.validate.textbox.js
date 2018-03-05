/*
* jQuery validation textbox
*
* Copyright (c) 2006 - 2008 IBM - e-Power - Alimentos Heinz
*
* Funciones para validar todos los text-boxs del sistema de Balanza.
* Validar textbox que solo acepte numeros.
* Validar textbox que solo acepte letras.
* Validar textbox que solo acepte numeros y guiones para campos fechas dd-mm-yyyy.
* 
*/

function validarNumeros(e) {
    var key;
    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }
    if (key < 48 || key > 57) {
        return false;
    }
    return true;
}

function validarLetras(e) { // 1
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true; // backspace
    if (tecla == 32) return true; // espacio
    if (e.ctrlKey && tecla == 86) { return true; } //Ctrl v
    if (e.ctrlKey && tecla == 67) { return true; } //Ctrl c
    if (e.ctrlKey && tecla == 88) { return true; } //Ctrl x
    patron = /[a-zA-Z]/; //patron
    te = String.fromCharCode(tecla);
    return patron.test(te); // prueba de patron
}

// Esta es la funcion que se usa para validar la fecha en los textbox
function validarFecha(e) {
    var key;
    te = String.fromCharCode(key);
    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }
    if (key == 45) return true; // "-" Gion
    if (key < 48 || key > 57 || key == null || key == "") {
        return false;
    }
    return true;
}

// No se usa
function validarFecha2(e) {
    var key;
    var pattern = /^\d{2}-\d{2}-\d{4}$/;
    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }
    if (key == null || key == "" || !pattern.test(key)) {
        return false;
    }
    return true;
}

// No se usa
function validarFecha3(e) { // 1
    tecla = (document.all) ? e.keyCode : e.which;
    var patron = new RegExp(/^\d{2}-\d{2}-\d{4}$/);
    te = String.fromCharCode(tecla);
    if (patron.test(te)) {
        return true;
    } else {
        return false;
    }
}