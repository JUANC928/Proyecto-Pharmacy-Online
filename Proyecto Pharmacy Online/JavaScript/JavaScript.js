
window.addEventListener('scroll', function () {
    let animacion = document.getElementsByClassName('animacion-abajo');
    for (var i = 0; i < animacion.length; i++) {
        var posicionobj = animacion[i].getBoundingClientRect().top;
        console.log("distancia obj: " + i + "   es   " + posicionobj);
        if (posicionobj < 400) {
            animacion[i].classList.add("aparicion-abajo");
            animacion[i].classList.remove("animacion-abajo");
            console.log("se añadio la animacion");
        }
    }
});

