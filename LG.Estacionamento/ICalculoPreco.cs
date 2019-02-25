using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public interface ICalculoPreco
    {
       double CalculoPrecoTotal(Veiculo veiculo);
    }
}
