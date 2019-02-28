using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LG.Estacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Veiculo moto = new Moto();
            Veiculo carro = new Carro();
            Veiculo camionete = new Camionete();
        
            var maquinadecalculopreco = FabricaMaquinaDeCalculoPreco.Crie().CrieMaquinaDeCalculoPreco(moto, EnumTipoDeCalculo.Moto);
            maquinadecalculopreco.CalculoPrecoTotal(moto);

            maquinadecalculopreco = FabricaMaquinaDeCalculoPreco.Crie().CrieMaquinaDeCalculoPreco(carro, EnumTipoDeCalculo.Carro);
            maquinadecalculopreco.CalculoPrecoTotal(carro);
            
            maquinadecalculopreco = FabricaMaquinaDeCalculoPreco.Crie().CrieMaquinaDeCalculoPreco(camionete, EnumTipoDeCalculo.Carro);
            maquinadecalculopreco.CalculoPrecoTotal(camionete);

        }
    }
}
