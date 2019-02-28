using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Estacionamento
{
    public class BancoDeDadosEmMemoria
    {
        private static BancoDeDadosEmMemoria _singleton;
        private static object _lock = new object();
        public IList<ValorCalculado> ValoresCalculados;
       
        private BancoDeDadosEmMemoria()
        {
            ValoresCalculados = new List<ValorCalculado>();
        }

        public static BancoDeDadosEmMemoria Crie()
        {
            lock (_lock)
            {
                if (_singleton == null)
                    _singleton = new BancoDeDadosEmMemoria();
            }
            return _singleton;
        }

        public IList<ValorCalculado> SelectPorData<T>(DateTime Referencia)
        {
            try 
  	        {	        
	          return this.ValoresCalculados.ToList().Where(
                x => x.DataDoCalculo.Equals(Referencia)).ToList();
	        }
	        catch (Exception)
	        {
		        throw;
	        }
        }
        public IEnumerable<IGrouping<string, ValorCalculado>> SelecPorPlaca(EnumTipoDeCalculo enumTipoDeCalculo)
        {
            var GrupoPorTipoOrdenadoPorPlaca = ValoresCalculados.OrderBy(x => x.veiculo.Placa);
            
            return GrupoPorTipoOrdenadoPorPlaca.GroupBy(x => x.veiculo.GetType().Name);

        }
        public IList<DTOSelecPorAgrupamento> SelectPorAgrupamento()
        {
            List<DTOSelecPorAgrupamento> ListaDTOSelecPorAgrupamento = new List<DTOSelecPorAgrupamento>();
            
            var AgrupamentoPorData =
                from valorcalculo in ValoresCalculados
                group valorcalculo by valorcalculo.DataDoCalculo into NG
                select new DTOSelecPorAgrupamento
                { 
                    
                    DataReferecia = NG.Key, 
                    QTDMotosNaData = NG.Where(x=> x.veiculo.GetType()==typeof(Moto)).Count(),
                    QTDCarrosNaData = NG.Where(x=> x.veiculo.GetType()==typeof(Carro)).Count(),
                    QTDCamioneteNaData = NG.Where(x=> x.veiculo.GetType()==typeof(Camionete)).Count()
                };

            return AgrupamentoPorData.ToList();
    
        }
        public List<string> CalculeTempoMedioPorTipoDeVeiculo() //OTIMIZAR EM CASA
        {
            
            var TempoMedioMoto = new TimeSpan();
            var TempoMedioCarro = new TimeSpan();
            var TempoMedioCamionete = new TimeSpan();
            List<string> ListaComAsMedias = new List<string>();

            var AgrupamentoPorTipo =
                        from valorcalculado in ValoresCalculados
                        group valorcalculado by valorcalculado.veiculo.GetType() into NovoGrupo
                        select new {Lista = NovoGrupo}; 

            foreach (var item in AgrupamentoPorTipo)
	        {
		        foreach (ValorCalculado valorcalculado in item.Lista)
	            {
                    if (valorcalculado.veiculo.GetType() == typeof(Carro))
                        TempoMedioCarro = TempoMedioCarro + valorcalculado.veiculo.TotalDeHorasGastaNoEstacionamento();
                        
                    if (valorcalculado.veiculo.GetType() == typeof(Moto))
                        TempoMedioMoto = TempoMedioMoto + valorcalculado.veiculo.TotalDeHorasGastaNoEstacionamento();
                    if(valorcalculado.veiculo.GetType() == typeof(Camionete))
                        TempoMedioCamionete = TempoMedioCamionete + valorcalculado.veiculo.TotalDeHorasGastaNoEstacionamento();
	            }
        	}
            ListaComAsMedias.Add("Tipo:Moto Media:"+ TempoMedioMoto);
            ListaComAsMedias.Add("Tipo:Carro Media:" + TempoMedioCarro);
            ListaComAsMedias.Add("Tipo:Camionete Media:" + TempoMedioCamionete);

           return ListaComAsMedias;
        }
    }
    public class DTOSelecPorAgrupamento
    {
        public DateTime DataReferecia { get; set; }
        public int QTDMotosNaData { get; set; }
        public int QTDCarrosNaData { get; set; }
        public int QTDCamioneteNaData { get; set; }
        
    }
}