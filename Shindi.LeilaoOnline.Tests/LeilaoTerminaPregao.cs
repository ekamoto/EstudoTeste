using System;
using System.Collections.Generic;
using System.Text;
using Shindi.LeilaoOnline.Core;
using Xunit;

namespace Shindi.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {

        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        public void RetornaValorMaisProximoDoValorEstimadoDadoModalidade(
            double valorDestino,
            double valorEsperado,
            double[] ofertas)
        {
            // valorDestino - é o valor esperado para aquele leilão
            // o lance vencedor é o primeiro valor superior ao valor destino
            // no caso é 1250 e não 1400

            OfertaSuperiorMaisProxima modalidade = new OfertaSuperiorMaisProxima(1200);

            // Arranje - cenário
            var leilao = new Leilao("Bicicleta", modalidade);
            leilao.IniciaPregao();

            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            for (var i = 0; i < ofertas.Length; i++)
            {
                if (i % 2 == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }
                else
                {
                    leilao.RecebeLance(maria, ofertas[i]);
                }
            }

            leilao.TerminaPregao();

            // Act - método sob teste
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);

        }

        [Theory]
        [InlineData(800, new double[] { 800, 900, 1000 })]
        [InlineData(800, new double[] { 800, 1000, 900 })]
        [InlineData(350, new double[] { 350 })]
        public void RetornaValorDadoLeilaoComPeloMenosUmLance(double valor, double[] ofertas)
        {
            // give when then
            // Arrange Act Assert
            // Arranje - cenário de entrada
            // Dado(give) leilão com 2 clientes sendo que fulado deu dois Lances, um de 800 e outro de 1000
            // e maria deu um lance 900

            MaiorValor modalidade = new MaiorValor();
            var leilao = new Leilao("Jogos", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            foreach (var oferta in ofertas)
            {
                leilao.RecebeLance(fulano, oferta);
            }

            // Act - método sob teste
            // Quando o leilão/pregão termina
            leilao.TerminaPregao();

            // Assert
            // Então o valor esperado é o maior valor, no caso é 100
            var valorEsperado = valor;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void VerificaClienteGanhador()
        {
            MaiorValor modalidade = new MaiorValor();
            var leilao = new Leilao("Gado", modalidade);
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
        public void RetornaZeroDadoLeilaoSemLances()
        {
            MaiorValor modalidade = new MaiorValor();
            var leilao = new Leilao("Bicicleta", modalidade);
            var interassado1 = new Interessada("Leandro", leilao);
            var interassado2 = new Interessada("Priscila", leilao);
            var interassado3 = new Interessada("Marina", leilao);
            leilao.IniciaPregao();
            leilao.TerminaPregao();
            var valorEsperado = 0;

            Assert.Equal(leilao.Ganhador.Valor, valorEsperado);

        }
    }
}
