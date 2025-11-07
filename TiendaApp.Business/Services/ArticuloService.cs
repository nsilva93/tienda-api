using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Data.Repositories;
using TiendaApp.Entities;

namespace TiendaApp.Business.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly IRepository<Articulo> _repository;

        public ArticuloService(IRepository<Articulo> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Articulo>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Articulo> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<Articulo> CreateAsync(Articulo entity) => _repository.AddAsync(entity);

        public async Task<bool> UpdateAsync(int id, Articulo entity)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return false;

            existing.Codigo = entity.Codigo;
            existing.Descripcion = entity.Descripcion;
            existing.Precio = entity.Precio;
            existing.Imagen = entity.Imagen;
            existing.Stock = entity.Stock;

            return await _repository.UpdateAsync(existing);
        }

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);

    }
}
