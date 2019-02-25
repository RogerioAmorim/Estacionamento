using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public class ValorCalculado : IEqualityComparer<ValorCalculado>
    {
    
        public Veiculo veiculo {get;set;}
        public double valorCalculado { get; set; }
        public DateTime DataDoCalculo = DateTime.Now;

        public RegistroDeHorasDoVeiculo CompareData(DateTime Referencia)
        {
            return  veiculo.QtdVezesEstacionado.ToList().FirstOrDefault(x => x.DataDaEntrada.Equals(Referencia));
        }

        public override bool Equals(object obj)
        {
            try
            {
                var calculointerno = (ValorCalculado)obj;
                return this.Equals(calculointerno);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Equals(ValorCalculado x, ValorCalculado y)
        {
            return x.Equals(y);
        }
        public int GetHashCode(ValorCalculado obj)
        {
             return string.Concat(veiculo.GetHashCode(), this.DataDoCalculo.GetHashCode()).GetHashCode();
        }
    }
}
