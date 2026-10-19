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
            _service.LimparTodas(); 
        }

        [Fact]
        public void CadastrarNota_DeveAdicionarENotificarSucesso()
        {
            var dto = new CriarNotaFiscalDto
            {
                NumeroNota = "1001",
                Cliente = "Empresa Teste",
                Valor = 1500.50m,
                DataEmissao = DateTime.Today
            };

            var resultado = _service.Cadastrar(dto);

            Assert.NotNull(resultado);
            var notas = _service.ListarTodas();
            Assert.NotEmpty(notas);
        }

        [Fact]
        public void ObterTodas_DeveRetornarListaDeNotas()
        {
            var dto = new CriarNotaFiscalDto
            {
                NumeroNota = "1002",
                Cliente = "Cliente ABC",
                Valor = 200.00m,
                DataEmissao = DateTime.Today
            };
            _service.Cadastrar(dto);

            var notas = _service.ListarTodas();

            Assert.NotNull(notas);
            Assert.NotEmpty(notas);
        }

        [Fact]
        public void LimparTodas_DeveEsvaziarListaDeNotas()
        {
            var dto = new CriarNotaFiscalDto
            {
                NumeroNota = "1003",
                Cliente = "Cliente Para Limpar",
                Valor = 50.00m,
                DataEmissao = DateTime.Today
            };
            _service.Cadastrar(dto);

            _service.LimparTodas();
            var notas = _service.ListarTodas();

            Assert.Empty(notas);
        }
    }
}