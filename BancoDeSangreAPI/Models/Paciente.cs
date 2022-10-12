using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }
        public int Edad { get; set; }
        [ForeignKey("GeneroId")]
        public virtual TipoSangre TipoSangre { get; set; }
        [ForeignKey("GeneroId")]
        public virtual TipoRH TipoRH { get; set; }
        //public virtual ICollection<Bolsas> Bolsas { get; set; }
    }
}
