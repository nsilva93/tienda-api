using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Data.Repositories;
using TiendaApp.Entities;

namespace TiendaApp.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<Cliente> _repository;
        private readonly IConfiguration _config;

        public AuthService(IRepository<Cliente> repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        public async Task<Cliente> RegisterAsync(Cliente cliente, string password)
        {
            cliente.PasswordHash = HashPassword(password);
            return await _repository.AddAsync(cliente);
        }

        public async Task<Cliente> LoginAsync(string email, string password)
        {
            var clientes = await _repository.GetAllAsync();
            var cliente = clientes.FirstOrDefault(c => c.Email == email);

            if (cliente == null) return null;

            if (!VerifyPassword(password, cliente.PasswordHash))
                return null;

            return cliente;
        }

        public string GenerateJwtToken(Cliente cliente)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, cliente.Id.ToString()),
                new Claim("email", cliente.Email),
                new Claim("nombre", cliente.Nombre),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Hash de contraseña
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }
    }
}
