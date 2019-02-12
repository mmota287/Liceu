using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Liceu.Dominio.Compartilhado
{
    public interface IRepositorio<TEntity, TKey> where TEntity : Entidade
    {
        TEntity Inserir(TEntity obj);

        TEntity RetornarPorId(TKey id);

        IQueryable<TEntity> RetornarTodos();

        IEnumerable<TEntity> Filtrar(
            Expression<Func<TEntity, bool>> filtro = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordernacao = null,
            string relacionamentos = "");

        TEntity Atualizar(TEntity entidade);

        void Remover(Guid id);

        int SalvarAlteracoes();
    }
}
