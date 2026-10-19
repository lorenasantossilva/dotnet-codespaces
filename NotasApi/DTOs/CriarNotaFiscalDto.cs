namespace NotasApi.DTOs
{
    public class CriarNotaFiscalDto
    {
        public string NumeroNota { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataEmissao { get; set; }   
    }
}