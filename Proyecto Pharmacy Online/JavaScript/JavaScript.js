
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

//var scrolling;
//let animacion = document.getElementsByClassName('info-display');
////window.addEventListener('scroll', function () {
////    window.clearTimeout(scrolling);
////    scrolling = setTimeout(function () {
////        for (var i = 0; i < animacion.length; i++) {
////            animacion[i].classList.add("info-display");
////            animacion[i].classList.remove("info-nodisplay");
////            console.log("scroll quieto");
////        }
////    }, 66);
////    for (var i = 0; i < animacion.length; i++) {
////        animacion[i].classList.add("info-nodisplay");
////        animacion[i].classList.remove("info-display");
////        console.log("scroll en mov");
////    }
////}, false);

//function scrollStop(scrollStop, refresh = 66) {

//    // Make sure a valid callback was provided
//    if (!callback || typeof callback !== 'function') return;

//    // Setup scrolling variable
//    let isScrolling;

//    // Listen for scroll events
//    window.addEventListener('scroll', function (event) {

//        // Clear our timeout throughout the scroll
//        window.clearTimeout(isScrolling);

//        // Set a timeout to run after scrolling ends
//        isScrolling = setTimeout(callback, refresh);

//    }, false);

//}
//var scrollStop = function (callback) {
//    for (var i = 0; i < animacion.length; i++) {
//        animacion[i].classList.add("info-display");
//        animacion[i].classList.remove("info-nodisplay");
//        console.log("scroll quieto");
//    }
//}

//scrollStop(function () {
//    for (var i = 0; i < animacion.length; i++) {
//        animacion[i].classList.add("info-nodisplay");
//        animacion[i].classList.remove("info-display");
//        console.log("scroll en mov");
//    }
//    console.log('Scrolling has stopped.');
//});