using System;

namespace TiendaApp.Entities.DTOs.TiendaArticulo
{
    public class CrearTiendaArticuloRequest
    {
        public int TiendaId { get; set; }
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
