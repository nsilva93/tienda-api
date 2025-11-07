using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Data.Repositories;
using TiendaApp.Entities;

namespace TiendaApp.Business.Services
{
    public class TiendaService : ITiendaService
    {
        private readonly IRepository<Tienda> _repository;

        public TiendaService(IRepository<Tienda> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Tienda>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Tienda> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<Tienda> CreateAsync(Tienda entity) => _repository.AddAsync(entity);

        public async Task<bool> UpdateAsync(int id, Tienda entity)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Sucursal = entity.Sucursal;
            existing.Direccion = entity.Direccion;

            return await _repository.UpdateAsync(existing);
        }

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
