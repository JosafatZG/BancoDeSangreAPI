using System.Collections.Generic;

namespace BancoDeSangreAPI.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Pwd { get; set; }
        public string CodigoRecuperacion { get; set; }
    }
}