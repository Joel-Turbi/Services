using Newtech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newtech.Acciones
{
    public class Accion
    {

        public void agregar_profile(Personas personas)
        {
            using (ClientEntities DB = new ClientEntities())
            {
                Profile_Table profile = new Profile_Table();

                profile.Profiel_Name = personas.profile;
                profile.Profiel_Description = personas.Description;
                DB.Profile_Table.Add(profile);
                DB.SaveChanges();

                Profile_Table listado = DB.Profile_Table.Where(x => x.Profiel_Description == personas.Description).First();

                profile_.id_profile = listado.Id_Profiel;

                Action<Personas> action = agregar_client;
                action(personas);


            }
        }
        public void agregar_client(Personas persona)
        {
            using (ClientEntities DB = new ClientEntities())
            {
                Client_Table cliete = new Client_Table();

                cliete.Name = persona.Nombre;
                cliete.LastName = persona.Apellido;
                cliete.Birthday = persona.nacimiento;
                cliete.ProfileID = profile_.id_profile;
                DB.Client_Table.Add(cliete);
                DB.SaveChanges();


            }

        }
        public List<Personas> Datos()
        {
            using (ClientEntities DB = new ClientEntities())
            {
                var listado = DB.Client_Table.Join(DB.Profile_Table, x => x.ProfileID, y => y.Id_Profiel, (x, y) => new { x, y }).Select(x => new Personas
                {
                    id = x.x.Client_Id,
                    Nombre = x.x.Name,
                    Apellido = x.x.LastName,
                    nacimiento = x.x.Birthday,
                    profile = x.y.Profiel_Name,
                    Description = x.y.Profiel_Description
                }).ToList();
                return listado;
            }
        }

        public void Borrar(Personas personas)
        {
            using (ClientEntities DB = new ClientEntities())
            {
                var elimanar = DB.Client_Table.Find(personas.id);

                DB.Client_Table.Remove(elimanar);
                DB.SaveChanges();

                var eliminar_profile = DB.Profile_Table.Find(personas.id);
                DB.Profile_Table.Remove(eliminar_profile);
                DB.SaveChanges();


            }
        }
        public void Modificar(Personas personas)
        {
            using (ClientEntities DB = new ClientEntities())
            {
                Client_Table client = DB.Client_Table.Where(x => x.Client_Id == profile_.id_profile).First();

                client.Name = personas.Nombre;
                client.LastName = personas.Apellido;
                client.Birthday = personas.nacimiento;
                client.ProfileID = profile_.id_profile;



                DB.Entry(client).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();

                Profile_Table profile = DB.Profile_Table.Find(profile_.id_profile);
                {
                    profile.Profiel_Description = personas.Description;
                    profile.Profiel_Name = personas.Description;
                };
                DB.Entry(profile).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            };


        }


        public List<Personas> Encontrar()
        {
            using (ClientEntities DB = new ClientEntities())
            {
                var list = DB.Client_Table.Where(x => x.Client_Id == profile_.id_profile).Select(x => new Personas
                {
                    Nombre = x.Name,
                    Apellido = x.LastName,
                    nacimiento = x.Birthday
                }).ToList();

                return list;

            }
        }
    }
}
