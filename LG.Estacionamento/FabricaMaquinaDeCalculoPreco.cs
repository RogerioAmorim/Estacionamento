using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public class FabricaMaquinaDeCalculoPreco
    {
        private static FabricaMaquinaDeCalculoPreco _singleton;
        private static object _lock = new object();
        public static FabricaMaquinaDeCalculoPreco Crie()
        {
            lock(_lock)
            {
                if (_singleton == null)
                    _singleton = new FabricaMaquinaDeCalculoPreco();
            }

            return _singleton;
        }

        private FabricaMaquinaDeCalculoPreco()
        {
        }

        public ICalculoPreco CrieMaquinaDeCalculoPreco(Veiculo veiculo, EnumTipoDeCalculo enumTipoCalculo) 
        {
            switch (enumTipoCalculo)
            {
                case EnumTipoDeCalculo.Carro:
                    return new CalculoPrecoCarro(veiculo);
                    
                case EnumTipoDeCalculo.Moto:
                    return new CalculoPrecoMoto(veiculo);

                case EnumTipoDeCalculo.Camionete:
                    return new CalculoPrecoCamionete(veiculo);
   
                default:
                    throw new ArgumentException("Por favor, prestar atenção no calculo");
            }
        }
    }
}
