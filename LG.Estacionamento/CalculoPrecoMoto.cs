using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public class CalculoPrecoMoto:CalculoPreco
    {
        private readonly Veiculo _veiculodereferencia;

        public CalculoPrecoMoto(Veiculo VeiculoDeReferencia) : base(VeiculoDeReferencia)
        {
            _veiculodereferencia = VeiculoDeReferencia;
        }

        public override double PrecoPrimeiraHora()
        {
            return 1.5;
        }

        public override double PrecoPorHoraAdicional()
        {
            return 1.0;
        }

    }
}
