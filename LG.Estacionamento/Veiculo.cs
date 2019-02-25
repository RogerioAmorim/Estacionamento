using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public abstract class Veiculo
    {
        public Veiculo(String placa):this()
        {
            this.Placa = placa;
        }

        protected Veiculo()
        {
            this.QtdVezesEstacionado = new List<RegistroDeHorasDoVeiculo>();
        }

        public string Placa{get;set;}
        public static int VezeUtilizada { get; set; }
        public IList <RegistroDeHorasDoVeiculo> QtdVezesEstacionado{ get; set; }
        private string _placadereferencia {get;set;}

        protected bool ComparePlacas(RegistroDeHorasDoVeiculo x)
        {
            return x.veiculo.Placa.Equals(_placadereferencia);    
        }

        public TimeSpan QuantidadeDeHorasEstacionado(String PlacaDeReferencia)
        {
            _placadereferencia = PlacaDeReferencia;    
            return this.QtdVezesEstacionado.FirstOrDefault(ComparePlacas).QtdHorasEstacionado();
        }
        public TimeSpan TotalDeHorasGastaNoEstacionamento()
        { 
            var tempomedio = new TimeSpan();
            QtdVezesEstacionado.ToList().ForEach(x =>
            {
                tempomedio = tempomedio + x.QtdHorasEstacionado();
            });

            return tempomedio;
        }
        public bool EntradaGratis() 
        {
            if(QtdVezesEstacionado.Count() % 3 == 0)
                return true;
            
            return false;
        }

      
    }
}
