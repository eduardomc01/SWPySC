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







    }

}