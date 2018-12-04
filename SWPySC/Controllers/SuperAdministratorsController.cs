using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;


using SWPySC.Models;

namespace SWPySC.Controllers
{

    [Route("[controller]")]
    public class SuperAdministratorsController : Controller
    {


        [HttpGet("[action]")]
        public List<Registros> GetSuperAdministrator(int id)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from e in context.Registros where e.Id == id select e).ToList();

            return list;

        }




        [HttpPost("[action]")]
        public int UpdateSuperAdministrator(int id, [FromBody] Registros datas)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var change = context.Registros.Find(id);

            change.Nombre = datas.Nombre;
            change.Correo = datas.Correo;
            change.Password = datas.Password;

            context.SaveChanges();

            return 1;

        }


        [HttpGet("[action]")]
        public List<DatasSuperAdmin> GetSuperAdministratorDatasHome(int id)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from a in context.Registros

                        join e in context.Tipousuarios on a.IdTipoUsuario equals e.Id

                        where a.Id == id select new DatasSuperAdmin
                        {

                            Nombre = a.Nombre,
                            Correo = a.Correo,
                            TipoUsuario = e.Tipo,
                            Date = DateTime.Today.ToString("dd-MM-yyyy")

                        }).ToList();

            return list;

        }



        [HttpGet("[action]")]
        public List<DatasSuperAdmin> GetAllSuperAdministrator()
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from a in context.Registros

                        join e in context.Tipousuarios on a.IdTipoUsuario equals e.Id

                        join o in context.Estatus on a.IdEstatus equals o.Id

                        where a.IdTipoUsuario == 2

                        select new DatasSuperAdmin
                        {
                            _Id = a.Id,
                            Nombre = a.Nombre,
                            Correo = a.Correo,
                            TipoUsuario = e.Tipo,
                            TipoEstatus = o.Tipo

                        }).ToList();

            return list;

        }





        [HttpPost("[action]")]
        public int EstatusSuperAdministrator(int op, [FromBody] int id)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var found = context.Registros.Find(id);

            switch (op)
            {

                case 1:
                    found.IdEstatus = 1;
                    break;

                case 2:
                    found.IdEstatus = 2;
                    break;

                case 3:
                    context.Registros.Attach(found);
                    context.Registros.Remove(found);
                    break;

            }

         
            context.SaveChanges();

            return 1;

        }


        [HttpPost("[action]")]
        public int InsertModifications([FromBody] Historialusuarios datas)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;


            context.Historialusuarios.Add(datas);
            context.SaveChanges();

            return 1; //<--- falta validar esta parte


        }




    }

    
    public partial class DatasSuperAdmin
    {
        public int _Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string TipoUsuario { get; set; }
        public string TipoEstatus { get; set; }
        public string Date { get; set; }

    }
   
}