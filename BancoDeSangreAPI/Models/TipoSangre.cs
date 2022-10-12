using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDeSangreAPI.Models
{
    public class TipoSangre
    {
        public int Id { get; set; }
        public string NombreTS { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
