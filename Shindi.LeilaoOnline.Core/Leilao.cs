using System;
using System.Collections.Generic;
using System.Linq;

namespace Shindi.LeilaoOnline.Core
{
    public class Leilao
    {
        
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }

        public Lance Ganhador { get; private set; }

        public IEstado Estado { get; set; }
        private Interessada _ultimoLanceIntessado { get; set; }

        public Leilao(string peca)
        {
            Estado = new EstadoEmEspera();
            Peca = peca;
            _lances = new List<Lance>();
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (_ultimoLanceIntessado != cliente)
            {
                if (Estado.GetType() == new EstadoEmAndamento().GetType())
                {
                    _lances.Add(new Lance(cliente, valor));
                    _ultimoLanceIntessado = cliente;
                }
            }
        }

        public void IniciaPregao()
        {
            Estado.IniciarLeilao(this);
            Console.WriteLine("Leilão Iniciado");
        }

        public void TerminaPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(t => t.Valor).LastOrDefault();

            Estado.FinalizarLeilao(this);
        }
    }
}