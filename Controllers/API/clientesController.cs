using Newtech.Acciones;
using Newtech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Newtech.Controllers.API
{
    [RoutePrefix("Accion")]
    public class clientesController : ApiController
    {

        [HttpPost,Route("Agregar")]

        public void agregar (Personas persona)
        {
            Accion acciones = new Accion();
            acciones.agregar_profile(persona);

        }

        [HttpGet,Route("Refrescar")]

        public List<Personas> obtener_personas()
        {
            Accion acciones = new Accion();

            var listado =acciones.Datos();
            return listado;

        }
        [HttpPost,Route("Eliminar")]
        public void Borrar(Personas personas)
        {
            Accion acciones = new Accion();
            acciones.Borrar(personas);


        }

        [HttpPost,Route("Modificar")]

        public void Modificar(Personas personas)
        {
            Accion acciones = new Accion();
            acciones.Modificar(personas);


        }
        [HttpPost,Route("Buscar")]

        public void buscar (Personas personas)
        {
            profile_.id_profile = personas.id;
        }
        [HttpGet,Route("Encontrar")]

        public List<Personas> Encontrar()
        {
            Accion acciones = new Accion();
           var list= acciones.Encontrar();
            return list;
        }
    }
}
