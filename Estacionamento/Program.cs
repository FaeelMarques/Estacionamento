using Estacionamento.Enums;
using Estacionamento.Extensions;
using Estacionamento.Models;
using Estacionamento.Services;

class Program
{
    static void Main(string[] args)
    {
        SistemaPrincipal();
    }

    private static void SistemaPrincipal()
    {
        Console.WriteLine("Bem vindo!");

        Thread.Sleep(3000);

        Console.WriteLine("\nInforme a quantidade de vagas para motos:");

        int totalVagasMoto = int.Parse(Console.ReadLine());

        Console.WriteLine("\nInforme a quantidade de vagas para carros:");

        int totalVagasCarro = int.Parse(Console.ReadLine());

        Console.WriteLine("\nInforme a quantidade de vagas para vans:");

        int totalVagasVan = int.Parse(Console.ReadLine());

        List<Vaga> vagas = VagasService.InsereVagasEstacionamento(totalVagasMoto, totalVagasCarro, totalVagasVan);


        bool exibeMainMenu = true;

        while (exibeMainMenu)
        {
            exibeMainMenu = MenuPrincipal(vagas);
        }
    }

    private static bool MenuPrincipal(List<Vaga> vagas)
    {
        ConsoleExtensions.MenuPrincipal();

        bool estacionamentoVazio = !vagas.Any(v => v.Veiculo != null);
        bool estacionamentoCheio = !vagas.Any(v => v.Veiculo == null);

        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                if (estacionamentoCheio)
                {
                    Console.WriteLine("\n O estacionamento está lotado!\n");
                    Thread.Sleep(2000);
                }
                else
                {
                    InsereVeiculo(vagas);
                }
                return true;

            case 2:
                if (estacionamentoVazio)
                {
                    Console.WriteLine("\nNão há veículos no estacionamento!\n");
                    Thread.Sleep(2000);
                }
                else
                {
                    RemoveVeiculo(vagas);
                }
                return true;

            case 3:
                VagasService.ImprimeVagasRestantes(vagas);
                Thread.Sleep(2000);
                return true;

            case 4:
                Console.WriteLine("\nTotal de vagas do estacionamento: " + vagas.Count + "\n");
                Thread.Sleep(2000);
                return true;

            case 5:
            default:
                Console.ReadKey();
                return false;
        }
    }

    private static void RemoveVeiculo()
    {
        ConsoleExtensions.ExibeMenuOpçõesVeiculo();

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                RemoverVeiculo();
                Thread.Sleep(3000);
                MenuPrincipal();
                break;

            case 2:
                RemoverVeiculo();
                Thread.Sleep(3000);
                MenuPrincipal();
                break;

            case 3:
                RemoverVeiculo();
                Thread.Sleep(3000);
                MenuPrincipal();
                break;

            case 4:
            default:
                MenuPrincipal();
                break;
        }
    }

    private static void RemoverVeiculo()
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

    private static void InsereVeiculo(List<Vaga> vagas)
    {
        ConsoleExtensions.ExibeMenuOpçõesVeiculo();

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                InserirVeiculo(Tipo.Moto);
                Thread.Sleep(3000);
                MenuPrincipal();
                break;

            case 2:
                InserirVeiculo(Tipo.Carro);
                Thread.Sleep(3000);
                MenuPrincipal();
                break;

            case 3:
                InserirVeiculo(Tipo.Van);
                Thread.Sleep(3000);
                MenuPrincipal();
                break;

            default:
                MenuPrincipal();
                break;
        }

    }

   

    private static void InserirVeiculo(Tipo tipo)
    {
        Console.WriteLine("\nInforme a placa do veículo: \n");

        string placa = Console.ReadLine();

        switch (tipo)
        {
            case Tipo.Moto:
                InserirMoto(placa);
                break;
            case Tipo.Carro:
                InserirCarro(placa);
                break;
            case Tipo.Van:
                InserirVan(placa);
                break;

            default:
                break;
        }
    }

    private static void InserirMoto(string placa)
    {
        Moto moto = new(placa);

        if (vagas.Any(m => m.Tipo == Tipo.Moto && m.Veiculo == null))
        {

            Vaga vagaDisponivel = vagas.First(v => v.Tipo == Tipo.Moto && v.Veiculo == null);
            vagaDisponivel.Veiculo = moto;
            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }

        else if (vagas.Any(m => m.Tipo == Tipo.Carro && m.Veiculo == null))
        {
            Vaga vagaDisponivel = vagas.First(v => v.Tipo == Tipo.Carro && v.Veiculo == null);
            vagaDisponivel.Veiculo = moto;
            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }

        else if (vagas.Any(m => m.Tipo == Tipo.Van && m.Veiculo == null))
        {
            Vaga vagaDisponivel = vagas.First(v => v.Tipo == Tipo.Van && v.Veiculo == null);
            vagaDisponivel.Veiculo = moto;
            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }
        else
        {
            Console.WriteLine("\nNão há vagas para o veículo no momento!\n");
        }
    }

    private static void InserirCarro(string placa)
    {
        Carro carro = new(placa);

        if (vagas.Any(m => m.Tipo == Tipo.Carro && m.Veiculo == null))
        {
            Vaga vagaDisponivel = vagas.First(v => v.Tipo == Tipo.Carro && v.Veiculo == null);
            vagaDisponivel.Veiculo = carro;
            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }

        else if (vagas.Any(m => m.Tipo == Tipo.Van && m.Veiculo == null))
        {
            Vaga vagaDisponivel = vagas.First(v => v.Tipo == Tipo.Van && v.Veiculo == null);
            vagaDisponivel.Veiculo = carro;
            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }
        else
        {
            Console.WriteLine("\nNão há vagas para o veículo no momento!\n");
        }
    }

    private static void InserirVan(string placa)
    {
        Van van = new(placa);

        if (vagas.Any(m => m.Tipo == Tipo.Van && m.Veiculo == null))
        {
            Vaga vagaDisponivel = vagas.First(v => v.Tipo == Tipo.Van && v.Veiculo == null);
            vagaDisponivel.Veiculo = van;
            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }

        else if (vagas.Count(m => m.Tipo == Tipo.Carro && m.Veiculo == null) >= 3)
        {
            List<Vaga> vagasDisponiveis = vagas.Where(v => v.Tipo == Tipo.Carro && v.Veiculo == null).Take(3).ToList();
            foreach (var vaga in vagasDisponiveis)
            {
                vaga.Veiculo = van;
            }

            Console.WriteLine("\nVeículo inserido com sucesso!\n");
        }
        else
        {
            Console.WriteLine("\nNão há vagas para o veículo no momento!\n");
        }
    }

   
}