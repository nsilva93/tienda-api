namespace TiendaApp.API.Models.Auth
{
    public class RegisterRequest
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
