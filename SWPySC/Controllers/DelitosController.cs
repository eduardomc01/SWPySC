using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SWPySC.Models;

namespace SWPySC.Controllers
{

    [Route("[controller]")]
    public class DelitosController : Controller
    {

        [HttpGet("[action]")]
        public List<Delitos> GetDatasDelitos()
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from e in context.Delitos select e).ToList();

            return list;

        }


        [HttpGet("[action]")]
        public List<Codigos> GetCodigosDelitos()
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from e in context.Codigos select e).ToList();

            return list;

        }



        [HttpGet("[action]")]
        public int[] GetEstadisticsCrimes()
        {

            int[] valores = new int[10];

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            for (int i = 1; i < valores.Length; i++)
            {
                valores[i] = context.Delitos.Count(s => s.IdCodigo == i);
            }

            return valores;

        }



        [HttpGet("[action]")]
        public List<Historialdelitomes> GetEstadisticsMonth() //<-- enfocate aqui
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from e in context.Historialdelitomes select new Historialdelitomes {

                Id = e.Id,
                Enero = e.Enero,
                Febrero = e.Febrero,
                Marzo = e.Marzo,
                Abril = e.Abril,
                Mayo = e.Mayo,
                Junio = e.Junio,
                Julio = e.Julio,
                Agosto = e.Agosto,
                Septiembre = e.Septiembre,
                Octubre = e.Octubre,
                Noviembre = e.Noviembre,
                Diciembre = e.Diciembre

            }).ToList();

            return list;

        }



        [HttpGet("[action]")]
        public List<Gradodelito> GetGradeDelitos()
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from e in context.Gradodelito select e).ToList();

            return list;

        }



        [HttpPost("[action]")]
        public int InsertDatasDelitos([FromBody] Delitos data)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            context.Delitos.Add(data);
            context.SaveChanges();

            return 1; //<--- falta validar esta parte

        }


    }

}