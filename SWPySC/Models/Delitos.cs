using System;
using System.Collections.Generic;

namespace SWPySC.Models
{
    public partial class Delitos
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public int? Cp { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int? Cantidad { get; set; }
        public int? IdGd { get; set; }
        public int? IdCodigo { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
    }
}
