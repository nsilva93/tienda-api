using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Entities;

namespace TiendaApp.Business.Interfaces
{
    public interface IAuthService
    {
        Task<Cliente> RegisterAsync(Cliente cliente, string password);
        Task<Cliente> LoginAsync(string email, string password);
        string GenerateJwtToken(Cliente cliente);
    }
}
