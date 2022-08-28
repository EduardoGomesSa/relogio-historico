using DapperExtensions.Mapper;
using Relogio.Infra.Entidades;

namespace Relogio.Infra.Repositorios.Maps
{
    public class ContadorMap : ClassMapper<Contador>
    {
        public ContadorMap()
        {
            Schema("cadastro");
            Table("evento");

            Map(c => c.Id)
                .Column("id")
                .Key(KeyType.Identity);

            Map(c => c.Nome)
                .Column("nome");

            Map(c => c.Descricao)
                .Column("descricao");

            Map(c => c.DataEvento)
                .Column("data_evento");

            AutoMap();
        }
    }
}
