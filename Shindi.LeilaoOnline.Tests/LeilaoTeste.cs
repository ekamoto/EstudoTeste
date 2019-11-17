using System;
using System.Collections.Generic;
using System.Text;
using Shindi.LeilaoOnline.Core;
using Xunit;

namespace Shindi.LeilaoOnline.Tests
{
    public class LeilaoTeste
    {
        [Fact]
        public void LeilaoComVariosLances()
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

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComUmLance()
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

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
