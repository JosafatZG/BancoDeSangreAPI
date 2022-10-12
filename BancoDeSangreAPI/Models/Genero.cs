using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDeSangreAPI.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string NombreGenero { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
