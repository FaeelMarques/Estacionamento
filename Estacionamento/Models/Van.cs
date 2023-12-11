using Estacionamento.Enums;

namespace Estacionamento.Models
{
    public class Van : Veiculo
    {
        public Van(string placa) : base(placa, Tipo.Van)
        {
        }
    }
}
