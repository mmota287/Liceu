using Liceu.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liceu.Dados.Mapeamentos
{
    public class LivroMapeamento : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("GE_LIVRO");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Ano)
                .HasColumnName("ANO_LANCAMENTO")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(p => p.Autor)
                .HasColumnName("NOME_AUTOR")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Titulo)
                .HasColumnName("TITULO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.DataAtualizacao)
                .HasColumnName("DT_ATUALIZACAO")
                .IsRequired();

            builder.Property(p => p.DataAtualizacao)
                .HasColumnName("DT_CRIACAO");

            builder.Property(p => p.Editora)
                .HasColumnName("NOME_EDITORA")
                                .HasMaxLength(50)

                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("STATUS")
                .IsRequired();

        }
    }
}
