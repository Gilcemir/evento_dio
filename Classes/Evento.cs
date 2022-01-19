using System;

namespace cadastroEventos_dio
{
    public class Evento : eventoBase
    {

        private string Titulo { get; set; }
        private Modalidade Modalidade { get; set; }
        private string Organizador { get; set; }
        private int ano { get; set; }
        private bool excluido { get; set; }
    
        public Evento(int id, string titulo, Modalidade modalidade, string organizador, int ano) 
        {
                this.id = id;
                this.Titulo = titulo;
                this.Modalidade = modalidade;
                this.Organizador = organizador;
                this.ano = ano;
                this.excluido = false;     
        }


        public override string ToString()
		{
            string str = "";
            str+= "Id : "+ this.id + " | ";
            str+= "Título : "+ this.Titulo + " | ";
            str+= "Modalidade : "+ this.Modalidade + " | ";
            str+= "Ano : "+ this.ano + " | ";
            str+= "Organizador: " + this.Organizador;
            return str;
        }
        public void Excluir()
        {
            this.excluido = true;
        }

        public bool Excluido()
        {
            return this.excluido;
        }
    }
}
