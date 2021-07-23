using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornarPorId(int id);
        void Inserir(T entidade);
        void Inativar(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();
         
    }
}