using System;
using System.Collections.Generic;
using System.Text;
using Shindi.LeilaoOnline.Core;

namespace Shindi.LeilaoOnline.Core
{
    public class EstadoEmAndamento : IEstado
    {
        public void AbrirLeilao(Leilao leilao)
        {
            throw new Exception("Leilão já está em andamento");
        }

        public void FinalizarLeilao(Leilao leilao)
        {
            leilao.Estado = new EstadoFinalizado();
        }

        public void IniciarLeilao(Leilao leilao)
        {
            throw new Exception("Leilão já está em andamento");
        }
    }
}
