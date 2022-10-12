using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDeSangreAPI.Models
{
    public class TipoBolsa
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        //public virtual ICollection<Bolsas> Bolsas { get; set; }
    }
}
