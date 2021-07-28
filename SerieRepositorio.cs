using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();        
        public void Inserir(Serie entidade)
        {
            listaSerie.Add(entidade);
            Console.WriteLine("Série inserida com sucesso!");
        }
        public void Atualizar(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }
        public void Inativar(int id)
        {
            listaSerie[id].Inativar();
            Console.WriteLine("Série inativada com sucesso!");
        }
        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornarPorId(int id)
        {
            return listaSerie[id];
        }

    }
}