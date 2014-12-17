using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace TddDemo.Test
{
    public class InMemoryDbSet<T> : IDbSet<T> where T : class
    {
        public InMemoryDbSet()
            : this(Enumerable.Empty<T>()) {
            }
        public InMemoryDbSet(IEnumerable<T> entities) {
            _set = new HashSet<T>();
            foreach (var entity in entities) {
                _set.Add(entity);
            }
            _queryableSet = _set.AsQueryable();
        }
        
        readonly HashSet<T> _set;
        readonly IQueryable<T> _queryableSet;
        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        #region IQueryable

        public Expression Expression
        {
            get { return _queryableSet.Expression; }
        }

        public Type ElementType
        {
            get { return _queryableSet.ElementType; }
            
        }

        public IQueryProvider Provider
        {
            get { return _queryableSet.Provider; }
        }

        #endregion

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            _set.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            _set.Remove(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            _set.Add(entity);
            return entity;
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<T> Local { get; private set; }
    }
}