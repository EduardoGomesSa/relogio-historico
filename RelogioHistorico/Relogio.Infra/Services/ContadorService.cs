using Relogio.Infra.Interfaces;

namespace Relogio.Infra.Services
{
    public class ContadorService : IContadorService
    {
        public string CalcularTempoEmAnos(DateTime dateTime)
        {
            var tempo = 0;

            if (dateTime < DateTime.Now)
            {
                tempo = (int)(DateTime.Now - dateTime).TotalDays / 365;

                return "Se passaram " + tempo.ToString() + " anos";
            }
            else
            {
                tempo = (int)(dateTime - DateTime.Now).TotalDays / 365;

                return "Faltam " + tempo.ToString() + " anos";
            }
        }

        public string CalcularTempoEmDias(DateTime dateTime)
        {
            var tempo = 0;

            if(dateTime < DateTime.Now)
            {
                tempo = (int)(DateTime.Now - dateTime).TotalDays;
                return "Se passaram "+tempo.ToString() + " dias";
            }
            else
            {
                tempo = (int)(dateTime - DateTime.Now).TotalDays;
                return "Faltam " + tempo.ToString() + " dias";
            }
        }

        public string CalcularTempoEmMeses(DateTime dateTime)
        {
            var tempo = 0;

            if (dateTime < DateTime.Now)
            {
                tempo = (int)(DateTime.Now - dateTime).TotalDays / 30;
                return "Se passaram " + tempo.ToString() + " meses";
            }
            else
            {
                tempo = (int)(dateTime - DateTime.Now).TotalDays / 30;
                return "Faltam " + tempo.ToString() + " meses";
            }
        }
    }
}