using Shindi.LeilaoOnline.Core;
using System;

namespace Shindi.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void CompararValores(double esperado, double obtido)
        {
            var corPadrao = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("O teste está OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Falho no teste. esperado:{esperado}, obtido:{obtido}");
            }
            Console.ForegroundColor = corPadrao;

        }

        private static void LeilaoComVariosLances()
        {
            // Arranje - cenário de entrada
            var leilao = new Leilao("Jogos");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);

            leilao.RecebeLance(maria, 990);

            // Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            CompararValores(valorEsperado, valorObtido);
        }

        private static void LeilaoComUmLance()
        {
            // Arranje - cenário de entrada
            var leilao = new Leilao("Jogos");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);

            // Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            CompararValores(valorEsperado, valorObtido);
        }

        static void Main(string[] args)
        {

            LeilaoComVariosLances();
            LeilaoComUmLance();
            Console.Read();
        }

       
    }
}
