
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Entities;
using Contracts;

namespace Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }

        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        //public void Create(T entity)
        //{
        //    this.RepositoryContext.Set<T>().Add(entity);
        //}

        //public void Update(T entity)
        //{
        //    this.RepositoryContext.Set<T>().Update(entity);
        //}

        //public void Delete(T entity)
        //{
        //    this.RepositoryContext.Set<T>().Remove(entity);
        //}
    }
}
