using BancoDeSangreAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace BancoDeSangreAPI.Dto
{
    public class PacienteDTO
    {
            public int Id { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public DateTime FechaNac { get; set; }
            public int GeneroId { get; set; }
            public int Edad { get; set; }
            public int TipoSangreId { get; set; }
            public int TipoRHId { get; set; }
    }
}
