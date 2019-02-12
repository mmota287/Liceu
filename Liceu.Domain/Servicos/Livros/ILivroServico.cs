using Liceu.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Liceu.Dominio.Servicos
{
    public interface ILivroServico
    {
        Livro InserirLivro(Livro livro);

        Livro EditarLivro(Livro livro);

        IEnumerable<Livro> BuscarLivros();

        IEnumerable<Livro> FiltrarLivros(string titulo,string autor, string editora,int ano);

        Livro BuscarLivroPorId(Guid id);

        Livro InativarLivro(Guid id);

        Livro AtivarLivro(Guid id);
    }
}