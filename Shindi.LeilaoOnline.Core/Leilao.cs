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

        private double _valorDestino { get; }

        public Leilao(string peca, double valorDestino = 0)
        {
            _valorDestino = valorDestino;
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
            if (Estado.GetType() == new EstadoEmEspera().GetType())
            {
                throw new InvalidOperationException("Não é possível finalizar um pregão que não foi iniciado");
            }
            if (_valorDestino > 0)
            {

                // Modalidade oferta superior mais próxima
                Ganhador = Lances
                    .Where(l => l.Valor > _valorDestino)
                    .DefaultIfEmpty(new Lance(null, 0))
                    .OrderBy(l => l.Valor)
                    .FirstOrDefault();
            }
            else {

                // Modalidade maior lance
                Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(t => t.Valor).LastOrDefault();
            }
            

            Estado.FinalizarLeilao(this);
        }
    }
}