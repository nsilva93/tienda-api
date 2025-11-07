using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaApp.Entities;

namespace TiendaApp.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<TiendaArticulo> TiendaArticulos { get; set; }
        public DbSet<ClienteArticulo> ClienteArticulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TiendaArticulo>()
                .HasOne(x => x.Tienda)
                .WithMany(t => t.Articulos)
                .HasForeignKey(x => x.TiendaId);

            modelBuilder.Entity<TiendaArticulo>()
                .HasOne(x => x.Articulo)
                .WithMany(a => a.Tiendas)
                .HasForeignKey(x => x.ArticuloId);

            modelBuilder.Entity<ClienteArticulo>()
                .HasOne(x => x.Cliente)
                .WithMany(c => c.Compras)
                .HasForeignKey(x => x.ClienteId);

            modelBuilder.Entity<ClienteArticulo>()
                .HasOne(x => x.Articulo)
                .WithMany(a => a.Clientes)
                .HasForeignKey(x => x.ArticuloId);
        }
    }
}
