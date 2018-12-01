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
        public List<Datas> GetSuperAdministratorDatasHome(int id)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from a in context.Registros

                        join e in context.Tipousuarios on a.IdTipoUsuario equals e.Id

                        where a.Id == id select new Datas
                        {

                            Nombre = a.Nombre,
                            Correo = a.Correo,
                            TipoUsuario = e.Tipo,
                            Date = DateTime.Today.ToString("dd-MM-yyyy")

                        }).ToList();

            return list;

        }

    }


    public partial class Datas
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string TipoUsuario { get; set; }
        public string Date { get; set; }

    }

}