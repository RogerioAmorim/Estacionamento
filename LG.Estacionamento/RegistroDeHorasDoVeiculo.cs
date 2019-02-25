using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public class RegistroDeHorasDoVeiculo
    {
        public Veiculo veiculo { get; set; }
        public DateTime DataDaEntrada { get; set; }
        
        
        public RegistroDeHorasDoVeiculo(DateTime dataDaEntrada)
        {
            this.DataDaEntrada = dataDaEntrada;
        }
        
        public TimeSpan QtdHorasEstacionado()
        {
            return DataDaEntrada - DateTime.Now;
        }
        
    }
}
