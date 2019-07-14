 function Refrescar_Tabla() {
  
        console.log("Refresca");
        $.ajax({

            url: '/Accion/Refrescar',
            type: 'GET',
            datatype: 'json',
            success: function (Data) {

                $('#listodo').text("");
                console.log("Entro a refrescar");
                $.each(data, function (index, obj) {
                    $('#listado').append(`   <tr>
                        <td>${obj.Nombre}</td>
                         <td>${obj.Apellido}</td>
                         <td>${obj.nacimiento}</td>
                          <td>${obj.profile}</td>
                          <td>${obj.Description}</td>
                           
                         
                    </tr>`)

                });
            }
        });


}