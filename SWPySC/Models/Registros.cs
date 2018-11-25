using System;
using System.Collections.Generic;

namespace SWPySC.Models
{
    public partial class Registros
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdEstatus { get; set; }
    }
}
