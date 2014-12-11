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
            return _queryableSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region IQueryable

        public Expression Expression { get; set; }

        public Type ElementType
        {
            get { return typeof (T); }
            
        }
        public IQueryProvider Provider { get; private set; }
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