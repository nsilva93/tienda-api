using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Entities;

namespace TiendaApp.Business.Interfaces
{
    public interface IArticuloService
    {
        Task<IEnumerable<Articulo>> GetAllAsync();
        Task<Articulo> GetByIdAsync(int id);
        Task<Articulo> CreateAsync(Articulo entity);
        Task<bool> UpdateAsync(int id, Articulo entity);
        Task<bool> DeleteAsync(int id);
    }
}
