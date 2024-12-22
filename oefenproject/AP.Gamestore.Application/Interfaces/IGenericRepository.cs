﻿using AP.MyGameStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll(int pageNr, int pageSize);

        Task<T> GetById(int id);
        Task<T> Create(T newStore);

        T Update(T modifiedStore);
        void Delete(T store);
    }
}
