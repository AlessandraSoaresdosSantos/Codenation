﻿using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using Codenation.Infra.Data.Context;
using Codenation.Infra.Data.Repository;
using Codenation.Infra.Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using Xunit;

namespace Codenation.Teste.Repositorio
{
    public sealed class VeiculoRepositorioTest
    {
        private readonly Veiculo _veiculo;

        public VeiculoRepositorioTest()
        {
            _veiculo = new Veiculo
            {
                AnoFabricacao = 1998,
                AnoModelo = 1999,
                Cor = "Azul da cor do céu",
                Imagem = "Imagem veiculo Teste em aula",
                MarcaID = 1,
                ModeloID = 1,
                Preco = 34567.89,
                Quilometragem = 45,
                VersaoID = 1
            };

        }

        [Fact]
        public void Adicionar_Veiculo()
        {
            IVeiculoRepository veiculoRepository = GetVeiculoRepository();

            Veiculo veiculo = veiculoRepository.Save(_veiculo);

            Assert.Equal("Azul da cor do céu", veiculo.Cor);
            Assert.Equal("Imagem veiculo Teste em aula", veiculo.Imagem);
            Assert.NotNull(veiculo.VersaoID);
        }

        private IVeiculoRepository GetVeiculoRepository()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Carro;Integrated Security=True");
            options = builder.Options;
            DataContext veiculoDataContext = new DataContext(options);
            return new VeiculoRepository(veiculoDataContext);
        }
    }
}
