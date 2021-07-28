using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Ativo { get; set; }

       public Serie(int id, string titulo, string descricao, Genero genero, int ano)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Genero = genero;
            this.Ano = ano;
            this.Ativo = true;
        }

        public override string ToString()
        {
            string serie = "";
            serie += "Gênero: " + this.Genero + Environment.NewLine;
            serie += "Título: " + this.Titulo + Environment.NewLine;
            serie += "Descrição: " + this.Descricao + Environment.NewLine;
            serie += "Ano Lançamento: " + this.Ano + Environment.NewLine;
            serie += "Ativo: " + this.Ativo;
            return serie;
        }

        public string getTitulo()
        {
            return this.Titulo;
        }

        public int getId()
        {
            return this.Id;
        }

        public bool getAtivo()
        {
            return this.Ativo;
        }

        public void Inativar()
        {
            this.Ativo = false;
        }


    }
}