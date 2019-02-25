using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public static class FuncoesUteis
    {
      public static IList<Tou> Convert<Tin, Tou>(this List<Tin> lista) where Tin: Veiculo where Tou : class
      {
          return lista.ToList().ConvertAll(x => x as Tou);
      }
    }
}
