

$(document).ready(function () {

    Refrescar_Tabla();
    $('#myForm').submit(function () {
     

        console.log("Funciona");
        let nombre = $('#nombre').val();
        let apellido = $('#apellido').val();
        let nacimiento = $('#nacimiento').val();
        let profile = $('#profile').val();
        let description = $('#description').val();
        $.post('/Accion/Agregar', {
            'Nombre': nombre,
            'Apellido': apellido,
            'nacimiento': nacimiento,
            'profile': profile,
            'Description': description
        }, function () {
                
                Refrescar_Tabla();
            });

    });


    function Refrescar_Tabla() {

        console.log("Refresca");
        $.ajax({

            url: '/Accion/Refrescar',
            type: 'GET',
            datatype: 'json',
            success: function (data) {

                $('#listado').text("");
                console.log("Entro a refrescar");
                $.each(data, function (index, obj) {

                    $('#listado').append(`   <tr>
                        <td>${obj.Nombre}</td>
                         <td>${obj.Apellido}</td>
                         <td>${obj.nacimiento2}</td>
                          <td>${obj.profile}</td>
                          <td>${obj.Description}</td>
                          <td><button class="btn btn-outline-primary" id="modificar" value="${obj.id}" data-toggle="modal" data-target="#modal_mod"> Modfificar</button></td>
                          <td><button  id="Borrar" class="btn btn-outline-danger" value="${obj.id}">Eliminar</button></td>
                           
                         
                    </tr>`);

                });
            }
        });


    }
    $(document).on('click', '#Borrar', function () {
        console.log("entra");
        let cach= $(this)[0];
        let id = $(cach).val();

        $.post("/Accion/Eliminar", { 'id': id }, function () {
            Refrescar_Tabla();
         
        });
      
    });
    $(document).on('click', '#modificar', function () {

        let cach = $(this)[0];
        let id = $(cach).val();
        $.post('/Accion/Buscar', { 'id': id }, function () {
            $.ajax({
                url: '/Accion/Encontrar',
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    $.each(data, function (index, obj) {
                        $('#nombre1').attr("value", obj.Nombre);
                        $('#apellido1').attr("value", obj.Apellido);
                      

                    });

                }

            })
        });

    });

    $('#modif').submit(function (e) {
        e.preventDefault;
           
            let nombre = $('#nombre1').val();
            let apellido = $('#apellido1').val();
            let nacimiento = $('#nacimiento1').val();
            let profile = $('#profile1').val();
            let description = $('#description1').val();
            $.post('/Accion/Modificar', {
                'Nombre': nombre,
                'Apellido': apellido,
                'nacimiento': nacimiento,
                'profile': profile,
                'Description': description
            }, function () {
                    Refrescar_Tabla();
                
            
            });
   

    });

});


