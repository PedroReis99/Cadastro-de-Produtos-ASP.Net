using AppMVC.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AppMVC.Repository
{
    //T parametro genérico
    //entity: são os parametros que vão ser utilizados em cada função
    public class Repository<T> : IDisposable where T : class
    {
        ContextApp _context;
        DbSet<T> _dbSet;
            
        public Repository(ContextApp context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindAll()
        {//Recebe um parametro generico para retornar todos os dados
            return _context.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {//Recebe um parametro generico para pesquisa
            return _dbSet.Where(predicate);
        }

        public T FindById(int id)
        {//Recebe um parametro generico para pesquisar pela ID
            return _dbSet.Find(id);
        }

        public void Remove(T entity)//Recebe um parametro generico para remover
        {
            _context.Set<T>().Remove(entity);
        }

        public void Add(T entity)//Recebe um parametro generico para adicionar
        {
            _context.Set<T>().Add(entity);
        }
    }
}