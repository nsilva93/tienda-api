using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaApp.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Para autenticación
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<ClienteArticulo> Compras { get; set; }
    }
}
