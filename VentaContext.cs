using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSoftware
{
    class VentaContext : DbContext
    {
        private DbSet<Cliente> clientes;
        private DbSet<Venta> venta;
        private DbSet<Producto> productos;

        public DbSet<Cliente> Clientes { get => clientes; set => clientes = value; }
        public DbSet<Producto> Productos { get => productos; set => productos = value; }
        internal DbSet<Venta> Venta { get => venta; set => venta = value; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=PCGRANDE\DESARROLLO;Database=Venta;Trusted_Connection=True;");
        }
    }
}
