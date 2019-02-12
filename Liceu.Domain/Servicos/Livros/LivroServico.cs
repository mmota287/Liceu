using Liceu.Dominio.Compartilhado;
using Liceu.Dominio.Entidades;
using Liceu.Dominio.Exececoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liceu.Dominio.Servicos
{
    public class LivroServico : ILivroServico
    {
        private readonly IRepositorio<Livro, Guid> _repositorio;

        public IRepositorio<User, string> repositorio { get; set; }

        public LivroServico(IRepositorio<Livro, Guid> repositorio)
        {
            _repositorio = repositorio;
        }

        public Livro BuscarLivroPorId(Guid Id)
        {
            Livro livro = _repositorio.RetornarPorId(Id);
            if (livro == null)
                throw new DominioExcecao("Livro não encontrado.");

            return livro;
        }

        public Livro InserirLivro(Livro livro)
        {
            if (livro == null)
                throw new DominioExcecao("Livro não pode ser vazio.");

            livro.Id = Guid.NewGuid();
            livro.DataCriacao = DateTime.Now;
            livro.Status = LivroStatusEnum.ATIVO;

            var livroInserido = _repositorio.Inserir(livro);
            _repositorio.SalvarAlteracoes();

            return livroInserido;
        }

        public Livro EditarLivro(Livro livro)
        {
            if (livro == null)
                throw new DominioExcecao("Livro não pode ser vazio.");

            Livro novoLivro = BuscarLivroPorId(livro.Id);

            novoLivro.DataAtualizacao = DateTime.Now;
            novoLivro.Ano = livro.Ano;
            novoLivro.Autor= livro.Autor;
            novoLivro.Editora = livro.Editora;
            novoLivro.Titulo = livro.Titulo;

            var livroAtualizado = _repositorio.Atualizar(novoLivro);
            _repositorio.SalvarAlteracoes();

            return livroAtualizado;
        }

      

        public Livro AtivarLivro(Guid id)
        {
            Livro livro = BuscarLivroPorId(id);

            livro.Status = LivroStatusEnum.ATIVO;
            livro.DataAtualizacao = DateTime.Now;

            return livro;
        }

        public Livro InativarLivro(Guid id)
        {
            Livro livro = BuscarLivroPorId(id);

            livro.Status = LivroStatusEnum.INATIVO;
            livro.DataAtualizacao = DateTime.Now;

            return livro;
        }

        public IEnumerable<Livro> BuscarLivros()
        {
            return _repositorio.RetornarTodos();
        }

        public IEnumerable<Livro> FiltrarLivros(string titulo, string autor, string editora, int ano)
        {
            return _repositorio.Filtrar(
                        p => p.Titulo.StartsWith(titulo)  ||
                        p.Autor.StartsWith(autor)  ||
                        p.Editora.StartsWith(editora)  ||
                        p.Ano == ano
                );
        
        }
    }
}
