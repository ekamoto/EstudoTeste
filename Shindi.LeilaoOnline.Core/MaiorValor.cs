using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shindi.LeilaoOnline.Core
{
    public class MaiorValor : IModalidadeAvaliacao
    {
        public MaiorValor()
        {
            
        }

        public Lance RetornaGanhador(IList<Lance> lances)
        {
            Lance Ganhador = lances
            .DefaultIfEmpty(new Lance(null, 0))
            .OrderBy(t => t.Valor).LastOrDefault();

            return Ganhador;
        }
    }
}
