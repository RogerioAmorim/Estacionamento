using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public class CalculoPrecoCarro:CalculoPreco
    {
        private readonly Veiculo _veiculoDeReferencia;

        public CalculoPrecoCarro(Veiculo VeiculoDeReferencia) : base(VeiculoDeReferencia)
        {
            _veiculoDeReferencia = VeiculoDeReferencia;
        }
        public override double PrecoPrimeiraHora()
        {
            return 3.0;
        }
        public override double PrecoPorHoraAdicional()
        {
            return 1.5;
        }
    }
}
