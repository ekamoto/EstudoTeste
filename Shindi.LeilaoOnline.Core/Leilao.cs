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

        private IModalidadeAvaliacao _modalidadeAvaliacao { get; }

        public Leilao(string peca, IModalidadeAvaliacao modalidade = null)
        {
            _modalidadeAvaliacao = modalidade;
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
            
            Ganhador = _modalidadeAvaliacao.RetornaGanhador(_lances);
            
            Estado.FinalizarLeilao(this);
        }
    }
}