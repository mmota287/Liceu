using Liceu.Dados.Contexto;
using Liceu.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Liceu.Dados.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : Entidade
    {
        protected readonly LiceuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repositorio(LiceuDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Inserir(TEntity entidade)
        {
            DbSet.Add(entidade);
            return entidade;
        }

        public TEntity Atualizar(TEntity entidade)
        {
            DbSet.Update(entidade);
            return entidade;
        }

        public TEntity RetornarPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> RetornarTodos()
        {
            return DbSet;
        }

        public IEnumerable<TEntity> Filtrar(Expression<Func<TEntity, bool>> filtro = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordernacao = null, string relacionamentos = "")
        {
            IQueryable<TEntity> consulta = DbSet;

            if (filtro != null)
            {
                consulta = consulta.Where(filtro);
            }

            foreach (var includeProperty in relacionamentos.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                consulta = consulta.Include(includeProperty);
            }

            if (ordernacao != null)
            {
                return ordernacao(consulta).ToList();
            }
            else
            {
                return consulta.ToList();
            }
        }


        public void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SalvarAlteracoes()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
