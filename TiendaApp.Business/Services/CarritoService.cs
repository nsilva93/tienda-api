using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Data;
using TiendaApp.Data.Repositories;
using TiendaApp.Entities;

namespace TiendaApp.Business.Services
{
    public class CarritoService : ICarritoService
    {
        private readonly TiendaContext _context;
        private readonly IRepository<ClienteArticulo> _clienteArticuloRepo;
        private readonly IRepository<Articulo> _articuloRepo;

        public CarritoService(
            TiendaContext context,
            IRepository<ClienteArticulo> clienteArticuloRepo,
            IRepository<Articulo> articuloRepo)
        {
            _context = context;
            _clienteArticuloRepo = clienteArticuloRepo;
            _articuloRepo = articuloRepo;
        }

        public async Task<bool> AddToCartAsync(int clienteId, int articuloId)
        {
            var articulo = await _articuloRepo.GetByIdAsync(articuloId);
            if (articulo == null) return false;

            var entity = new ClienteArticulo
            {
                ClienteId = clienteId,
                ArticuloId = articuloId,
                Fecha = DateTime.Now
            };

            await _clienteArticuloRepo.AddAsync(entity);
            return true;
        }

        public async Task<bool> RemoveFromCartAsync(int clienteId, int articuloId)
        {
            var cart = await _clienteArticuloRepo.GetAllAsync();
            var item = cart.FirstOrDefault(c =>
                c.ClienteId == clienteId &&
                c.ArticuloId == articuloId);

            if (item == null) return false;

            return await _clienteArticuloRepo.DeleteAsync(item.Id);
        }

        public async Task<IEnumerable<object>> GetCartAsync(int clienteId)
        {
            return await _context.ClienteArticulos
                .Where(c => c.ClienteId == clienteId)
                .Include(c => c.Articulo)
                .Select(c => new
                {
                    id = c.Id,
                    articuloId = c.ArticuloId,
                    fecha = c.Fecha,
                    articulo = new
                    {
                        codigo = c.Articulo.Codigo,
                        descripcion = c.Articulo.Descripcion,
                        precio = c.Articulo.Precio,
                        stock = c.Articulo.Stock,
                        imagen = c.Articulo.Imagen
                    }
                })
                .ToListAsync();
        }

    }
}