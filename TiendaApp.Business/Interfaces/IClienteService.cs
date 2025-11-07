using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Entities;

namespace TiendaApp.Business.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente entity);
        Task<bool> UpdateAsync(int id, Cliente entity);
        Task<bool> DeleteAsync(int id);
    }
}
