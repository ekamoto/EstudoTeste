using System;
using System.Collections.Generic;
using System.Text;

namespace Shindi.LeilaoOnline.Core
{
    public interface IModalidadeAvaliacao
    {
        Lance RetornaGanhador(IList<Lance> lances);
    }
}
