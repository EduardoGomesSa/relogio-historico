namespace Relogio.Application.Queries
{
    public class BuscarEvento
    {
        public Int64 Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public string? TempoCalculado { get; set; }
    }
}
