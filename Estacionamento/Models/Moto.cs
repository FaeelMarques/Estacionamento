using Estacionamento.Enums;

namespace Estacionamento.Models
{
    public class Moto : Veiculo
    {
        public Moto(string placa) : base(placa, Tipo.Moto)
        {
        }
    }
}
