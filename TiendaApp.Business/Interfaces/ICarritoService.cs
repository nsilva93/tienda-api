using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Entities;

namespace TiendaApp.Business.Interfaces
{
    public interface ICarritoService
    {
        Task<bool> AddToCartAsync(int clienteId, int articuloId);
        Task<bool> RemoveFromCartAsync(int clienteId, int articuloId);
        Task<IEnumerable<ClienteArticulo>> GetCartAsync(int clienteId);
    }
}
