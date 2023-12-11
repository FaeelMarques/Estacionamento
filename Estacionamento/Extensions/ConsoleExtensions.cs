namespace Estacionamento.Extensions
{
    public static class ConsoleExtensions
    {

        public static void MenuPrincipal()
        {
            Console.WriteLine("\nO que gostaria de fazer agora? Selecione uma Opção:\n");
            Console.WriteLine("1 - Estacionar Veículo \n");
            Console.WriteLine("2 - Retirar Veículo \n");
            Console.WriteLine("3 - Vagas Restantes \n");
            Console.WriteLine("4 - Total de vagas no estacionamento \n");
            Console.WriteLine("5 - Sair \n");
        }

        public static void ExibeMenuOpçõesVeiculo()
        {
            Console.WriteLine("\nInforme o tipo do veículo:\n");
            Console.WriteLine("1 - Moto \n");
            Console.WriteLine("2 - Carro \n");
            Console.WriteLine("3 - Van \n");
            Console.WriteLine("4 - Voltar ao menu anterior \n");
        }
    }
}
