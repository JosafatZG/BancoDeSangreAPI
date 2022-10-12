using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDeSangreAPI.Models
{
    public class Bolsas
    {
        public int Id { get; set; }
        public virtual TipoBolsa TipoBolsa { get; set; }
        public int Cantidadml { get; set; }
        public virtual Paciente Donante { get; set; }
        public virtual Paciente Receptor { get; set; }
        //public Paciente DonanteId { get; set; }
        //public Paciente ReceptorId { get; set; }
        public DateTime FechaDonacion { get; set; }
        public DateTime FechaAplicacion { get; set; }
    }
}
