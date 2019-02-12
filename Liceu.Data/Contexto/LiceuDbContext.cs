using Liceu.Dados.Mapeamentos;
using Liceu.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Liceu.Dados.Contexto
{
    public class LiceuDbContext : DbContext
    {
        public LiceuDbContext(DbContextOptions<LiceuDbContext> options) : base(options)
        { }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LivroMapeamento());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=liceu_db;Persist Security Info=True;User ID=sa;Password=Marcos@mota#1930");
        }
    }
}
