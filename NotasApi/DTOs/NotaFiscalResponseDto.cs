namespace NotasApi.DTOs
{
    public class NotaFiscalResponseDto
    {
        public string NumeroNota { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string ValorFormatado { get; set; } = string.Empty;
        public string DataEmissao { get; set; } = string.Empty;
        public string DataHoraCadastro { get; set; } = string.Empty;
    }
}