using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDeSangreAPI.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public virtual Genero Genero { get; set; }
        public int Edad { get; set; }
        public virtual TipoSangre TipoSangre { get; set; }
        public virtual TipoRH TipoRH { get; set; }
        //public virtual ICollection<Bolsas> Bolsas { get; set; }
    }
}
