using System;
using System.Collections.Generic;
using System.Linq;

namespace Shindi.LeilaoOnline.Core
{
    public enum EstadoLeilao
    { 
        LeilaoEmEspera,
        LeilaoEmAndamento,
        LeilaoFinalizado
    };

    public class Leilao
    {
        
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }

        public Lance Ganhador { get; private set; }

        public EstadoLeilao Estado { get; set; }

        public Leilao(string peca)
        {
            Estado = EstadoLeilao.LeilaoEmEspera;
            Peca = peca;
            _lances = new List<Lance>();
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if(Estado.Equals(EstadoLeilao.LeilaoEmAndamento))
                _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
            Console.WriteLine("Leilão Iniciado");
        }

        public void TerminaPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(t => t.Valor).LastOrDefault();
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}