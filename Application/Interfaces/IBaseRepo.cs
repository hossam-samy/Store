﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBaseRepo<T>
    {
        public Task<IEnumerable<TResult>> Get<TResult>(Func<T, bool> match, Func<T, TResult> selector);
        public Task<IEnumerable<TResult>> Get<TResult>(Func<T, TResult> selector);
        public Task<List<T>> Get(Func<T, bool> match);
        public Task<IEnumerable<T>> Get(Func<T, bool> match, string[] include);
        public Task<IEnumerable<TResult>> Get<TResult>(Func<T, TResult> selector, string include);
        public Task AddAsync(T item);
        public Task Delete(T item);
        public Task Update(T item);
        public Task<IEnumerable<T>> GetAll();


    }
}
