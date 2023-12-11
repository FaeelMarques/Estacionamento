using Estacionamento.Enums;
using Estacionamento.Extensions;
using Estacionamento.Models;

namespace Estacionamento.Services
{
    public static class VeiculosService
    {
        public static void InserirVeiculo(List<Vaga> vagas)
        {
            ConsoleExtensions.ExibeMenuOpçõesVeiculo();

            string opcao = Console.ReadLine();

            Enum.TryParse(opcao, out Tipo tipoVeiculo);

            switch (tipoVeiculo)
            {
                case Tipo.Moto:
                    InserirMoto(vagas);
                    break;

                case Tipo.Carro:
                    InserirCarro(vagas);
                    break;

                case Tipo.Van:
                    InserirVan(vagas);
                    break;
            }
        }

        private static void InserirMoto(List<Vaga> vagas)
        {
            if (!vagas.Any(m => m.Tipo == Tipo.Moto && m.Veiculo == null ||
                           m.Tipo == Tipo.Carro && m.Veiculo == null ||
                           m.Tipo == Tipo.Van && m.Veiculo == null))
            {
                Console.WriteLine("\nNão há vagas para o veículo no momento!\n");
                return;
            }

            Console.WriteLine("\nInforme a placa do veículo:\n");

            string placa = Console.ReadLine();

            bool veiculoJaEstacionado = ValidaVeiculoJaEstacionado(vagas, placa);

            if (veiculoJaEstacionado)
            {
                Console.WriteLine("\nVeículo já se encontra no estacionamento!\n");
                return;
            }

            Moto moto = new(placa);

            Vaga vagaDisponivel = vagas.First(m => m.Tipo == Tipo.Moto && m.Veiculo == null ||
                                              m.Tipo == Tipo.Carro && m.Veiculo == null ||
                                              m.Tipo == Tipo.Van && m.Veiculo == null);
            vagaDisponivel.Veiculo = moto;
            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }

        private static void InserirCarro(List<Vaga> vagas)
        {

            if (!vagas.Any(m => m.Tipo == Tipo.Carro && m.Veiculo == null ||
                           m.Tipo == Tipo.Van && m.Veiculo == null))
            {
                Console.WriteLine("\nNão há vagas para o veículo no momento!\n");
                return;
            }

            Console.WriteLine("\nInforme a placa do veículo: \n");

            string placa = Console.ReadLine();


            bool veiculoJaEstacionado = ValidaVeiculoJaEstacionado(vagas, placa);

            if (veiculoJaEstacionado)
            {
                Console.WriteLine("\nVeículo já se encontra no estacionamento!\n");
                return;
            }

            Carro carro = new(placa);

            Vaga vagaDisponivel = vagas.First(m=> m.Tipo == Tipo.Carro && m.Veiculo == null ||
                                              m.Tipo == Tipo.Van && m.Veiculo == null);

            vagaDisponivel.Veiculo = carro;
            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }

        private static void InserirVan(List<Vaga> vagas)
        {
            if (!vagas.Any(m => m.Tipo == Tipo.Van && m.Veiculo == null) && vagas.Count(m => m.Tipo == Tipo.Carro && m.Veiculo == null) < 3)
            {
                Console.WriteLine("\nNão há vagas para o veículo no momento!\n");
                return;
            }

            Console.WriteLine("\nInforme a placa do veículo: \n");

            string placa = Console.ReadLine();

            bool veiculoJaEstacionado = ValidaVeiculoJaEstacionado(vagas, placa);

            if (veiculoJaEstacionado)
            {
                Console.WriteLine("\nVeículo já se encontra no estacionamento!\n");
                return;
            }

            Van van = new(placa);

            if (vagas.Any(m => m.Tipo == Tipo.Van && m.Veiculo == null))
            {
                Vaga vagaDisponivel = vagas.First(v => v.Tipo == Tipo.Van && v.Veiculo == null);
                vagaDisponivel.Veiculo = van;
                Console.WriteLine("\nVeículo inserido com sucesso!\n");
            }
            else 
            {
                List<Vaga> vagasDisponiveis = vagas.Where(v => v.Tipo == Tipo.Carro && v.Veiculo == null).Take(3).ToList();
                foreach (var vaga in vagasDisponiveis)
                {
                    vaga.Veiculo = van;
                }

                Console.WriteLine("\nVeículo inserido com sucesso!\n");
            }
           
        }

        public static void RemoverVeiculo(List<Vaga> vagas)
        {
            Console.WriteLine("\n Informe a placa do veículo: \n");

            string placa = Console.ReadLine();

            List<Vaga> liberarVagas = vagas.Where(v => v.Veiculo?.Placa == placa).ToList();

            if (liberarVagas.Any())
            {
                foreach (var vaga in liberarVagas)
                {
                    vaga.Veiculo = null;
                }

                Console.WriteLine("\nVeículo removido com sucesso!\n");
            }
            else
            {
                Console.WriteLine("\nVeículo não foi encontrado no estacionamento!\n");
            }
        }

        private static bool ValidaVeiculoJaEstacionado(List<Vaga> vagas, string placa)
        {
            if(vagas.Any(v => v.Veiculo?.Placa == placa))
            {
                return true;
            }
            return false;
        }
    }
}
