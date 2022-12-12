using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    // class: reference type. do not send int-style value types
    // IEntity(X) : send X or something that implements X.
    // new() : must be newable... interfaces cannot be newed so it says to send IEntity which is an interface...
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //if there is a filter submission status, work according to that filter.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}