using System;
using Liceu.Dominio.Compartilhado;

namespace Liceu.Dominio.Entidades
{
    public class Livro: Entidade
    {
        public string Titulo { get; set; }

        public int Ano { get; set; }

        public string Autor { get; set; }

        public string Editora { get; set; }
        public LivroStatusEnum Status { get; set; }
    }
}
