using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaApp.Entities
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }

        public ICollection<TiendaArticulo> Tiendas { get; set; }
        public ICollection<ClienteArticulo> Clientes { get; set; }
    }
}
