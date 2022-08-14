using System;

namespace Relogio.Infra.Entidades
{
    public class Contador
    {
        public Contador()
        {

        }

        public Contador(long id, string nome, string descricao, DateTime dataEvento)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataEvento = dataEvento;
        }

        public Int64 Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataEvento { get; private set; }
    }
}
