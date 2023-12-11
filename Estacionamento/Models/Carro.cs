using Estacionamento.Enums;

namespace Estacionamento.Models
{
    public class Carro : Veiculo
    {
        public Carro(string placa) : base(placa, Tipo.Carro)
        {
        }
    }
}
