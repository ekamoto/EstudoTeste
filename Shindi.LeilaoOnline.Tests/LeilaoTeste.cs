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
            // give when then
            // Arrange Act Assert
            // Arranje - cenário de entrada
            // Dado(give) leilão com 2 clientes sendo que fulado deu dois Lances, um de 800 e outro de 1000
            // e maria deu um lance 900
            var leilao = new Leilao("Jogos");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);

            leilao.RecebeLance(maria, 990);

            // Act - método sob teste
            // Quando o leilão/pregão termina
            leilao.TerminaPregao();

            // Assert
            // Então o valor esperado é o maior valor, no caso é 100
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

        [Fact]
        public void VerificaClienteGanhador()
        {

            var leilao = new Leilao("Gado");
            var interassado1 = new Interessada("Leandro", leilao);
            var interassado2 = new Interessada("Priscila", leilao);
            var interassado3 = new Interessada("Marina", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(interassado1, 220);
            leilao.RecebeLance(interassado2, 632);
            leilao.RecebeLance(interassado3, 120);

            leilao.TerminaPregao();

            Assert.Equal(leilao.Ganhador.Cliente, interassado2);

        }

        [Fact]
        public void LeilaoSemLances()
        {
            var leilao = new Leilao("Bicicleta");
            var interassado1 = new Interessada("Leandro", leilao);
            var interassado2 = new Interessada("Priscila", leilao);
            var interassado3 = new Interessada("Marina", leilao);

            leilao.TerminaPregao();
            var valorEsperado = 0;

            Assert.Equal(leilao.Ganhador.Valor, valorEsperado);

        }
    }
}
