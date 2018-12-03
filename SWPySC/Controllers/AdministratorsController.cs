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
    public class AdministratorsController : Controller
    {


        [HttpPost("[action]")]
        public int InsertAdmin([FromBody] Registros datas)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;


            if (datas.Nombre != null && datas.Password != null && datas.Correo != null)
            {

                context.Registros.Add(datas);
                context.SaveChanges();

                return 1;

            }
            else
            {

                return 0;

            }

        }


        [HttpGet("[action]")]
        public List<Registros> GetAdministrator(int id)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from e in context.Registros where e.Id == id select e).ToList();

            return list;

        }




        [HttpPost("[action]")]
        public int UpdateAdministrator(int id, [FromBody] Registros datas)
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
        public List<Datas> GetAdministratorDatasHome(int id)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from a in context.Registros

                        join e in context.Tipousuarios on a.IdTipoUsuario equals e.Id

                        where a.Id == id
                        select new Datas
                        {

                            Nombre = a.Nombre,
                            Correo = a.Correo,
                            TipoUsuario = e.Tipo,
                            Date = DateTime.Today.ToString("dd-MM-yyyy")

                        }).ToList();

            return list;

        }

    }




}