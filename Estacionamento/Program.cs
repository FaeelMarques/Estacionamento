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
        Console.WriteLine("################################################");
        Console.WriteLine("################################################");
        Console.WriteLine("#                                              #");
        Console.WriteLine("#   Estacionamento Rotativo. Seja bem vindo!   #");
        Console.WriteLine("#                                              #");
        Console.WriteLine("################################################");
        Console.WriteLine("################################################");

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
                    VeiculosService.InserirVeiculo(vagas);
                    Thread.Sleep(2000);
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
                    VeiculosService.RemoverVeiculo(vagas);
                    Thread.Sleep(2000);
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
                return false;
        }
    }
}