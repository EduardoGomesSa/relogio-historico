namespace Relogio.Infra.Interfaces
{
    public interface IContadorService
    {
        string CalcularTempoEmDias(DateTime dateTime);
        string CalcularTempoEmMeses(DateTime dateTime);
        string CalcularTempoEmAnos(DateTime dateTime);
    }
}
