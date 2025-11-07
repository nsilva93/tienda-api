using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Entities.DTOs.TiendaArticulo;

namespace TiendaApp.Business.Interfaces
{
    public interface ITiendaArticuloService
    {
        Task<bool> CrearRelacionAsync(CrearTiendaArticuloRequest request);
        Task<IEnumerable<TiendaArticuloResponse>> GetArticulosPorTienda(int tiendaId);
        Task<IEnumerable<TiendaArticuloResponse>> GetTiendasPorArticulo(int articuloId);
        Task<bool> EliminarRelacionAsync(int id);
    }
}
