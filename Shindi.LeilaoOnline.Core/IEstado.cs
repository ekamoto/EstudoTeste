using Shindi.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shindi.LeilaoOnline.Core
{
    public interface IEstado
    {
        void AbrirLeilao(Leilao leilao);
        void IniciarLeilao(Leilao leilao);
        void FinalizarLeilao(Leilao leilao);
    }
}
