using System;
using System.Collections.Generic;

namespace SWPySC.Models
{
    public partial class Historialusuarios
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public TimeSpan? Hora { get; set; }
        public DateTime? Dia { get; set; }
        public int? IdAccion { get; set; }
    }
}
