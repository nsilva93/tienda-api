using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Data.Repositories;
using TiendaApp.Entities;

namespace TiendaApp.Business.Services
{
    public class CarritoService : ICarritoService
    {
        private readonly IRepository<ClienteArticulo> _clienteArticuloRepo;
        private readonly IRepository<Articulo> _articuloRepo;

        public CarritoService(
            IRepository<ClienteArticulo> clienteArticuloRepo,
            IRepository<Articulo> articuloRepo)
        {
            _clienteArticuloRepo = clienteArticuloRepo;
            _articuloRepo = articuloRepo;
        }

        public async Task<bool> AddToCartAsync(int clienteId, int articuloId)
        {
            // Validar que el artículo existe
            var articulo = await _articuloRepo.GetByIdAsync(articuloId);
            if (articulo == null) return false;

            var entity = new ClienteArticulo
            {
                ClienteId = clienteId,
                ArticuloId = articuloId,
                Fecha = System.DateTime.Now
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

        public async Task<IEnumerable<ClienteArticulo>> GetCartAsync(int clienteId)
        {
            var cart = await _clienteArticuloRepo.GetAllAsync();
            return cart.Where(c => c.ClienteId == clienteId).ToList();
        }
    }
}