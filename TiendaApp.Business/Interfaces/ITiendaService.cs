using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Entities;

namespace TiendaApp.Business.Interfaces
{
    public interface ITiendaService
    {
        Task<IEnumerable<Tienda>> GetAllAsync();
        Task<Tienda> GetByIdAsync(int id);
        Task<Tienda> CreateAsync(Tienda entity);
        Task<bool> UpdateAsync(int id, Tienda entity);
        Task<bool> DeleteAsync(int id);
    }
}
