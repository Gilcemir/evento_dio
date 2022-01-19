using System.Collections.Generic;
namespace cadastroEventos_dio.Interface
{
    public interface IRepositorioEvento<T>
    {
        List<T> Lista();

        T GetById(int id);

        void Insere(T obj);

        void Exclui(int id);

        void Atualiza(int id, T obj);

        int NextId();
    }
}
