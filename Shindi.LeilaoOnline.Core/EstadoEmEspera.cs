using System;
using System.Collections.Generic;
using System.Text;
using Shindi.LeilaoOnline.Core;

namespace Shindi.LeilaoOnline.Core
{
    public class EstadoEmEspera : IEstado
    {
        public void AbrirLeilao(Leilao leilao)
        {
            throw new Exception("Leilão já está em espera");
        }

        public void FinalizarLeilao(Leilao leilao)
        {
            throw new Exception("Leilão não pode ser finalizado pois ainda está em espera");
        }

        public void IniciarLeilao(Leilao leilao)
        {
            leilao.Estado = new EstadoEmAndamento();
        }
    }
}
