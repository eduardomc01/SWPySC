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
        public List<DatasSuperAdmin> GetAdministratorDatasHome(int id)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from a in context.Registros

                        join e in context.Tipousuarios on a.IdTipoUsuario equals e.Id

                        where a.Id == id
                        select new DatasSuperAdmin
                        {

                            Nombre = a.Nombre,
                            Correo = a.Correo,
                            TipoUsuario = e.Tipo,
                            Date = DateTime.Today.ToString("dd-MM-yyyy")

                        }).ToList();

            return list;

        }


        [HttpGet("[action]")]
        public List<DatasHistorialUsuario> GetAllChangeAdministrators()
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from a in context.Registros 
                        
                        join  e in context.Historialusuarios on a.Id equals e.IdUsuario

                        join o in context.Acciones on e.IdAccion equals o.Id

                        select new DatasHistorialUsuario

                        {

                            Nombre = a.Nombre,
                            Hora = e.Hora,
                            Dia = e.Dia,
                            TipoAccion = o.Tipo,
                            Comentario = o.Comentario

                        }
                        
                        
                        ).ToList();

            return list;

        }


    }



    public partial class DatasHistorialUsuario
    {
       
        public string Nombre { get; set; }
        public TimeSpan? Hora { get; set; }
        public DateTime? Dia { get; set; }
        public string TipoAccion { get; set; }
        public string Comentario { get; set; }

    }



}