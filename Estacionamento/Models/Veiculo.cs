using Estacionamento.Enums;

namespace Estacionamento.Models
{
    public class Veiculo : EntityBase
    {
        public Veiculo(string placa, Tipo tipo)
        {
            Id = Guid.NewGuid();
            Placa = placa;
            Tipo = tipo;
        }

        public string Placa { get; set; }
        public Tipo Tipo { get; set; }
    }
}
