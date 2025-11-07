using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaApp.Entities
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        public ICollection<TiendaArticulo> Articulos { get; set; }
    }
}
