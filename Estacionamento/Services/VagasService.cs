using Estacionamento.Enums;
using Estacionamento.Models;

namespace Estacionamento.Services
{
    public static class VagasService
    {
        public static List<Vaga> InsereVagasEstacionamento(int totalVagasMoto, int totalVagasCarro, int totalVagasVan)
        {
            List<Vaga> vagas = new();

            for (int i = 0; i < totalVagasMoto; i++)
            {
                Vaga vagaMoto = new(Tipo.Moto);
                vagas.Add(vagaMoto);
            }

            for (int i = 0; i < totalVagasCarro; i++)
            {
                Vaga vagaCarro = new(Tipo.Carro);
                vagas.Add(vagaCarro);
            }

            for (int i = 0; i < totalVagasVan; i++)
            {
                Vaga vagaVan = new(Tipo.Van);
                vagas.Add(vagaVan);
            }

            return vagas;
        }

        public static void ImprimeVagasRestantes(List<Vaga> vagas)
        {
            int vagasMotoRestantes = vagas.Count(m => m.Tipo == Tipo.Moto && m.Veiculo == null);

            int vagasCarroRestantes = vagas.Count(c => c.Tipo == Tipo.Carro && c.Veiculo == null);

            int vagasVanRestantes = vagas.Count(v => v.Tipo == Tipo.Van && v.Veiculo == null);

            Console.WriteLine("\nNo momento, há " + vagasMotoRestantes + " vaga(s) para motos, " +
                  vagasCarroRestantes + " vaga(s) para carros, e " + vagasVanRestantes + " vaga(s) para vans.\n");
        }
    }
}
