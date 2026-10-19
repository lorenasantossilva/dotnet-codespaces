using System;
using System.Linq;
using NotasApi.DTOs;
using NotasApi.Services;
using Xunit;

namespace NotasApi.Tests
{
    public class NotaFiscalServiceTests
    {
        private readonly NotaFiscalService _service;

        public NotaFiscalServiceTests()
        {
            _service = new NotaFiscalService();
        }

        [Fact]
        public void CadastrarNota_DeveAdicionarENotificarSucesso()
        {
            var dto = new CriarNotaFiscalDto
            {
                NumeroNota = "NF-001",
                Cliente = "Empresa Teste",
                Valor = 1500.50m,
                DataEmissao = DateTime.Today
            };

            var resultado = _service.Cadastrar(dto);

            Assert.NotNull(resultado);
            Assert.Equal("NF-001", resultado.NumeroNota);
            Assert.Equal("Empresa Teste", resultado.Cliente);
        }

        [Fact]
        public void ObterTodas_DeveRetornarListaDeNotas()
        {
            // Arrange
            var dto = new CriarNotaFiscalDto
            {
                NumeroNota = "NF-002",
                Cliente = "Cliente ABC",
                Valor = 200.00m,
                DataEmissao = DateTime.Today
            };
            _service.Cadastrar(dto);

            var notas = _service.ListarTodas();

            Assert.NotNull(notas);
            Assert.NotEmpty(notas);
            Assert.Contains(notas, n => n.NumeroNota == "NF-002");
        }
    }
}