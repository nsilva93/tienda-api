using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Data;
using TiendaApp.Entities;
using TiendaApp.Entities.DTOs.TiendaArticulo;

namespace TiendaApp.Business.Services
{
    public class TiendaArticuloService : ITiendaArticuloService
    {
        private readonly TiendaContext _db;

        public TiendaArticuloService(TiendaContext db)
        {
            _db = db;
        }

        public async Task<bool> CrearRelacionAsync(CrearTiendaArticuloRequest request)
        {
            var exists = await _db.TiendaArticulos
                .AnyAsync(t => t.TiendaId == request.TiendaId &&
                               t.ArticuloId == request.ArticuloId);

            if (exists)
                return true; // ya existe, consideramos OK

            var entity = new TiendaArticulo
            {
                TiendaId = request.TiendaId,
                ArticuloId = request.ArticuloId,
                Fecha = request.Fecha
            };

            _db.TiendaArticulos.Add(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TiendaArticuloResponse>> GetArticulosPorTienda(int tiendaId)
        {
            return await _db.TiendaArticulos
                .Where(x => x.TiendaId == tiendaId)
                .Include(x => x.Articulo)
                .Include(x => x.Tienda)
                .Select(x => new TiendaArticuloResponse
                {
                    Id = x.Id,
                    TiendaId = x.TiendaId,
                    Sucursal = x.Tienda.Sucursal,
                    ArticuloId = x.ArticuloId,
                    Articulo = x.Articulo.Descripcion,
                    Fecha = x.Fecha
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TiendaArticuloResponse>> GetTiendasPorArticulo(int articuloId)
        {
            return await _db.TiendaArticulos
                .Where(x => x.ArticuloId == articuloId)
                .Include(x => x.Tienda)
                .Include(x => x.Articulo)
                .Select(x => new TiendaArticuloResponse
                {
                    Id = x.Id,
                    TiendaId = x.TiendaId,
                    Sucursal = x.Tienda.Sucursal,
                    ArticuloId = x.ArticuloId,
                    Articulo = x.Articulo.Descripcion,
                    Fecha = x.Fecha
                })
                .ToListAsync();
        }

        public async Task<bool> EliminarRelacionAsync(int id)
        {
            var entity = await _db.TiendaArticulos.FindAsync(id);

            if (entity == null)
                return false;

            _db.TiendaArticulos.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
