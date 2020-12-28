using System;
using System.Linq;
using System.Linq.Expressions;

namespace Facturacion.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> AsQueryable();
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        bool Exists(Expression<Func<T, bool>> predicate);
        T AddAndGetEntity(T entity);
        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
    }
}
