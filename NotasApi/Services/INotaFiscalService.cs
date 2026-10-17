using NotasApi.DTOs;

namespace NotasApi.Services
{
    public interface INotaFiscalService
    {
        NotaFiscalResponseDto Cadastrar(CriarNotaFiscalDto dto);
        IEnumerable<NotaFiscalResponseDto> ListarTodas();
    }
}