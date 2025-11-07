using System;

namespace TiendaApp.Entities.DTOs.TiendaArticulo
{
    public class TiendaArticuloResponse
    {
        public int Id { get; set; }
        public int TiendaId { get; set; }
        public string Sucursal { get; set; }
        public int ArticuloId { get; set; }
        public string Articulo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
