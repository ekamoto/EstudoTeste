using Xunit;
using Shindi.LeilaoOnline.Core;
using System.Linq;

namespace Shindi.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(2, new double[] { 100, 200})]
        [InlineData(4, new double[] { 100, 200, 635, 985 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdEsperada, double[] ofertas)
        {
            // Arranje - cenário
            var leilao = new Leilao("Bicicleta");
            leilao.IniciaPregao();

            var interassado1 = new Interessada("Leandro", leilao);
            var interassado2 = new Interessada("Priscila", leilao);

            foreach (var oferta in ofertas)
            {
                leilao.RecebeLance(interassado1, oferta);
            }

            leilao.TerminaPregao();

            // Act - método sob teste
            leilao.RecebeLance(interassado2, 532);
            var quantidadeDeLancesEsperado = qtdEsperada;

            Assert.Equal(leilao.Lances.Count(), quantidadeDeLancesEsperado);
        }

        [Theory]
        [InlineData(0, new double[] { 100, 200 })]
        [InlineData(0, new double[] { 100, 200, 635, 985 })]
        public void QtdePermaneceZeroDadoQuePregaoNaoFoiIniciado(int qtdEsperada, double[] ofertas) 
        {
            // Arranje - cenário
            var leilao = new Leilao("Bicicleta");
            
            var interassado1 = new Interessada("Leandro", leilao);
            var interassado2 = new Interessada("Priscila", leilao);

            foreach (var oferta in ofertas)
            {
                leilao.RecebeLance(interassado1, oferta);
            }

            var quantidadeDeLancesEsperado = qtdEsperada;

            Assert.Equal(leilao.Lances.Count(), quantidadeDeLancesEsperado);
        }
    }
}
