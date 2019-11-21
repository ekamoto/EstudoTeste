using System;

namespace Shindi.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            Cliente = cliente;

            if (valor < 0)
            {
                throw new ArgumentException("Lance inválido: valor deve ser maior que zero.");
            }
            
            Valor = valor;
        }
    }
}