$(document).on('ready', function () {

    $('#markers').addClass('hide');
    $('#ingresar').on('click', function () {

        //$('#iniciar').hide();
        $('#iniciar').addClass('hide');
        $('.menuUsuario').removeClass('hide');
        $('#markers').removeClass('hide');


        var email = $('#loginEmail').val();
        $('#nombreUsuario').text(email);

        //* alert("Bienvenido a VENADO Marker");*//
    });

    $("#salir").on('click', function () {
        $(".menuUsuario").addClass("hide");
        $("#iniciar").removeClass("hide");
        $('#markers').addClass('hide');
    });


});

