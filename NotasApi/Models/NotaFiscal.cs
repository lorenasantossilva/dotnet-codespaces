namespace NotasApi.Models
{
    public class NotaFiscal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NumeroNota { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataHoraCadastro { get; set; } = DateTime.UtcNow;
    }
}