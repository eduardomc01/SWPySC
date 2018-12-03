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
        public List<DatasDelitos> GetSomeDatasDelitos(int cantidad)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from a in context.Delitos 
                        
                        join e in context.Codigos on a.IdCodigo equals e.Id

                        select new DatasDelitos {

                            Id = a.Id,
                            Direccion = a.Direccion,
                            Latitud = a.Latitud,
                            Longitud = a.Longitud,
                            TipoDelito = e.Comentario
                            
                        }).Take(cantidad).ToList();

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
        public int[] GetEstadisticsCrimes(int op)
        {

            int[] valores = new int[10];


            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;


            switch (op) {

                case 1:

                    for (int i = 1; i < valores.Length; i++)
                    {
                        valores[i] = context.Delitos.Count(s => s.IdGd == i); //obten el grado del delito
                    }

                    break;

                case 2:

                    for (int i = 1; i < valores.Length; i++)
                    {
                        valores[i] = context.Delitos.Count(s => s.IdCodigo == i); //obten el codigo del delito o delitos especificos
                    }

                    break;

            }


            return valores;

        }



        [HttpGet("[action]")]
        public List<Historialdelitomes> GetEstadisticsMonth()
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var list = (from e in context.Historialdelitomes
                        select new Historialdelitomes
                        {

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


        [HttpPost("[action]")]
        public int DeleteCrimes([FromBody] int idCrime)
        {

            var context = HttpContext.RequestServices.GetService(typeof(swpyscContext)) as swpyscContext;

            var found = context.Delitos.Find(idCrime);

            context.Delitos.Attach(found);
            context.Delitos.Remove(found);

            context.SaveChanges();

            return 1;

        }


    }


    public partial class DatasDelitos
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string TipoDelito { get; set; }

    }

}