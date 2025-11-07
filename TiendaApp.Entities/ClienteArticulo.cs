using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaApp.Entities
{
    public class ClienteArticulo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; }
        public Articulo Articulo { get; set; }
    }
}
