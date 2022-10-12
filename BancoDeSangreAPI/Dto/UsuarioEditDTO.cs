namespace BancoDeSangreAPI.Dto
{
    public class UsuarioEditDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
    }
    public class UsuarioChangePassDTO
    {
        public int Id { get; set; }
        public string Pwd { get; set; }
    }
}
