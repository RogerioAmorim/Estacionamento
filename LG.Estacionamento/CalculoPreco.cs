using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public abstract class CalculoPreco:ICalculoPreco
    {
        private readonly Veiculo _veiculoDeReferencia;
        private const double _numeroDeMinutosTolerado = 14.99;
        private const double _numeroAteVirarHora = 60.0;
        private const double _primeiraHoraEstacionada = 60.0;


        public CalculoPreco(Veiculo VeiculoDeReferencia)
        {
            _veiculoDeReferencia = VeiculoDeReferencia;
        }

        public abstract double PrecoPrimeiraHora();
        public abstract double PrecoPorHoraAdicional();

        public double CalculoPrecoTotal(Veiculo veiculo)
        {
            if(veiculo.EntradaGratis())
                return 0;
            else if (veiculo.QuantidadeDeHorasEstacionado(veiculo.Placa).TotalMinutes > _numeroDeMinutosTolerado)
                return 0;
            else if ((veiculo.QuantidadeDeHorasEstacionado(veiculo.Placa).TotalMinutes < _numeroDeMinutosTolerado &&
                     veiculo.QuantidadeDeHorasEstacionado(veiculo.Placa).TotalMinutes <= _numeroAteVirarHora))
                return PrecoPrimeiraHora();
            else
                return PrecoPrimeiraHora() +
                    Math.Ceiling(veiculo.QuantidadeDeHorasEstacionado(veiculo.Placa).TotalHours - _primeiraHoraEstacionada) * PrecoPorHoraAdicional();
        }
    }
}
