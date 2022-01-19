using System;
using System.Collections.Generic;
using cadastroEventos_dio.Interface;

namespace cadastroEventos_dio
{
    public class RepositorioEvento : IRepositorioEvento<Evento>
    {
        List<Evento> Eventos = new List<Evento>();

        public List<Evento> Lista()
        {
            return Eventos;
        }

        public Evento GetById(int id)
        {
            return Eventos[id];
        }

        public void Insere(Evento obj)
        {
            Eventos.Add(obj);
        }

        public void Exclui(int id)
        {
            Eventos[id].Excluir();
        }

        public void Atualiza(int id, Evento obj)
        {
            Eventos[id] = obj;
        }

        public int NextId()
        {
           return Eventos.Count;
        }
    }
}