using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LG.Estacionamento
{
    
    class BancoDeDadosGenerico<T>
    {
        private static BancoDeDadosGenerico<T> _singleton;
        private static object _lock = new object();
        private IList<T> Tabelas;

        public delegate IList<T> TratamentoLista(IList<T> lista);
        
   
        TratamentoLista trateLista2 = y => y.OrderBy(z=>z.GetType()).ToList();

      
        private BancoDeDadosGenerico()
        {
            Tabelas = new List<T>();
        }

        public static BancoDeDadosGenerico<T> Crie()
        {
            lock (_lock)
            {
                if (_singleton == null)
                    _singleton = new BancoDeDadosGenerico<T>();
            }
            return _singleton;
        }

        public IList<T> Select()
        {
            return this.Tabelas.ToList().Where(x => x.GetType() == typeof(T)).ToList();
        }

        public IEnumerable<T> Select(Func<T, bool> Predicate, TratamentoLista DelTrateLista)
        {
            return DelTrateLista(Tabelas.ToList<T>().Where(Predicate).ToList());
        }

        
        public bool Add(T item)
        {
            try
            {
                this.Tabelas.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(T item)
        {
            try
            {
                this.Tabelas.Remove(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int index)
        {
            try
            {
                this.Tabelas.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

