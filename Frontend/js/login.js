
const nombre = "admin"; 
const contrasena = 12345; 


function validar(){
    let user = document.getElementById("user").value; 
    let pass = document.getElementById("pass").value; 

    if (user == nombre && pass == contrasena){
        window.location="/Registro.html"; 
        
    }else{
        alert('DATOS ERRONEOS');
    }
}
