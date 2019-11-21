using Shindi.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Shindi.LeilaoOnline.Tests
{
    public class LeilaoCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoLanceNegativo()
        {
            // Arranje/Cenário
            var valorNegativo = -200;

            // Assert
            var retornoException = Assert.Throws<ArgumentException>(
                // Act
                () => new Lance(new Interessada("", new Leilao("teste")), valorNegativo)
            );

        }
    }
}
