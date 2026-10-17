using System.Globalization;
using NotasApi.DTOs;
using NotasApi.Models;

namespace NotasApi.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private static readonly List<NotaFiscal> _notas = new();

        public NotaFiscalResponseDto Cadastrar(CriarNotaFiscalDto dto)
        {
            var nota = new NotaFiscal
            {
                NumeroNota = dto.NumeroNota,
                Cliente = dto.Cliente,
                Valor = dto.Valor,
                DataEmissao = dto.DataEmissao
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