using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shindi.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {

        private double _valorDestino { get; }
        public OfertaSuperiorMaisProxima(double valor)
        {
            _valorDestino = valor;
        }
        public Lance RetornaGanhador(IList<Lance> lances)
        {
            Lance Ganhador = lances
                    .Where(l => l.Valor > _valorDestino)
                    .DefaultIfEmpty(new Lance(null, 0))
                    .OrderBy(l => l.Valor)
                    .FirstOrDefault();

            return Ganhador;
        }
    }
}
