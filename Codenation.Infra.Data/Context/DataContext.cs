using Codenation.Dominio.Entidades;
using Codenation.Infra.Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace Codenation.Infra.Data.Context
{
    public sealed class DataContext : DbContext, IDisposable
    {

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Versao> Versoes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
         
         public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
          

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>()
            .ToTable("Marca");

            modelBuilder.Entity<Marca>()
                        .Property(c => c.Nome)
                        .IsRequired() //obrigatoriedade
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Nome"); //nome da coluna

            base.OnModelCreating(modelBuilder);

            //Criação tabela Versao
            modelBuilder.Entity<Versao>()
             .ToTable("Versao");

            modelBuilder.Entity<Versao>()
                .Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)")
                .HasColumnName("Nome");

            base.OnModelCreating(modelBuilder);
            //Fim

            //Criação da tabela Veiculo
            modelBuilder.Entity<Veiculo>()
                .ToTable("Veiculo");

            modelBuilder.Entity<Veiculo>()
                .Property(c => c.Imagem)
                .IsRequired()
                .HasColumnType("varchar(500)")
                .HasColumnName("Imagem");

            modelBuilder.Entity<Veiculo>()
               .Property(c => c.Quilometragem)
               .IsRequired()
               .HasColumnType("int")
               .HasColumnName("Quilometragem");

            modelBuilder.Entity<Veiculo>()
               .Property(c => c.Preco)
               .IsRequired()
               .HasColumnType("float")
               .HasColumnName("Preco");


            modelBuilder.Entity<Veiculo>()
              .Property(c => c.AnoModelo)
              .IsRequired()
              .HasColumnType("int")
              .HasColumnName("AnoModelo");

            modelBuilder.Entity<Veiculo>()
                         .Property(c => c.AnoFabricacao)
                         .IsRequired()
                         .HasColumnType("int")
                         .HasColumnName("AnoFabricacao");

            modelBuilder.Entity<Veiculo>()
               .Property(c => c.Cor)
               .IsRequired()
               .HasColumnType("varchar(500)")
               .HasColumnName("Cor");

            base.OnModelCreating(modelBuilder);
            //Fim

            //Criação da tabela Carro
            modelBuilder.Entity<Carro>()
                .ToTable("Carro");

            modelBuilder.Entity<Carro>()
                .Property(c => c.Ano)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Ano");

            modelBuilder.Entity<Carro>()
              .Property(c => c.Quilometragem)
              .IsRequired()
              .HasColumnType("int")
              .HasColumnName("Quilometragem");

            modelBuilder.Entity<Carro>()
             .Property(c => c.Observacao)
             .IsRequired()
             .HasColumnType("varchar(250)")
             .HasColumnName("Observacao");

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Carro;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}