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
            Moto moto = new Moto(); 
           var maquinadecalculopreco = FabricaMaquinaDeCalculoPreco.Crie().CrieMaquinaDeCalculoPreco(moto, EnumTipoDeCalculo.Moto);
           maquinadecalculopreco.CalculoPrecoTotal(moto);
        }
    }
}
