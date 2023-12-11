using Estacionamento.Enums;

namespace Estacionamento.Models
{
    public class Vaga : EntityBase
    {

        public Vaga(Tipo tipo)
        {
            Id = Guid.NewGuid();
            Tipo = tipo;
        }

        public Tipo Tipo { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
