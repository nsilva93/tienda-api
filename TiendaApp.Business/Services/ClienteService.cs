using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Data.Repositories;
using TiendaApp.Entities;

namespace TiendaApp.Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> _repository;

        public ClienteService(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Cliente>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Cliente> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<Cliente> CreateAsync(Cliente entity) => _repository.AddAsync(entity);

        public async Task<bool> UpdateAsync(int id, Cliente entity)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Nombre = entity.Nombre;
            existing.Apellidos = entity.Apellidos;
            existing.Direccion = entity.Direccion;

            return await _repository.UpdateAsync(existing);
        }

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
