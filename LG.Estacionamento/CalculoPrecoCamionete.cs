using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public class CalculoPrecoCamionete:CalculoPreco
    {
        private readonly Veiculo _veiculoDeReferencia;

        public CalculoPrecoCamionete(Veiculo VeiculoDeReferencia) : base(VeiculoDeReferencia)
        {
            _veiculoDeReferencia = VeiculoDeReferencia;

        }
        public override double PrecoPrimeiraHora()
        {
            return 5.0;  
        }
        public override double PrecoPorHoraAdicional()
        {
            return 3.0;    
        }
    }
}
