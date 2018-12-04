using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SWPySC.Models;

namespace SWPySC.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private List<DatasLogin> list;

        [HttpPost("[action]")]
        public List<DatasLogin> Admin([FromBody] DatasLogin datas)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            this.list = (from e in context.Registros where e.Correo == datas.User && e.Password == datas.Pass select new DatasLogin
            {
                Id = e.Id,
                IdTipoUsuario = e.IdTipoUsuario

            }).ToList();


            return list;

        }


    }


    public partial class DatasLogin
    {

        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public int? IdTipoUsuario { get; set; }

    }


}
