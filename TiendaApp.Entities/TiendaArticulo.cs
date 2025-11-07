using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaApp.Entities
{
    public class TiendaArticulo
    {
        public int Id { get; set; }
        public int TiendaId { get; set; }
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; }

        public Tienda Tienda { get; set; }
        public Articulo Articulo { get; set; }
    }
}
