﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepo<T> Repository<T>() where T : class;
        Task<int> SaveAsync();
    }
}
