using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsArena.Entities.Models
{
    public class Patrocinador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public decimal MontoInversion { get; set; }
        public string EmailContacto { get; set; }
        public string Estado { get; set; }
    }
}
