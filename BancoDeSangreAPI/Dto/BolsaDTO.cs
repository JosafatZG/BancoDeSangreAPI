using BancoDeSangreAPI.Models;
using System;

namespace BancoDeSangreAPI.Dto
{
    public class BolsaDTO
    {
        public int Id { get; set; }
        public int TipoBolsaId { get; set; }
        public int Cantidadml { get; set; }
        public int DonanteId { get; set; }
        public int ReceptorId { get; set; }
        public DateTime FechaDonacion { get; set; }
        public DateTime FechaAplicacion { get; set; }
    }
}
