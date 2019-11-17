using System;
using System.Collections.Generic;
using System.Text;
using Shindi.LeilaoOnline.Core;

namespace Shindi.LeilaoOnline.Core
{
    public class EstadoFinalizado : IEstado
    {
        public void AbrirLeilao(Leilao leilao)
        {
            throw new Exception("Leilão já está finalizado");
        }

        public void FinalizarLeilao(Leilao leilao)
        {
            throw new Exception("Leilão já está finalizado");
        }

        public void IniciarLeilao(Leilao leilao)
        {
            throw new Exception("Leilão já está finalizado");
        }
    }
}
