using System.Collections.Concurrent;
using System.Globalization;
using NotasApi.DTOs;
using NotasApi.Models;

namespace NotasApi.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private static readonly ConcurrentBag<NotaFiscal> _notas = new();
        private static readonly CultureInfo _culturePtBr = new("pt-BR");
        private static readonly TimeZoneInfo _fusoBrasilia = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");

        public NotaFiscalResponseDto Cadastrar(CriarNotaFiscalDto dto)
        {
            var nota = new NotaFiscal
            {
                NumeroNota = dto.NumeroNota,
                Cliente = dto.Cliente,
                Valor = dto.Valor,
                DataEmissao = dto.DataEmissao,
                DataHoraCadastro = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _fusoBrasilia)
            };

            lock (_notas)
            {
                _notas.Add(nota);
            }

            return Mapear(nota);
        }

        public IEnumerable<NotaFiscalResponseDto> ListarTodas()
        {
            lock (_notas)
            {
                return _notas.Select(Mapear).ToList();
            }
        }

        private static NotaFiscalResponseDto Mapear(NotaFiscal nota)
        {
            return new NotaFiscalResponseDto
            {
                NumeroNota = nota.NumeroNota,
                Cliente = nota.Cliente,
                ValorFormatado = nota.Valor.ToString("C", new CultureInfo("pt-BR")),
                DataEmissao = nota.DataEmissao.ToString("dd/MM/yyyy"),
                DataHoraCadastro = nota.DataHoraCadastro.ToString("dd/MM/yyyy HH:mm:ss")
            };
        }
    }
}